using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene(SceneNames.TEST_LEVEL, LoadSceneMode.Additive);
        SceneManager.LoadScene(SceneNames.MUSIC_AND_SFX, LoadSceneMode.Additive);
    }
}
