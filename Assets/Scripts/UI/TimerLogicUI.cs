using System.Collections.Generic;
using UnityEngine;

public class TimerLogicUI : MonoBehaviour
{
    [SerializeField] private List<BaseTimerUI> _prefabsToSpawn;

    [SerializeField] private Transform _timerContainer;

    private Timer _timer;

    public void Initialize(Timer timer)
    {
        _timer = timer;
        _timer.OnTimerStart += StartUI;
    }

    private void OnDestroy()
    {
        _timer.OnTimerStart -= StartUI;
    }

    private void StartUI(float duration)
    {
        foreach (BaseTimerUI prefab in _prefabsToSpawn)
        {
            BaseTimerUI newUI = Instantiate(prefab, _timerContainer);
            newUI.Initialize(_timer, duration);
        }
    }
}
