using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{   
    [SerializeField]
    private GameObject melee;

    private float interval = 4.5f;

    public Transform spawner;

    // Start is called before the first frame update
    private void Awake()
    {
        spawner = GameObject.Find("EnemySpawner").transform;
    }


    void Start()
    {
        StartCoroutine(spawnEnemy(interval, melee));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy,new Vector3(spawner.position.x, spawner.position.y, spawner.position.z), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
