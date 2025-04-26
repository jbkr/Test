using UnityEngine;
using UnityEngine.UI;

public class TestToggle : MonoBehaviour
{
    [SerializeField]
    private Toggle toggle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        toggle.onValueChanged.AddListener(OnToggleCallback);
    }

    private void OnToggleCallback(bool isOn)
    {
        Debug.Log("토글의 상태: " + toggle.isOn);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }
}
