using UnityEngine;
using UnityEngine.UI;
using HGS.CallLimiter;

public class Stagging : MonoBehaviour
{
    [SerializeField] Text withoutFilterTxt = null;
    [SerializeField] Text throttleTxt = null;
    [SerializeField] Text debounceTxt = null;

    int _withoutFilterCounter = 0;
    int _throttleCounter = 0;
    int _debounceCounter = 0;

    float _fireRatio = 0.3f;
    float _minTimeBetweenFires = 0.1f;

    Throttle _fireThrottle = new Throttle();
    Debounce _fireDebounce= new Debounce();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _withoutFilterCounter += 1;
            withoutFilterTxt.text = _withoutFilterCounter.ToString();

            _fireThrottle.Run(() =>
            {
                _throttleCounter += 1;
                throttleTxt.text = _throttleCounter.ToString();
            }, _fireRatio);

            _fireDebounce.Run(() =>
            {
                _debounceCounter += 1;
                debounceTxt.text = _debounceCounter.ToString();
            }, _minTimeBetweenFires, this);
        }
    }
}
