using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IDamagable
{
    protected float Health { get; set; }

    public void ApplyDamage(int damage)
    {
        if(Health - damage <= 0)
        {
            Health = 0;
            return;
        }
        Health -= damage;
    }

    public virtual void UpdateHealth(float value)
    {
        Health = value;
    }
}
