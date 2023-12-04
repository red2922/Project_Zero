using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttributes : MonoBehaviour
{
    public StatsManager sm;

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<StatsManager>().takeDamage(sm.attackStat);
            DestroyAtZero(other);
        }
    }


    private void DestroyAtZero(Collider other)
    {
        if (other.GetComponent<StatsManager>().healthStat <= 0)
        {
            Destroy(other.gameObject);
        }
    }



}



