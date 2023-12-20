using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangerAI : BasicEnemyAI
{
    public Transform bulletSpawnPoint;
    public GameObject bulletSprite;
    public float bulletSpeed = 10;

    public override void AttackPlayer()
    {
        Debug.Log("AHHHHHH!!!");
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ///Attack
            var bullet = Instantiate(bulletSprite, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), attackCooldown);
        }
    }
}

