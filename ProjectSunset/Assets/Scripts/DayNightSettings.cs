using DigitalRuby.WeatherMaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightSettings : MonoBehaviour
{
    public static float InitialTimeOfDay; 

    private void Awake()
    {
        var dayNight = FindObjectOfType<WeatherMakerDayNightCycleManagerScript>();
        InitialTimeOfDay = dayNight.TimeOfDay;
    }
}
