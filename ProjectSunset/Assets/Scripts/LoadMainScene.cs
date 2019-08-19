using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainScene : MonoBehaviour
{
    void Start()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName(SceneNames.MAIN))
        {
            print("loading scene");
            SceneManager.LoadScene(SceneNames.MAIN);
        }
    }
}
