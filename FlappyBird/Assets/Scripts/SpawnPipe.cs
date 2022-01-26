using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPipe : MonoBehaviour
{
    public GameObject pipe;
    private Vector2 spawnPos;
    private void Start()
    {
        StartCoroutine(Spawner());
    }
    IEnumerator Spawner()
    {
        
        float randomSpawnPos = Random.Range(-1f, 3.5f);
        spawnPos = new Vector2(transform.position.x, randomSpawnPos);
        Instantiate(pipe, spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(2);
        StartCoroutine(Spawner());
    }
}
