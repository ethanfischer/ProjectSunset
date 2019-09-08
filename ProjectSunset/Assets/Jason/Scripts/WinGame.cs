using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using DigitalRuby.WeatherMaker;

public class WinGame : MonoBehaviour
{

    public TextMeshProUGUI youWin;
    public TextMeshProUGUI playAgain;

    private void Start()
    {
        youWin.enabled = false;
        playAgain.enabled = false;
    }

    private void Update()
    {
        if (youWin.enabled == true && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.UnloadSceneAsync(SceneNames.TEST_LEVEL);
            SceneManager.LoadSceneAsync(SceneNames.TEST_LEVEL, LoadSceneMode.Additive);
            Player.Instance.Unfreeze();
            PlayerSpawn.Instance.Spawn();
            var dayNight = FindObjectOfType<WeatherMakerDayNightCycleManagerScript>();
            dayNight.TimeOfDay = DayNightSettings.InitialTimeOfDay;
            var gameOverTimer = FindObjectOfType<GameOverTimer>();
            gameOverTimer.Reset();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("You win!");
            youWin.enabled = true;
            playAgain.enabled = true;
            Player.Instance.Freeze();
            //Restart.DoRestart();
            var gameOverTimer = FindObjectOfType<GameOverTimer>();
            gameOverTimer.Stop();
        }
    }

}
