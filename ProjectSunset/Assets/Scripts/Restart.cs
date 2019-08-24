using DigitalRuby.WeatherMaker;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private GameOverTimer timer;

    private void Start()
    {
        //timer = GameObject.FindGameObjectWithTag("GameOverTimer").GetComponent<GameOverTimer>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            DoRestart();
        }
    }

    public static void DoRestart()
    {
        ResetScenes();
        ResetPlayer();
        ResetDayNightCycle();
        ResetGameOverTimer();
        //timer.expireTar = false;
    }

    private static void ResetScenes()
    {
        if (SceneManager.GetSceneByName(SceneNames.GAME_OVER) != null)
        {
            SceneManager.UnloadSceneAsync(SceneNames.GAME_OVER);
        }
            
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
