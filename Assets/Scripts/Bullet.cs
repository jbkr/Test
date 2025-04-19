using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _speed  = 3;

    [SerializeField]
    private SpriteRenderer _reneder; // �׷��ִ¾� 

    [SerializeField]
    private Sprite[] _sprites; // �׷��پ����� �Ѱ��� �׸��� 

    private float _accTime = 0; // �����ð� 
    private int _currentIndex = 0; // ���� �׸��� �ִ� �׸��߿� ���° �� ����
    
    void Update()
    {
        transform.position += Vector3.up * _speed * Time.deltaTime;

        if(transform.position.y > 10)
            Destroy(gameObject);

        _accTime += Time.deltaTime;

        if (_accTime > 0.05f)
        {
            _currentIndex++;

            if (_currentIndex >= _sprites.Length)
                _currentIndex = 0;

             _reneder.sprite = _sprites[_currentIndex];

            _accTime = 0;
        }
        
    }
}
