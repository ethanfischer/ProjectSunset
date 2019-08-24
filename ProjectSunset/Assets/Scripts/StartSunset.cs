using DigitalRuby.WeatherMaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSunset : MonoBehaviour
{
    public float SunsetSpeed = 400;
    private WeatherMakerDayNightCycleManagerScript _dayNightCycle;
    void Start()
    {
        _dayNightCycle = GameObject.FindObjectOfType<WeatherMakerDayNightCycleManagerScript>();
        _dayNightCycle.Speed = SunsetSpeed;
    }
}
