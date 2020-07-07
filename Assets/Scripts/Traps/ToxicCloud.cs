using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicCloud : MonoBehaviour
{
    // Start is called before the first frame update
    private bool playerInCloud=false;
    HealthSystem HP;
    void Start()
    {
        HP = GameObject.Find("HealthBar").GetComponent<HealthSystem>();
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            playerInCloud = true;
            StartCoroutine(doDamage(other.gameObject.GetComponent<Player>()));
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            playerInCloud = false;
        }
    }
    IEnumerator doDamage(Player player)
    {
        while (playerInCloud==true)
        {
            player.UpdateHealth(-5f);
            yield return new WaitForSecondsRealtime(1);
        }
    }
}
