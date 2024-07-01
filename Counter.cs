using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private readonly float delay = 0.5f;
    private float _currentValue = 0f;
    private bool _canIncrease = false;

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

    public void OnPush()
    {
        _canIncrease = !_canIncrease;

        if (_canIncrease)
            StartCoroutine(CountUp());
        else
            StopCoroutine(CountUp());
    }
}
