using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateNoodle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject NoodleContainer;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        NoodleContainer.transform.Rotate(Vector3.up, 2f);

    }
}
