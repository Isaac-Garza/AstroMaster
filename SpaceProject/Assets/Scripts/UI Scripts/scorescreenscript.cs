using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scorescreenscript : MonoBehaviour
{

    public string scorescene;
    public Transform player;
    public Transform playerVal;
    public GameObject scorescreen;
    public bool OnScore;


    // Start is called before the first frame update
    void Update()
    {
        if (OnScore)
        {
            NextRound();
        }
    }  
    // Update is called once per frame
    public void GoToShop()
    {
        OnScore = false;
       
    }
    public void OpenScoreScreen ()
    {
  
            scorescreen.SetActive(true);
            Debug.Log("NexRound!");
            Time.timeScale = 0f;

    }
    public void NextRound()
    {
        OnScore = false;
        scorescreen.SetActive(false);
        Time.timeScale = 1f;
    }
}