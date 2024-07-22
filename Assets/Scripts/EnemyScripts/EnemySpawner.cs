using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{   
    [SerializeField]
    private GameObject enemyAsset;
    [SerializeField]
    private int maxNumEnemies = 5;

    private float interval = 4.5f;

    public Transform spawner;

    // Start is called before the first frame update
    private void Awake()
    {
        spawner = GameObject.Find("EnemySpawner").transform;
    }

    void Start()
    {
            StartCoroutine(spawnEnemy(interval, enemyAsset));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        int numberOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length + 1;
        yield return new WaitForSeconds(interval);
        Debug.Log(numberOfEnemies);

        if (numberOfEnemies < maxNumEnemies)
        {
            Instantiate(enemy, new Vector3(spawner.position.x, spawner.position.y, spawner.position.z), Quaternion.identity);
        }
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
