using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public GameObject Bang;
    public GameObject PlayerBang;
    private GameObject ScoreText;
    public float EnemyTilt;
    public float minSpeed;
    public float maxSpeed;
    public float minshotCoolDown;
    public float maxshotCoolDown;
    public GameObject Shot;
    private float nextShot;
    public Transform Gunposition, Gunposition1;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody Enemy = GetComponent<Rigidbody>();
        ScoreText = GameObject.FindGameObjectWithTag("ScoreText");
        if (transform.position.x < 0)
        {
            Enemy.velocity = new Vector3((float)0.3,0,-1) * Random.Range(minSpeed, maxSpeed);
            
        }
        else
        {
            Enemy.velocity = new Vector3((float)-0.3, 0, -1) * Random.Range(minSpeed, maxSpeed);
            
        }
    }
    public void UpdateScore()
    {
        ScoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + asteroidFly.score;
        return;
    }
    void Update()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        if (Player == null)
        {
           
            return;
        }
        else
        {
            transform.LookAt(Player.transform.position);
        }
        if (Time.time > nextShot && transform.position.z<=50)
       {
           nextShot = Time.time + Random.Range(minshotCoolDown, maxshotCoolDown);
           Instantiate(Shot, Gunposition.transform.position, transform.rotation);
           Instantiate(Shot, Gunposition1.transform.position, transform.rotation);
        }
       

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Shot" || other.gameObject.tag == "GameBoundary" || other.gameObject.tag == "Bonus")
        {
            return;
        }
        if (other.gameObject.tag == "shot")
        {
            asteroidFly.score += 25;
            UpdateScore();
        }
          Instantiate(PlayerBang, transform.position, Quaternion.identity);
          Destroy(gameObject);
        
        


    }
}
