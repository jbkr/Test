using UnityEngine;
using UnityEngine.UI;

public class FullTime : MonoBehaviour
{
    [SerializeField]
    private Image _slot;

    private float _time = 2.0f;
    private float _accTime = 0;

    private bool _running;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _slot.fillAmount = 1;
    }

    private float accTime;

    private float duration = 2.0f;
    private float current = 0f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _running = true;
            _slot.fillAmount = 1;
        }

        if (_running)
        {
            accTime += Time.deltaTime;

            float percent = 1 - (accTime / _time);

            _slot.fillAmount = percent;

            Debug.Log("누적시간 : " + _accTime);

            if (_accTime >= _time)
            {
                _running = false;
                _slot.fillAmount = 0;
                _accTime = 0f;
            }
        }
        //current = duration - Time.deltaTime;
        //_slot.fillAmount = (float)current / duration;
    }
}
