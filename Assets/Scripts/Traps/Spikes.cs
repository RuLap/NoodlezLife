using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private float kickPower = 50.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.UpdateHealth(-12.5f);
            StartCoroutine(player.Immortal());
        }
    }
}
