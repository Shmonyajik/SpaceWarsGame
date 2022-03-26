using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BangDispersion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody Bang = GetComponent<Rigidbody>();

        Bang.velocity = Vector3.back*10;
    }

    
}
