using DigitalRuby.WeatherMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightSettings : MonoBehaviour
{
    public static float InitialTimeOfDay; 
    public static DateTime InitialDateTime; 

    private void Start()
    {
        var dayNight = FindObjectOfType<WeatherMakerDayNightCycleManagerScript>();
        InitialTimeOfDay = dayNight.TimeOfDay;
        InitialDateTime = dayNight.DateTime;
    }
}
