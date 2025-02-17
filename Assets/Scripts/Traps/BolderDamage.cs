﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolderDamage : MonoBehaviour
{
    private float damage = 25f;

    private void OnCollisionEnter(Collision collision)
    {
        var obj = collision.gameObject;
        if (obj.TryGetComponent<Player>(out Player player))
        {
            player.UpdateHealth(-damage);
        }
    }
}
