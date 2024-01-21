using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    public string initialSceneName = "MainMenu";

    public void ResetToInitialScene()
    {
        SceneManager.LoadScene(initialSceneName);
    }
}
