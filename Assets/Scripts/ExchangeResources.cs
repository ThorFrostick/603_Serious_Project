using TMPro;
using UnityEngine;

public class ExchangeResources : MonoBehaviour
{
    //The amount of resources that will be exchanged between the two nations.
    private float deltaOil, deltaLand, deltaCurrency;

    //Get the two nations in our scene.
    private GameObject nationA;
    private GameObject nationB;

    //We will use bools to determine if nation A will give or receive certain resources.
    private bool nationAGivesOil, nationAGivesLand, nationAGivesCurrency;

    //Additionally, get the Bars that show the amount of resources each nation has.
    private ResourceUpdateManager resources;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Get the two nations using the tags in Unity Inspector.
        nationA = GameObject.FindGameObjectWithTag("Nation_A");
        nationB = GameObject.FindGameObjectWithTag("Nation_B");

        //On startup/creation, randomly assign a change in the resources.
        deltaOil = Random.Range(0.0f, 0.25f);
        deltaLand = Random.Range(0.0f, 0.25f);
        deltaCurrency = Random.Range(0.0f, 0.25f);

        //For each of the resources, determine which nation will give and/or receive them.
        nationAGivesOil = CoinFlip();
        nationAGivesLand = CoinFlip();
        nationAGivesCurrency = CoinFlip();

        //Get the resource manager for the two nations' resources.
        resources = GameObject.FindFirstObjectByType<ResourceUpdateManager>();
        resources.Reset();

        //The resourceBars list is all of our resources for each nation.
        // 0 = Nation A Oil
        resources.UpdateResource(0, -1 + nationA.GetComponent<NationalResources>().Oil);
        // 1 = Nation A Land
        resources.UpdateResource(1, -1 + nationA.GetComponent<NationalResources>().Land);
        // 2 = Nation A Currency
        resources.UpdateResource(2, -1 + nationA.GetComponent<NationalResources>().Currency);
        // 3 = Nation B Oil
        resources.UpdateResource(3, -1 + nationB.GetComponent<NationalResources>().Oil);
        // 4 = Nation B Land
        resources.UpdateResource(4, -1 + nationB.GetComponent <NationalResources>().Land);
        // 5 = Nation B Currency
        resources.UpdateResource(5, -1 + nationB.GetComponent<NationalResources>().Currency);

        //Display the information we have determined about this policy on screen
        Display();
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
        if (nationAGivesLand)
        {
            deltaLand = -deltaLand;
        }
        if (nationAGivesCurrency)
        {
            deltaCurrency = -deltaCurrency;
        }

        //Reset the bars on screen to accurately showcase the following changes.
        resources.Reset();

        //Update Nation A's resources using the new base values for the change.
        nationA.GetComponent<NationalResources>().UpdateResources(deltaOil, deltaLand, deltaCurrency);
        Debug.Log($"Nation A => Oil: {nationA.GetComponent<NationalResources>().Oil}, Land: {nationA.GetComponent<NationalResources>().Land}, Capital: {nationA.GetComponent<NationalResources>().Currency}");

        //Then, update Nation B's resources with the inverse of Nation A's change in resources.
        nationB.GetComponent<NationalResources>().UpdateResources(-deltaOil, -deltaLand, -deltaCurrency);
        Debug.Log($"Nation B => Oil: {nationB.GetComponent<NationalResources>().Oil}, Land: {nationB.GetComponent<NationalResources>().Land}, Capital: {nationB.GetComponent<NationalResources>().Currency}");
    }

    /// <summary>
    /// Display the information of the policy on screen, including who exchanges what.
    /// </summary>
    private void Display()
    {
        //First, get the Text display of our policy.
        TMP_Text text = gameObject.GetComponentInChildren<TMP_Text>();

        //Now, we want to display the information in a readable format for the player.
        //We will go through each of the resources and show what nation will be giving resources.
        //text.text = "Request:\n";
        //if (nationAGivesOil)
        //{
        //    text.text += $"Nation B requests {deltaOil.ToString("F2")} units of Oil from Nation A\n";
        //}
        //else
        //{
        //    text.text += $"Nation A requests {deltaOil.ToString("F2")} units of Oil from Nation B\n";
        //}
        //if (nationAGivesLand)
        //{
        //    text.text += $"Nation B requests {deltaLand.ToString("F2")} units of Land from Nation A\n";
        //}
        //else
        //{
        //    text.text += $"Nation A requests {deltaLand.ToString("F2")} units of Land from Nation B\n";
        //}
        //if (nationAGivesCurrency)
        //{
        //    text.text += $"Nation B requests {deltaCurrency.ToString("F2")} units of Capital from Nation A\n";
        //}
        //else
        //{
        //    text.text += $"Nation A requests {deltaCurrency.ToString("F2")} units of Capital from Nation B\n";
        //}
    }
}
