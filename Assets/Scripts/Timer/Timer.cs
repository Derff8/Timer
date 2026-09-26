using System;
using System.Collections;
using UnityEngine;

public class Timer
{
    public event Action<float> OnTimerStart;
    public event Action<float> OnTimerChanged;
    public event Action OnTimerEnd;

    private float _timeLeft = 0;
    private bool _isRunning = false;
    public bool InProcess => _timeLeft > 0;

    private MonoBehaviour _coroutineRunner;
    private Coroutine _timerCoroutine;

    public Timer(MonoBehaviour runner)
    {
        _coroutineRunner = runner;
    }

    public void StartTimer(float duration)
    {
        _timeLeft = duration;
        _isRunning = true;

        OnTimerStart?.Invoke(_timeLeft);

        if (_timerCoroutine != null)
            _coroutineRunner.StopCoroutine(_timerCoroutine);

        _timerCoroutine = _coroutineRunner.StartCoroutine(TimerRoutine());
    }

    private IEnumerator TimerRoutine()
    {
        while (_timeLeft > 0)
        {
            if (_isRunning)
            {
                _timeLeft -= Time.deltaTime;

                if (_timeLeft <= 0)
                {
                    _timeLeft = 0;
                    _isRunning = false;
                    OnTimerChanged?.Invoke(_timeLeft);
                    OnTimerEnd?.Invoke();
                    yield break;
                }

                OnTimerChanged?.Invoke(_timeLeft);
            }
            yield return null;
        }
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
        if (_timerCoroutine != null)
            _coroutineRunner.StopCoroutine(_timerCoroutine);
        OnTimerEnd?.Invoke();
    }
}
