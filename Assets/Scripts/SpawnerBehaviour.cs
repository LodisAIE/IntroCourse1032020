using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject _spawnObject;
    [SerializeField]
    private float _spawnTimer;
    [SerializeField]
    private int _spawnCount;
    public bool isSpawning;

    // Start is called before the first frame update
    void Start()
    {

    }

    public IEnumerator SpawnEnemies()
    {
        //Loops so that enemies can be spawned repeatedly
        for (int i = 0; i < _spawnCount; i++)
        {
            isSpawning = true;
            //Spawns an enemy at spawner location
            Instantiate(_spawnObject, transform.position, transform.rotation);
            //Creates a delay before the next loop around
            yield return new WaitForSeconds(_spawnTimer);
        }
        isSpawning = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
