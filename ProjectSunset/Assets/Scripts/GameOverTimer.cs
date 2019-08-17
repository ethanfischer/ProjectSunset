using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTimer : MonoBehaviour
{
    [Tooltip("The amount of time in seconds it takes before a gameover is triggered")]
    public float TimeLimit = 30;

    private float _elapsedTime = 0.0f;
    private bool _didTimeExpire = false;

    private void Update()
    {
        if (_didTimeExpire)
        {
            return;
        }

        UpdateTimer();
    }

    private void UpdateTimer()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= TimeLimit)
        {
            Debug.Log("Timer expired");
            _didTimeExpire = true;
            PauseTimeAndLoadGameOverScene();
        }
    }

    private static void PauseTimeAndLoadGameOverScene()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene(SceneNames.GAME_OVER, LoadSceneMode.Additive);
    }
}
