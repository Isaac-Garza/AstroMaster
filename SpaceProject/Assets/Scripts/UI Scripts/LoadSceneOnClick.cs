using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LoadSceneOnClick : MonoBehaviour {

    public GameObject scorescreen;

  
   public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1f;
        scorescreen.SetActive(false);
    }
}
