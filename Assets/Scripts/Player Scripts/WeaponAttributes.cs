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
            Debug.Log("Hit");
            other.GetComponent<StatsManager>().takeDamage(sm.attackStat);

            DestroyOther(other);
           
        }
    }


    private void DestroyOther(Collider other)
    {
        if (other.GetComponent<StatsManager>().healthStat <= 0)
        {
            Debug.Log("I Should be dead");
            Destroy(other.GetComponent<GameObject>());
        }
    }



}



