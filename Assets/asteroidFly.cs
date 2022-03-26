using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class asteroidFly : MonoBehaviour
{
    public static int score = 0;
    private GameObject ScoreText;
    public float minSpeed;
    public float maxSpeed;

    public float RotationSpeed;
    public float asteroidCoolDown;
    private float nextAsteroid;
   
    public GameObject Bang;
    public GameObject PlayerBang;
    //// Start is called before the first frame update
    void Start()
    {
        ScoreText = GameObject.FindGameObjectWithTag("ScoreText");
        Rigidbody Asteroid = GetComponent<Rigidbody>();
    
        
        Asteroid.velocity = Vector3.back * Random.Range(minSpeed, maxSpeed);
        Asteroid.angularVelocity = Random.insideUnitSphere * RotationSpeed;//angularVelocity - вращение рандомное по 3 координатам

    }
    
    public void UpdateScore()
    {
        ScoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + score;
        return;
    }


// Update is called once per frame


private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GameBoundary" || other.gameObject.tag == "Bonus")
        {
            return;
        }
        if (other.gameObject.tag == "shot")
        {
            score += 10;
            UpdateScore();

        }
        Instantiate(Bang, transform.position, Quaternion.identity);
        Destroy(gameObject);
        
        
    }
}