using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBehaviour : MonoBehaviour
{
    [SerializeField]
    private List<SpawnerBehaviour> spawners;
    [SerializeField]
    private int _waveCount;
    [SerializeField]
    private int _currentWave;
    [SerializeField]
    private float _waveDelay;
    public static int enemyCount;
    public bool startingWave;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartWave());
    }

    public IEnumerator StartWave()
    {
        startingWave = true;
        yield return new WaitForSeconds(_waveDelay);
        foreach(SpawnerBehaviour spawner in spawners)
        {
            spawner.StartCoroutine(spawner.SpawnEnemies());
        }
        _currentWave++;
        startingWave = false;
    }

    public bool CheckWaveSpawned()
    {
        //Check if any of the spawners are still spawning enemies
        foreach(SpawnerBehaviour spawner in spawners)
        {
            if (spawner.isSpawning == true)
                return false;
        }
        //If no spawner is spawning enemies then return false
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(enemyCount);
        //If no enemies are alive and the wave has been spawned then spawn a new wave
        if (enemyCount == 0 && CheckWaveSpawned() && _currentWave < _waveCount && startingWave == false)
        {
            StartCoroutine(StartWave());
        }
    }
}
