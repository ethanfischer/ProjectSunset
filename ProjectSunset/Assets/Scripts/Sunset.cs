using UnityEngine;
using UnityEngine.SceneManagement;

public class Sunset : MonoBehaviour
{
    [Tooltip("The amount of time in seconds it takes for the sun to set")]
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
            SceneManager.LoadScene(SceneNames.GAME_OVER);
        }
    }
}
