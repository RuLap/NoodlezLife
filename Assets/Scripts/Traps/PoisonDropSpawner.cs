using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonDropSpawner : MonoBehaviour
{
    public GameObject poisonDrop;

    void Start()
    {
        StartCoroutine(SpawnPoisonDrop());
    }

    private IEnumerator SpawnPoisonDrop()
    {
        while (true)
        {
            Instantiate(poisonDrop, transform.position, Quaternion.identity);
            yield return new WaitForSecondsRealtime(Random.Range(1, 3));
        }
    }
}
