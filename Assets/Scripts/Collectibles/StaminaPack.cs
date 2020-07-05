using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaPack : Collectable
{
    // Start is called before the first frame update
    void Start()
    {
        weight = 10;
        type = CollectableType.Stamina;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var obj = collision.gameObject;
        if (obj.TryGetComponent<Player>(out Player player))
        {
            player.UpdateStamina(weight);
            Destroy(gameObject);
        }
    }
}
