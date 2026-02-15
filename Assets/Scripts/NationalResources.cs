using System;
using UnityEngine;

public class NationalResources : MonoBehaviour
{
    //The amounts of Oil, Land, and Capital this nation possesses
    [SerializeField]
    private float oil, land, currency;

    public float Oil
    {
        get
        {
            return oil;
        }
    }

    public float Land
    {
        get
        {
            return land;
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
    /// <param name="deltaLand">Change in this nation's Land</param>
    /// <param name="deltaCurrency">Change in this nation's Capital</param>
    public void UpdateResources(float deltaOil, float deltaLand, float deltaCurrency)
    {
        //Add the change to all the resources.
        oil += deltaOil;
        land += deltaLand;
        currency += deltaCurrency;

        //Round all the resources to the second decimal place.
        oil = (float)Math.Round((double)oil, 2, MidpointRounding.AwayFromZero);
        land = (float)Math.Round((double)land, 2, MidpointRounding.AwayFromZero);
        currency = (float)Math.Round((double)currency, 2, MidpointRounding.AwayFromZero);
    }
}
