using System.Collections.Generic;
using UnityEngine;

public class HeartsContainerUI : BaseTimerUI
{
    [SerializeField] private GameObject _heartImagePrefab;

    private List<GameObject> _hearts = new List<GameObject>();

    public override void Initialize(Timer timer, float maxTime)
    {
        base.Initialize(timer, maxTime);

        SetCountHearts(maxTime);
        _myTimer.OnTimerChanged += UpdateCountHearts;
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

    protected override void OnDestroy()
    {
        base.OnDestroy();

        _myTimer.OnTimerChanged -= UpdateCountHearts;
    }
}
