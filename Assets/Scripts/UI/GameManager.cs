using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void PlayGame()
    {
         int randomSceneIndex = Random.Range(1, 4);
      
        switch (randomSceneIndex)
        {
            case 1:
                SceneManager.LoadScene(1);
                break;
            case 2:
                SceneManager.LoadScene(2);
                break;
            case 3:
                SceneManager.LoadScene(3);
                break;
            default:
                Debug.LogError("Invalid scene index.");
                break;
        }
    }
  
    public void QuitGame()
    {
        Application.Quit();
    }



}    

