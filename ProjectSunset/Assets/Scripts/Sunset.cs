using UnityEngine;
using UnityEngine.SceneManagement;

public class Sunset : MonoBehaviour
{
    private const float TIME_LIMIT = 3;
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

        if (_elapsedTime >= TIME_LIMIT)
        {
            Debug.Log("Timer expired");
            _didTimeExpire = true;
            SceneManager.LoadScene(SceneNames.GAME_OVER);
        }
    }
}
