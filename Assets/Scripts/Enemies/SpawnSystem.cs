using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;
    [Serializable]
    public class MonsterNumber {
        public int[] numbers;
    }
    [SerializeField] MonsterNumber[] waveMonsters;
    int[] infinite = { 0, 0, 0, 0, 0 };
    [SerializeField] List<GameObject> monsters = new List<GameObject>();
    [SerializeField] float SpawnDistance = 50f;
    int[] infNum = { 0, 0, 0, 0 };
    public int killCount;
    int waveIndex = 0;
    public void Start() {
        LaunchWave(waveIndex);
    }

    public void Update() {
        for(var i = 0;i<monsters.Count;i++) {
            if (!monsters[i]) {
                monsters.Remove(monsters[i]);
                killCount++;
            }
        }
        if(monsters.Count == 0) {
            LaunchWave(waveIndex++);
        }
    }
    public void LaunchWave(int current) {
        int[] currentWave;
        if (current < waveMonsters.Length) currentWave = infNum;
        else currentWave = waveMonsters[current].numbers;
        for (var monsterIndex = 0; monsterIndex < currentWave.Length; monsterIndex++) {
            for (var newMonster = 0; newMonster < currentWave[monsterIndex]; newMonster++) {
                Vector3 newPosition;
                do {
                    newPosition = new Vector3(Random.Range(-SpawnDistance, SpawnDistance), 0, Random.Range(-SpawnDistance, SpawnDistance));
                } while (!Physics.CheckSphere(newPosition, 3));
                monsters.Add(Instantiate(prefabs[monsterIndex],newPosition,Quaternion.identity));
            }
        }
    }
}