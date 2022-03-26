using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScript : MonoBehaviour
{
    private void OnTriggerExit(Collider other)// когда любой коллайдер(other) касается жанного коллайдера 
    {
        Destroy(other.gameObject);
    }

}