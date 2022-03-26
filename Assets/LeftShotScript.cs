using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftShotScript : MonoBehaviour
{
    public float ShotSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody shot = GetComponent<Rigidbody>();

        shot.velocity = new Vector3(ShotSpeed * -1, 0, ShotSpeed);
        shot.rotation = Quaternion.Euler(0, -45, 0);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Bonus" && other.gameObject.tag != "GameBoundary")
            Destroy(gameObject);
    }
}