using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnSystem : MonoBehaviour
{

    public GameObject simpleRoot;
    public GameObject bigRoot;
    public GameObject rangeRoot;
    public GameObject fastRoot;
    [Header("Wave 1:")] 
    public int enemy1Count;
    public int enemy1Number;
    [Header("Wave 2:")]
    public int enemy2Count;
    public int enemy2Number;
    public int enemyBig2Count;
    public int enemyBig2Number;
    [Header("Wave 3:")]
    public int enemy3Count;
    public int enemy3Number;
    public int enemyRange3Count;
    public int enemyRange3Number;
    public int enemyBig3Count;
    public int enemyBig3Number;
    [Header("Wave 4:")]
    public int enemy4Count;
    public int enemy4Number;
    public int enemyFast4Count;
    public int enemyFast4Number;
    public int enemyBig4Count;
    public int enemyBig4Number;
    [Header("Wave 5:")]
    public int enemy5Count;
    public int enemy5Number;
    public int enemyRange5Count;
    public int enemyRange5Number;
    public int enemyFast5Count;
    public int enemyFast5Number;
    public int enemyBig5Count;
    public int enemyBig5Number;
    [Header("Next Wave:")]
    public int enemyNCount;
    public int enemyNNumber;
    public int enemyRangeNCount;
    public int enemyRangeNNumber;
    public int enemyFastNCount;
    public int enemyFastNNumber;
    public int enemyBigNCount;
    public int enemyBigNNumber;


    [Header("Total d'enemies tués:")]
    public int totalEnemyKilled;
    public int totalEnemy1Killed;
    public int totalEnemy2Killed;
    public int totalEnemy3Killed;
    public int totalEnemy4Killed;
    
    [Header("Stats:")]
    private int enemyNumber;
    public int waveNumber = 5;
    
    private Boolean _waveOne = true;
    private Boolean _waveTwo = false;
    private Boolean _waveThree = false;
    private Boolean _waveFour = false;
    private Boolean _waveFive = false;
    private Boolean _nextWave = false;

    private List<GameObject> tinyRootL = new List<GameObject>();
    private List<GameObject> bigRootL = new List<GameObject>();
    private List<GameObject> fastRootL = new List<GameObject>();
    private List<GameObject> rangeRootL = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    private void Update() {
        
        
        for(var i =0;i<tinyRootL.Count;i++)
        {
            if (!tinyRootL[i])
            {
                tinyRootL.Remove(tinyRootL[i]);
                totalEnemy1Killed += 1;
            }
            
        }
        for(var i =0;i<bigRootL.Count;i++)
        {
            if (!bigRootL[i])
            {
                bigRootL.Remove(bigRootL[i]);
                totalEnemy2Killed += 1;
            }
            
        }
        for(var i =0;i<fastRootL.Count;i++)
        {
            if (!fastRootL[i])
            {
                fastRootL.Remove(fastRootL[i]);
                totalEnemy3Killed += 1;
            }
            
        }
        for(var i =0;i<rangeRootL.Count;i++)
        {
            if (!rangeRootL[i])
            {
                rangeRootL.Remove(rangeRootL[i]);
                totalEnemy4Killed += 1;
            }
            
        }

        totalEnemyKilled = totalEnemy1Killed + totalEnemy2Killed + totalEnemy3Killed + totalEnemy4Killed;
        
        /* ---   SYSTEM WAVES ----*/
        
        if (_waveOne)
        {
            if (totalEnemyKilled == 5)
            {
                _waveOne = false;
                Debug.Log("Start Wave 2");
                _waveTwo = true;
                StartCoroutine(EnemyDrop());
            }
        }
        if (_waveTwo)
        {

            if (totalEnemyKilled > 20 && totalEnemy2Killed == 5)
            {
                _waveTwo = false;
                Debug.Log("Start Wave 3");
                _waveThree = true;
                StartCoroutine(EnemyDrop());
            }
        }
        if (_waveThree)
        {

            if (totalEnemyKilled > 40 && totalEnemy3Killed == 5)
            {
                _waveThree = false;
                Debug.Log("Start Wave 4");
                _waveFour = true;
                StartCoroutine(EnemyDrop());
            }
        }
        if (_waveFour)
        {

            if (totalEnemyKilled > 47 && totalEnemy4Killed == 5)
            {
                _waveFour = false;
                Debug.Log("Start Wave 5");
                _waveFive = true;
                StartCoroutine(EnemyDrop());
            }
        }
        if (_waveFive)
        {
            if (totalEnemyKilled > 77)
            {
                _waveFive = false;
                Debug.Log("Start Wave 5");
                _nextWave = true;
                enemyNumber = totalEnemyKilled;
                StartCoroutine(EnemyDrop());
            }
        }
        if (_nextWave)
        {
            waveNumber += 1;
            if (totalEnemyKilled > enemyNumber - 5)
            {
                Debug.Log("Start Wave " + waveNumber);
                
                enemyNumber = totalEnemyKilled;
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
                
            while (enemy1Count < enemy1Number)
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
                        tinyRootL.Add(Instantiate(simpleRoot, objectPosition, Quaternion.identity));
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
            while (enemy2Count < enemy2Number)
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
                        tinyRootL.Add(Instantiate(simpleRoot, objectPosition, Quaternion.identity));
                        yield return new WaitForSeconds(0.1f);
                        enemy2Count += 1;
                        objectSpawned = true;
                    }

                }
            }

            while (enemyBig2Count < enemyBig2Number)
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
                        bigRootL.Add(Instantiate(bigRoot, objectPosition, Quaternion.identity));
                        yield return new WaitForSeconds(0.1f);
                        enemyBig2Count += 1;
                        objectSpawned = true;
                    }

                }
            }
        }
            
        /*  ----------------   WAVE THREE  -------------------*/
            
            
        if (_waveThree)
        {
            while (enemy3Count < enemy3Number)
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
                        tinyRootL.Add(Instantiate(simpleRoot, objectPosition, Quaternion.identity));
                        yield return new WaitForSeconds(0.1f);
                        enemy3Count += 1;
                        objectSpawned = true;
                    }

                }
            }

            while (enemyRange3Count < enemyRange3Number)
            {
                bool objectSpawned = false;
                while (!objectSpawned)
                {

                    Vector3 objectPosition = new Vector3(transform.position.x + Random.Range(-50, 50), 0,
                        transform.position.z + Random.Range(-50, 50));

                    if ((objectPosition - transform.position).magnitude < 40 ||
                        Physics.CheckSphere(objectPosition, 0))
                    {
                        continue;
                    }
                    else
                    {
                        rangeRootL.Add(Instantiate(rangeRoot, objectPosition, Quaternion.identity));
                        yield return new WaitForSeconds(0.1f);
                        enemyRange3Count += 1;
                        objectSpawned = true;
                    }

                }
            }

            while (enemyBig3Count < enemyBig3Number)
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
                        bigRootL.Add(Instantiate(bigRoot, objectPosition, Quaternion.identity));
                        yield return new WaitForSeconds(0.1f);
                        enemyRange3Count += 1;
                        objectSpawned = true;
                    }

                }
            }
        }
            
        /*  ----------------   WAVE FOUR  -------------------*/
            
        if (_waveFour)
        {
            while (enemy4Count < enemy4Number)
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
                        tinyRootL.Add(Instantiate(simpleRoot, objectPosition, Quaternion.identity));
                        yield return new WaitForSeconds(0.1f);
                        enemy3Count += 1;
                        objectSpawned = true;
                    }

                }
            }

            while (enemyFast4Count < enemyFast4Number)
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
                        fastRootL.Add(Instantiate(fastRoot, objectPosition, Quaternion.identity));
                        yield return new WaitForSeconds(0.1f);
                        enemyRange3Count += 1;
                        objectSpawned = true;
                    }

                }
            }
            while (enemyBig4Count < enemyBig4Number)
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
                        bigRootL.Add(Instantiate(bigRoot, objectPosition, Quaternion.identity));
                        yield return new WaitForSeconds(0.1f);
                        enemyRange3Count += 1;
                        objectSpawned = true;
                    }

                }
            }
        }
            
        /*  ----------------   WAVE FIVE  -------------------*/
            
        if (_waveFive)
        {
            while (enemy5Count < enemy5Number)
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
                        tinyRootL.Add(Instantiate(simpleRoot, objectPosition, Quaternion.identity));
                        yield return new WaitForSeconds(0.1f);
                        enemy3Count += 1;
                        objectSpawned = true;
                    }

                }
            }

            while (enemyRange5Count < enemyRange5Number)
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
                        rangeRootL.Add(Instantiate(rangeRoot, objectPosition, Quaternion.identity));
                        yield return new WaitForSeconds(0.1f);
                        enemyRange3Count += 1;
                        objectSpawned = true;
                    }

                }
            }
            while (enemyBig5Count < enemyBig5Number)
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
                        bigRootL.Add(Instantiate(bigRoot, objectPosition, Quaternion.identity));
                        yield return new WaitForSeconds(0.1f);
                        enemyRange3Count += 1;
                        objectSpawned = true;
                    }

                }
            }
                
            while (enemyFast5Count < enemyFast5Number)
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
                        fastRootL.Add(Instantiate(fastRoot, objectPosition, Quaternion.identity));
                        yield return new WaitForSeconds(0.1f);
                        enemyRange3Count += 1;
                        objectSpawned = true;
                    }

                }
            }
        }
        
         /*  ----------------   WAVE N  -------------------*/
            
        if (_nextWave)
        {
            enemyNNumber = Random.Range(10, 15);
            enemyBigNNumber = Random.Range(10, 25);

            if (enemyBigNNumber < 15)
            {
                enemyRangeNNumber = Random.Range(15, 25);
            } else {
                enemyRangeNNumber = Random.Range(10, 15);
            }
            
            if (enemyRangeNNumber < 15)
            {
                enemyFastNNumber = Random.Range(15, 25);
            } else {
                enemyFastNNumber = Random.Range(10, 15);
            }

            while (enemyNCount < enemyNNumber)
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
                        tinyRootL.Add(Instantiate(simpleRoot, objectPosition, Quaternion.identity));
                        yield return new WaitForSeconds(0.1f);
                        enemyNCount += 1;
                        objectSpawned = true;
                    }

                }
            }

            while (enemyRangeNCount < enemyRangeNNumber)
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
                        rangeRootL.Add(Instantiate(rangeRoot, objectPosition, Quaternion.identity));
                        yield return new WaitForSeconds(0.1f);
                        enemyRangeNCount += 1;
                        objectSpawned = true;
                    }

                }
            }
            while (enemyBigNCount < enemyBigNNumber)
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
                        bigRootL.Add(Instantiate(bigRoot, objectPosition, Quaternion.identity));
                        yield return new WaitForSeconds(0.1f);
                        enemyRangeNCount += 1;
                        objectSpawned = true;
                    }

                }
            }
                
            while (enemyFastNCount < enemyFastNNumber)
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
                        fastRootL.Add(Instantiate(fastRoot, objectPosition, Quaternion.identity));
                        yield return new WaitForSeconds(0.1f);
                        enemyRangeNCount += 1;
                        objectSpawned = true;
                    }

                }
            }
        }
    }

}
