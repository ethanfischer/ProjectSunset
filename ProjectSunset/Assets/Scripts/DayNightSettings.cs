using DigitalRuby.WeatherMaker;
using UnityEngine;

public class DayNightSettings : MonoBehaviour
{
    public static float InitialTimeOfDay; 

    private void Start()
    {
        var dayNight = FindObjectOfType<WeatherMakerDayNightCycleManagerScript>();
        InitialTimeOfDay = dayNight.TimeOfDay;
    }
}
