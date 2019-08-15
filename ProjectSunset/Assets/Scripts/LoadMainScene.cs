using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainScene : MonoBehaviour
{
    void Start()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName(SceneNames.MAIN))
        {
            SceneManager.LoadScene(SceneNames.MAIN);
        }
    }
}
