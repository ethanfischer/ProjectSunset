using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.UnloadSceneAsync(SceneNames.GAME_OVER);
            SceneManager.UnloadSceneAsync(SceneNames.TEST_LEVEL);
            SceneManager.LoadSceneAsync(SceneNames.TEST_LEVEL, LoadSceneMode.Additive);
            Player.Instance.Unfreeze();
            PlayerSpawn.Instance.Spawn();
        }
    }
}
