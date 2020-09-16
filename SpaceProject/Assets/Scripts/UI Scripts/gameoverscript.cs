using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameoverscript : MonoBehaviour
{
    
    public string gameOverScene;
    public Transform player;
    public GameObject GameoverScreen;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   void Update()
    {
        if (player ==null)
        {
           GameoverScreen.SetActive(true);
            Debug.Log("GAMEOVER");
            Time.timeScale = 0f;
        }
        
       

   }
}
