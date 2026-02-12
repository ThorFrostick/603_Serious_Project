using UnityEngine;

public class ExchangeResources : MonoBehaviour
{
    //The amount of resources that will be exchanged between the two nations.
    private float deltaOil, deltaFood, deltaCurrency;

    //Get the two nations in our scene.
    private GameObject nationA;
    private GameObject nationB;

    //We will use bools to determine if nation A will give or receive certain resources.
    private bool nationAGivesOil, nationAGivesFood, nationAGivesCurrency;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Get the two nations using the tags in Unity Inspector.
        nationA = GameObject.FindGameObjectWithTag("Nation_A");
        nationB = GameObject.FindGameObjectWithTag("Nation_B");

        //On startup/creation, randomly assign a change in the resources.
        deltaOil = Random.Range(0.0f, 0.5f);
        deltaFood = Random.Range(0.0f, 0.5f);
        deltaCurrency = Random.Range(0.0f, 0.5f);

        //For each of the resources, determine which nation will give and/or receive them.
        nationAGivesOil = CoinFlip();
        nationAGivesFood = CoinFlip();
        nationAGivesCurrency = CoinFlip();
    }

    private bool CoinFlip()
    {
        if(Random.Range(0.0f, 1.0f) > 0.5f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Exchange the resources between the two nations using our determined bools.
    /// </summary>
    public void Exchange()
    {
        //When we exchange resources, increment or decrement the resources for each nation.
        if (nationAGivesOil)
        {
            //If Nation A is giving a resource, set the change in that resource to negative.
            deltaOil = -deltaOil;
        }
        if (nationAGivesFood)
        {
            deltaFood = -deltaFood;
        }
        if (nationAGivesCurrency)
        {
            deltaCurrency = -deltaCurrency;
        }

        //Update Nation A's resources using the new base values for the change.
        nationA.GetComponent<NationalResources>().UpdateResources(deltaOil, deltaFood, deltaCurrency);
        Debug.Log($"Nation A => Oil: {nationA.GetComponent<NationalResources>().Oil}, Food: {nationA.GetComponent<NationalResources>().Food}, Capital: {nationA.GetComponent<NationalResources>().Currency}");
        
        //Then, update Nation B's resources with the inverse of Nation A's change in resources.
        nationB.GetComponent<NationalResources>().UpdateResources(-deltaOil, -deltaFood, -deltaCurrency);
        Debug.Log($"Nation B => Oil: {nationB.GetComponent<NationalResources>().Oil}, Food: {nationB.GetComponent<NationalResources>().Food}, Capital: {nationB.GetComponent<NationalResources>().Currency}");
    }
}
