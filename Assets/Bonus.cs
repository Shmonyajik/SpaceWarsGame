using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public float RotationSpeed;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody Bonus = GetComponent<Rigidbody>();


        Bonus.velocity = Vector3.back*Speed;
        Bonus.angularVelocity = Random.insideUnitSphere * RotationSpeed;//angularVelocity - вращение рандомное по 3 координатам
    }


    
}
