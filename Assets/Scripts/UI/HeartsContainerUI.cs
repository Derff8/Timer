using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsContainerUI : MonoBehaviour
{
    [SerializeField] private GameObject _heartImagePrefab;

    private TimerExample _myTimer;
    private List<GameObject> _hearts = new List<GameObject>();

    public void Initialize(TimerExample timer, float maxTime)
    {
        _myTimer = timer;

        SetCountHearts(maxTime);

        _myTimer.OnTimerChanged += UpdateCountHearts;
        _myTimer.OnTimerEnd += DestrotContainer;
    }

    private void DestrotContainer()
    {
        _myTimer.OnTimerChanged -= UpdateCountHearts;
        _myTimer.OnTimerEnd -= DestrotContainer;
        GameObject.Destroy(gameObject);
    }

    private void SetCountHearts(float maxTime)
    {
        for (int i = 0; i < Mathf.CeilToInt(maxTime); i++)
        {
            GameObject newHeart = Instantiate(_heartImagePrefab, this.transform);
            _hearts.Add(newHeart);
        }
    }

    private void UpdateCountHearts(float actualTime)
    {
        if (Mathf.CeilToInt(actualTime) < _hearts.Count)
        {
            int lastIndex = _hearts.Count - 1;
            Destroy(_hearts[lastIndex]);
            _hearts.RemoveAt(lastIndex);
        }
    }
}
