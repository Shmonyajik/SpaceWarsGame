using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject Player;
    public GameObject Bang;
    public GameObject PlayerBang;
    public Texture Nani;
    public Texture Raindbow;
    public Renderer rend;
    public bool est;
    public bool estV;//щит актиывирован 

    public float Timer;//время до деактивации щита(сек)
    
    void Start()
    {
        
        rend.material.mainTexture = Nani;

    }
    void Update()
    {
          if (estV)//если аактивирован щит стартует корутина
            {
                StartCoroutine(flicker());
                 estV = false;
        }
            
    }
    IEnumerator flicker()
    {

        //float value = Timer;
        //for (; Timer > 0f; Timer -= 0.5f)
        //{
        //    //if (estV != true)
        //    //{
        //    //    return IEnumerator.Equals;
        //    //}
        //    yield return new WaitForSeconds(Timer);
        //    rend.material.mainTexture = Nani;
        //    yield return new WaitForSeconds(0.5f);
        //    rend.material.mainTexture = Raindbow;
        //}
        //estV = false;
        ////1 переменная для коллайдера и 1 для визуального 
        //rend.material.mainTexture = Nani;
        //Timer = value;
        //est = false;

        while(true)
        {
            if (estV != true)
            {   
                rend.material.mainTexture = null;
                yield break;
                
            }
            yield return new WaitForSeconds(Timer);
            rend.material.mainTexture = null;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "shot")
        {
           return;
        }
       
        if (other.gameObject.tag == "Bonus")
        {
            Destroy(other.gameObject);
            rend.material.mainTexture = Raindbow;
            est = true;
            estV = true;
            
            return;
        }
        if (est != true)
        {
            if (other.gameObject.tag == "Asteroid")
            {
                Instantiate(Bang, other.transform.position, Quaternion.identity);
                Instantiate(PlayerBang, transform.position, Quaternion.identity);
                Destroy(Player);
                Destroy(other.gameObject);
                
            }
            if (other.gameObject.tag == "Enemy")
            {
                Instantiate(PlayerBang, other.transform.position, Quaternion.identity);
                Instantiate(PlayerBang, transform.position, Quaternion.identity);
                Destroy(Player);
                Destroy(other.gameObject);
            }
            if (other.gameObject.tag == "Shot")
            {
                Instantiate(PlayerBang, transform.position, Quaternion.identity);
                Destroy(Player);
                Destroy(other.gameObject);
            }
        }
        else
        {
            if (other.gameObject.tag == "Asteroid")
            {
                Instantiate(Bang, other.transform.position, Quaternion.identity);
                Destroy(other.gameObject);
                est = false;
                estV = false;
                rend.material.mainTexture = Nani;
                
            }
            if (other.gameObject.tag == "Enemy")
            {
                Instantiate(PlayerBang, other.transform.position, Quaternion.identity);
                est = false;
                estV = false;
                rend.material.mainTexture = Nani;
                
            }
            if (other.gameObject.tag == "Shot")
            {
                Destroy(other.gameObject);
                est = false;
                estV = false;
                rend.material.mainTexture = Nani;
            }

            }

        //GameScript.Dead();

        }
     }

    


