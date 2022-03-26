using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScroll : MonoBehaviour
{
    public float speed;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position; //получить позицию объекта 
    }

    // Update is called once per frame
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * speed, transform.localScale.y);//0,1,45,64,86,99,100,0,1,45..... localScale - это размер по у
        transform.position = startPosition + Vector3.back * newPosition; //теперь позиция становится равна стартовой + движение назад * количество 
    }
}