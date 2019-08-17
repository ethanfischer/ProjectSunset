using DigitalRuby.WeatherMaker;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ResetScenes();
            ResetPlayer();
            ResetDayNightCycle();
            ResetGameOverTimer();
        }
    }

    private static void ResetScenes()
    {
        SceneManager.UnloadSceneAsync(SceneNames.GAME_OVER);
        SceneManager.UnloadSceneAsync(SceneNames.TEST_LEVEL);
        SceneManager.LoadSceneAsync(SceneNames.TEST_LEVEL, LoadSceneMode.Additive);
    }

    private static void ResetPlayer()
    {
        Player.Instance.Unfreeze();
        PlayerSpawn.Instance.Spawn();
    }

    private static void ResetDayNightCycle()
    {
        var dayNight = FindObjectOfType<WeatherMakerDayNightCycleManagerScript>();
        dayNight.TimeOfDay = DayNightSettings.InitialTimeOfDay;
    }

    private static void ResetGameOverTimer()
    {
        var gameOverTimer = FindObjectOfType<GameOverTimer>();
        gameOverTimer.Reset();
    }
}
