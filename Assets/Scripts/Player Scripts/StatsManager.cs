using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public int fullHealth;
    public int healthStat;
    public int attackStat;

    public void takeDamage(int amount)
    {
        healthStat -= amount;

    }

    public void dealDamage(GameObject target)
    {
        var atm = target.GetComponent<StatsManager>();
        if(atm != null)
        {
            atm.takeDamage(attackStat);
        }

    }





}
