using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerExample : MonoBehaviour
{
    public event Action<float> OnTimerStart;
    public event Action<float> OnTimerChanged;
    public event Action OnTimerEnd;

    private float _timeLeft = 0;
    private bool _isRunning = false;
    public bool InProcess => _timeLeft > 0;

    private void Update()
    {
        if (!_isRunning) return;

        _timeLeft -= Time.deltaTime;

        if (_timeLeft <= 0)
        {
            _timeLeft = 0;
            _isRunning = false;
            OnTimerEnd?.Invoke();
        }

        OnTimerChanged?.Invoke(_timeLeft);
    }

    public void StartTimer(float duration)
    {
        _timeLeft = duration;
        _isRunning = true;

        OnTimerStart?.Invoke(_timeLeft);
    }

    public void ContinueTimer()
    {
        _isRunning = true;
    }

    public void StopTimer()
    {
        _isRunning = false;
    }

    public void ResetTimer()
    {
        _isRunning = false;
        _timeLeft = 0;
        OnTimerEnd?.Invoke();
    }
}
