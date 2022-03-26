using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public GameObject StartButton;
    public GameObject menu;
    public GameObject DeathScreen;
    private bool isStarted = false;
    
    // Start is called before the first frame update
    public bool isStartedAlready()
        {
            return isStarted;
        }
    public void Dead()
    {
        DeathScreen.SetActive(true);
    }
    void Start()
    {
        StartButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
        {
            menu.SetActive(false);//невидимость - галочка
            isStarted = true;
        }
        );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
