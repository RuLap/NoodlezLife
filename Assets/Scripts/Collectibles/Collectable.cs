﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    protected float weight;
    protected CollectableType type;
    public float GetAward() 
    {
        return weight;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var obj = collision.gameObject;
        if (obj.TryGetComponent<Player>(out Player player))
        {
            player.UpdateHealth(weight);
        }
    }
}
