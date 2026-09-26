using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerExample : MonoBehaviour
{
    [SerializeField] private TimerLogicUI _timerLogicUI;
    [SerializeField] private InputUI _inputUI;

    private Timer _timer;

    private void Awake()
    {
        _timer = new Timer(this);

        _timerLogicUI.Initialize(_timer);
        _inputUI.Initialize(_timer);
    }
}
