using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnSystem : MonoBehaviour
{

    public GameObject enemy;
    public int enemyCount;
    public int enemyNumber;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < enemyNumber)
        {
            bool objectSpawned = false;
            while (!objectSpawned)
            {

                Vector3 objectPosition = new Vector3(transform.position.x + Random.Range(-50, 50), 0, transform.position.z + Random.Range(-50, 50));
                
                if ((objectPosition - transform.position).magnitude < 40 || Physics.CheckSphere(objectPosition, 0))
                {
                    continue;
                }
                else
                {
                    Instantiate(enemy, objectPosition, Quaternion.identity);
                    yield return new WaitForSeconds(0.1f);
                    enemyCount += 1;
                    objectSpawned = true;
                }

            }
        }
    }

}
