using UnityEngine;
using UnityEngine.UI;

public class SliderUI : BaseTimerUI
{
    [SerializeField] private Slider _slider;

    public override void Initialize(Timer timer, float maxTime)
    {
        base.Initialize(timer, maxTime);

        _slider.maxValue = maxTime;
        _slider.value = maxTime;
        _myTimer.OnTimerChanged += UpdateSliderValue;
    }

    private void UpdateSliderValue(float currentTime)
    {
        _slider.value = currentTime;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        _myTimer.OnTimerChanged -= UpdateSliderValue;
    }
}
