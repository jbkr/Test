using UnityEngine;

public class GravityPong : MonoBehaviour
{
    void Start()
    {   
        //Physics2D.bounceThreshold = 10f; // �ſ� ���� �ӵ������� ƨ�⵵�� ����
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("OnCollisionEnter2D : " + other.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D : " + other.gameObject.name);
    }



}
