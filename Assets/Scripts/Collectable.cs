using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    protected int weight;

    public int GetAward() 
    {
        return weight;
    }
}
