using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesActivator : MonoBehaviour
{
    public GameObject[] spikes;
    private void Start()
    {
        StartCoroutine(ActivateUpDownSpikes());
    }
    private void Update()
    {
        
    }

    IEnumerator ActivateUpDownSpikes()
    {
        foreach (var spike in spikes)
        {
            yield return new WaitForSecondsRealtime(1);
        }
    }
}
