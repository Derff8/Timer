using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderUI : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private TimerExample _myTimer;

    public void Initialize(TimerExample timer, float maxTime)
    {
        _myTimer = timer;

        _slider.maxValue = maxTime;
        _slider.value = maxTime;

        _myTimer.OnTimerChanged += UpdateSliderValue;
        _myTimer.OnTimerEnd += DestrotSlider;
    }

    private void DestrotSlider()
    {
        _myTimer.OnTimerChanged -= UpdateSliderValue;
        _myTimer.OnTimerEnd -= DestrotSlider;
        GameObject.Destroy(gameObject);
    }

    private void UpdateSliderValue(float currentTime)
    {
        _slider.value = currentTime;
    }
}
