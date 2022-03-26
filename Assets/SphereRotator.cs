using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereRotator : MonoBehaviour
{
    public float Tilt;

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(1, new Vector3(1,1,0));


    }
}
