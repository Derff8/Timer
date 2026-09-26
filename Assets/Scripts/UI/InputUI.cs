using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputText;

    [SerializeField] private Button _startTimerButton;
    [SerializeField] private Button _stopTimerButton;
    [SerializeField] private Button _resetTimerButton;

    private Timer _timer;

    public void Initialize(Timer timer)
    {
        _timer = timer;
    }

    private void OnEnable()
    {
        _startTimerButton.onClick.AddListener(OnStartClicked);
        _stopTimerButton.onClick.AddListener(OnStopClicked);
        _resetTimerButton.onClick.AddListener(OnResetClicked);
    }

    private void OnDisable()
    {
        _startTimerButton.onClick.RemoveListener(OnStartClicked);
        _stopTimerButton.onClick.RemoveListener(OnStopClicked);
        _resetTimerButton.onClick.RemoveListener(OnResetClicked);
    }

    private void OnStartClicked()
    {
        if (!_timer.InProcess)
        {
            string enterText = _inputText.text;

            if (float.TryParse(enterText, out float duration))
            {
                if (duration > 0)
                {
                    _timer.StartTimer(duration);
                }
            }
        }
        else
            _timer.ContinueTimer();
    }

    private void OnStopClicked()
    {
        _timer.StopTimer();
    }

    private void OnResetClicked()
    {
        _timer.ResetTimer();
    }
}
