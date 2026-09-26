using UnityEngine;

public class BaseTimerUI : MonoBehaviour
{
    protected Timer _myTimer;

    public virtual void Initialize(Timer timer, float maxTime)
    {
        _myTimer = timer;
        _myTimer.OnTimerEnd += DestroyUI;
    }

    protected virtual void OnDestroy()
    {
        if (_myTimer != null)
        {
            _myTimer.OnTimerEnd -= DestroyUI;
        }
    }

    private void DestroyUI()
    {
        Destroy(gameObject);
    }
}
