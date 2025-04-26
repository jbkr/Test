using UnityEngine;
using UnityEngine.UI;


public class HPBar : MonoBehaviour
{
    [SerializeField]
    private Image _hp;

    private int _maxValue = 250;
    private int _hpValue = 250;

    void Start()
    {
        _hp.fillAmount = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _hpValue -= 50;
            float remainHp = _hpValue / (float)_maxValue;
            _hp.fillAmount = remainHp;
        }
    }
}
