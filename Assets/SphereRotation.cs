using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereRotation : MonoBehaviour
{
    public float Tilt;

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(1, Vector3.forward);

        
    }

}
