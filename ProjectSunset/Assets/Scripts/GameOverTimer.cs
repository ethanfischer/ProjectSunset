using DigitalRuby.WeatherMaker;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTimer : MonoBehaviour
{
    [Tooltip("The amount of time in seconds a gameover is triggered")]
    public float TimeLimit = 30;

    private float _elapsedTime = 0.0f;
    private bool _didTimeExpire = false;

    [HideInInspector] public bool expireTar = false;

    public void Reset()
    {
        _elapsedTime = 0;
        _didTimeExpire = false;
    }

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
            expireTar = true;
            GameOver();
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene(SceneNames.GAME_OVER, LoadSceneMode.Additive);
        Player.Instance.Freeze();
    }
}
