using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Bonus;
    public GameScript GameScript;
    public float minEnemyCoolDown;
    public float maxEnemyCoolDown;
    private float nextEnemy = 0;
    private float nextBonus = 0;
    public float minBonusCoolDown;
    public float maxBonusCoolDown;

    void Start()
    {
        GameScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameScript>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!GameScript.isStartedAlready())
        {
           return;
        }
        if (Time.time > nextEnemy)
        {
            float yPosition = transform.position.y;
            float zPosition = transform.position.z;
            float xPosition = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
            Vector3 randomPositionB = new Vector3(xPosition, yPosition, zPosition);
            nextBonus = Time.time + Random.Range(minBonusCoolDown, maxBonusCoolDown);
            Instantiate(Bonus, randomPositionB, Quaternion.identity);
        }

            if (Time.time > nextEnemy)
        {
            float yPosition = transform.position.y;
            float zPosition = transform.position.z;
            float xPosition = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
            Vector3 randomPosition = new Vector3(xPosition, yPosition, zPosition);
            nextEnemy = Time.time + Random.Range(minEnemyCoolDown, maxEnemyCoolDown);
            switch (1)
            {
                case 1:
                    Instantiate(Enemy, randomPosition, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(Enemy1, randomPosition, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(Enemy2, randomPosition, Quaternion.identity);
                    break;
            }
        }
    }
}
