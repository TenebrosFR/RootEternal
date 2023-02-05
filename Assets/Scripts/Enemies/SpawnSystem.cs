using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnSystem : MonoBehaviour
{

    public GameObject enemy1;
    public GameObject enemy2;
    [Header("Wave 1")] 
    public int enemy1Count;
    public int _enemy1Number;
    [Header("Wave 2")]
    public int enemy2Count;
    public int _enemy2Number;
    public int enemyRange2Count;
    public int _enemyRange2Number;
    [Header("Wave 3")]
    public int enemy3Count;
    public int _enemy3Number;
    public int enemyRange3Count;
    public int _enemyRange3Number;
    
    [Header("Total d'enemies tués")]
    public int _totalEnemyKilled;
    public int _totalEnemy1Killed;
    public int _totalEnemy2Killed;
    
    private Boolean _waveOne = true;
    private Boolean _waveTwo = false;
    private Boolean _waveThree = false;
    private Boolean _waveFour = false;
    private Boolean _waveFive = false;

    private List<GameObject> enemies1 = new List<GameObject>();
    private List<GameObject> enemies2 = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    private void Update() {
        
        
        for(var i =0;i<enemies1.Count;i++)
        {
            if (!enemies1[i])
            {
                enemies1.Remove(enemies1[i]);
                _totalEnemy1Killed += 1;
            }
            
        }
        for(var i =0;i<enemies2.Count;i++)
        {
            if (!enemies2[i])
            {
                enemies2.Remove(enemies2[i]);
                _totalEnemy2Killed += 1;
            }
            
        }

        _totalEnemyKilled = _totalEnemy1Killed + _totalEnemy2Killed;
        
        
        if (_waveOne)
        {
            if (_totalEnemyKilled > _enemy1Number-5)
            {
                _waveOne = false;
                Debug.Log("Start Wave 2");
                _waveTwo = true;
                StartCoroutine(EnemyDrop());
            }
        }
        if (_waveTwo)
        {

            if (_totalEnemyKilled > _enemy2Number-5 && _totalEnemy2Killed == 5)
            {
                _waveTwo = false;
                Debug.Log("Start Wave 3");
                _waveThree = true;
                StartCoroutine(EnemyDrop());
            }
        }

    }
    
    IEnumerator EnemyDrop()
    {
        
        /*  ----------------   WAVE ONE  -------------------*/
        
        
        if (_waveOne)
            {
                Debug.Log("Start Wave 1");
                
                while (enemy1Count < _enemy1Number)
                {
                    bool objectSpawned = false;
                    while (!objectSpawned)
                    {

                        Vector3 objectPosition = new Vector3(transform.position.x + Random.Range(-50, 50), 0,
                            transform.position.z + Random.Range(-50, 50));

                        if ((objectPosition - transform.position).magnitude < 40 || Physics.CheckSphere(objectPosition, 0))
                        {
                            continue;
                        }
                        else
                        {
                            enemies1.Add(Instantiate(enemy1, objectPosition, Quaternion.identity));
                            yield return new WaitForSeconds(0.1f);
                            enemy1Count += 1;
                            objectSpawned = true;
                        }

                    }
                }
            }
/*  ----------------   WAVE TWO  -------------------*/
            if (_waveTwo)
            {
                while (enemy2Count < _enemy2Number)
                {
                    bool objectSpawned = false;
                    while (!objectSpawned)
                    {

                        Vector3 objectPosition = new Vector3(transform.position.x + Random.Range(-50, 50), 0,
                            transform.position.z + Random.Range(-50, 50));

                        if ((objectPosition - transform.position).magnitude < 40 || Physics.CheckSphere(objectPosition, 0))
                        {
                            continue;
                        }
                        else
                        {
                            enemies1.Add(Instantiate(enemy1, objectPosition, Quaternion.identity));
                            yield return new WaitForSeconds(0.1f);
                            enemy2Count += 1;
                            objectSpawned = true;
                        }

                    }
                }

                while (enemyRange2Count < _enemyRange2Number)
                {
                    bool objectSpawned = false;
                    while (!objectSpawned)
                    {

                        Vector3 objectPosition = new Vector3(transform.position.x + Random.Range(-50, 50), 0,
                            transform.position.z + Random.Range(-50, 50));

                        if ((objectPosition - transform.position).magnitude < 40 || Physics.CheckSphere(objectPosition, 0))
                        {
                            continue;
                        }
                        else
                        {
                            enemies2.Add(Instantiate(enemy2, objectPosition, Quaternion.identity));
                            yield return new WaitForSeconds(0.1f);
                            enemyRange2Count += 1;
                            objectSpawned = true;
                        }

                    }
                }
            }
            
            /*  ----------------   WAVE THREE  -------------------*/
            
            
            if (_waveThree)
            {
                while (enemy3Count < _enemy3Number)
                {
                    bool objectSpawned = false;
                    while (!objectSpawned)
                    {

                        Vector3 objectPosition = new Vector3(transform.position.x + Random.Range(-50, 50), 0,
                            transform.position.z + Random.Range(-50, 50));

                        if ((objectPosition - transform.position).magnitude < 40 || Physics.CheckSphere(objectPosition, 0))
                        {
                            continue;
                        }
                        else
                        {
                            enemies1.Add(Instantiate(enemy1, objectPosition, Quaternion.identity));
                            yield return new WaitForSeconds(0.1f);
                            enemy3Count += 1;
                            objectSpawned = true;
                        }

                    }
                }

                while (enemyRange3Count < _enemyRange3Number)
                {
                    bool objectSpawned = false;
                    while (!objectSpawned)
                    {

                        Vector3 objectPosition = new Vector3(transform.position.x + Random.Range(-50, 50), 0,
                            transform.position.z + Random.Range(-50, 50));

                        if ((objectPosition - transform.position).magnitude < 40 || Physics.CheckSphere(objectPosition, 0))
                        {
                            continue;
                        }
                        else
                        {
                            enemies2.Add(Instantiate(enemy2, objectPosition, Quaternion.identity));
                            yield return new WaitForSeconds(0.1f);
                            enemyRange3Count += 1;
                            objectSpawned = true;
                        }

                    }
                }
            }
    }

}
