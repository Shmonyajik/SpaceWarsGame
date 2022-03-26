using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{

    public GameObject Asteroid;
    public GameObject Asteroid1;
    public GameObject Asteroid2;
    public GameScript GameScript;
    public float minAsteroidCoolDown;
    public float maxAsteroidCoolDown;
    private float nextAsteroid = 0;
    // Update is called once per frame
    void Start()
    {
        GameScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameScript>();
    }
    void Update()
    {
        if(!GameScript.isStartedAlready())
        {
            return;
        }
        if (Time.time > nextAsteroid)
        {
            float yPosition = transform.position.y;
            float zPosition = transform.position.z;
            float xPosition = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
            Vector3 randomPosition = new Vector3(xPosition, yPosition, zPosition);
            nextAsteroid = Time.time + Random.Range(minAsteroidCoolDown, maxAsteroidCoolDown);
            switch (Random.Range(1, 4))
            {
                case 1:
                    Instantiate(Asteroid, randomPosition, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(Asteroid1, randomPosition, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(Asteroid2, randomPosition, Quaternion.identity);
                    break;

            }
        }
    }
}
