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
        }
    }

}
