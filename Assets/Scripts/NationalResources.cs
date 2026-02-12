using UnityEngine;

public class NationalResources : MonoBehaviour
{
    //The amounts of Oil, Food, and Capital this nation possesses
    [SerializeField]
    private float oil, food, currency;

    public float Oil
    {
        get
        {
            return oil;
        }
    }

    public float Food
    {
        get
        {
            return food;
        }
    }

    public float Currency
    {
        get
        {
            return currency;
        }
    }

    /// <summary>
    /// Call to Increment or Decrement the resources this nation possesses.
    /// Parameters must be negative to decrement the amount.
    /// </summary>
    /// <param name="deltaOil">Change in this nation's Oil</param>
    /// <param name="deltaFood">Change in this nation's Food</param>
    /// <param name="deltaCurrency">Change in this nation's Capital</param>
    public void UpdateResources(float deltaOil, float deltaFood, float deltaCurrency)
    {
        //Add the change to all the resources.
        oil += deltaOil;
        food += deltaFood;
        currency += deltaCurrency;
    }
}
