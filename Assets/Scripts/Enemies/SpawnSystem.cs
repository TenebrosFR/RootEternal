using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnSystem : MonoBehaviour
{

    public GameObject enemy1;
    public GameObject enemy2;
    
    public int enemy1Count;
    public int enemy1Number;
    
    public int enemy2Count;
    public int enemy2Number;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemy1Count < enemy1Number)
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
                    Instantiate(enemy1, objectPosition, Quaternion.identity);
                    yield return new WaitForSeconds(0.1f);
                    enemy1Count += 1;
                    objectSpawned = true;
                }

            }
        }
        while (enemy2Count < enemy2Number)
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
                    Instantiate(enemy2, objectPosition, Quaternion.identity);
                    yield return new WaitForSeconds(0.1f);
                    enemy2Count += 1;
                    objectSpawned = true;
                }

            }
        }
    }

}
