using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpikesTrigger : MonoBehaviour
{
    public GameObject[] spikes;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(FallSpikes());
    }

    IEnumerator FallSpikes()
    {
        foreach (var spike in spikes)
        {
            spike.transform.GetComponent<Rigidbody>().velocity = Vector3.up * (-10f);
            yield return new WaitForSecondsRealtime(0.5f);
        }
    }
}
