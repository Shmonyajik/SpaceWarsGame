using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{

    public GameObject Bang;
    public GameObject PlayerBang;

    public float speed;//скорость корабля
    public float xMin, xMax, zMin, zMax;//ограниченя карты
    public float tilt;//величина наклона корабля при движении
    public GameObject Shot;
    public GameObject LeftShot;
    public GameObject BigShot;
    public GameScript GameScript;
    public Transform Gunposition, Gunposition1, Gunposition2;
    public float BigshotCoolDown;
    public float SmallshotCoolDown;
    private float nextShot;
    private float nextshot;
    // Start is called before the first frame update

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


        float moveHorizontal = Input.GetAxis("Horizontal");//направление 
        float moveVertical = Input.GetAxis("Vertical");
        bool fire = Input.GetButton("Fire1");//нажата ли кнопка
        bool fire1 = Input.GetButton("Fire2");
        Rigidbody Player = GetComponent<Rigidbody>();// получение компонента объекта player
        if (fire && Time.time > nextShot)
        {
            nextShot = Time.time + BigshotCoolDown;
            Instantiate(BigShot, Gunposition.position, Quaternion.identity);

        }
        if (fire1 && Time.time > nextshot)
        {
            nextshot = Time.time + SmallshotCoolDown;

            Instantiate(LeftShot, Gunposition2.position, Quaternion.identity);//создание объекта выстрела из первой пушки instantiate - создание объекта
            Instantiate(Shot, Gunposition1.position, Quaternion.identity);// из второй
        }

        // задать напровление вектором
        float newX = Mathf.Clamp(Player.position.x, xMin, xMax);//mathf -ограничение числа
        float newZ = Mathf.Clamp(Player.position.z, zMin, zMax);
        float newY = Player.position.y;
        Player.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;//скорость векторная
        Player.position = new Vector3(newX, newY, newZ);//ограничение позиции в 3 измерениях
        Player.rotation = Quaternion.Euler(Player.velocity.z * tilt, 0, Player.velocity.x * -1 * tilt);//наклон корабля



    }
}

    