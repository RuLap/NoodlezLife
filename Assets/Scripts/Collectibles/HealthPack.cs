using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : Collectable
{
    // Start is called before the first frame update
    void Start()
    {
        weight = 12.5f;
        type = CollectableType.Health;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var obj = collision.gameObject;
        if (obj.TryGetComponent<Character>(out Character player))
        {
            player.UpdateHealth(weight);
            Destroy(gameObject);
        }
    }
}
