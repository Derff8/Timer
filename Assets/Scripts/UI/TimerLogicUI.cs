using Microsoft.Unity.VisualStudio.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerLogicUI : MonoBehaviour
{
    [SerializeField] private TimerExample _timer;

    [SerializeField] private SliderUI _sliderPrefab;
    [SerializeField] private HeartsContainerUI _heartsContainerPrefab;
    [SerializeField] private InputUI _input;


    [SerializeField] private Transform _timerContainer;



    private void Start()
    {
        _timer.OnTimerStart += StartUI;
    }

    private void OnDestroy()
    {
        _timer.OnTimerStart -= StartUI;
    }

    private void StartUI(float duration)
    {
        SliderUI newSlider = Instantiate(_sliderPrefab, _timerContainer);
        newSlider.Initialize(_timer, duration);

        HeartsContainerUI newContainer = Instantiate(_heartsContainerPrefab, _timerContainer);
        newContainer.Initialize(_timer, duration);
    }
}
