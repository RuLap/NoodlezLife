using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonDrop : MonoBehaviour
{
    private float damage = 12.5f;
    private void Start()
    {
        transform.rotation = new Quaternion(0, 0, 180, 0);
        GetComponent<Rigidbody>().velocity = new Vector3(0, -2f, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        var obj = collision.gameObject;
        if(obj.TryGetComponent<Player>(out Player player)){
            player.UpdateHealth(-damage);
        }
        Destroy(gameObject);
    }
}
