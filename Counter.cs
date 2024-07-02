using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private readonly float delay = 0.5f;
    private Coroutine _coroutine;
    private float _currentValue = 0f;
    private bool _canIncrease = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            OnPush();
    }
    public void OnPush()
    {
        _canIncrease = !_canIncrease;

        if (_canIncrease)
            Restart();
        else
            Stop();
    }

    private void Restart()
    {
        _coroutine = StartCoroutine(CountUp());
    }

    private void Stop()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator CountUp()
    {
        var wait = new WaitForSeconds(delay);

        while (_canIncrease)
        {
            _currentValue++;
            _text.text = _currentValue.ToString();
            yield return wait;
        }        
    }
}
