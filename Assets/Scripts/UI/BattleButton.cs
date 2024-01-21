using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleButton : MonoBehaviour
{
    public void Battle()
    {
        SceneManager.LoadScene(4);
    }
    
}
