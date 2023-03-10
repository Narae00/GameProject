using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float m_Speed = 1f;
    Vector3 m_Direction = Vector3.zero;

    public void Shoot(Vector3 _startPos, Vector3 _direction)
    {
        gameObject.SetActive(true);

        transform.position = _startPos;
        m_Direction = _direction;

        CancelInvoke("HideBullet");
        Invoke("HideBullet", 2.0f);
    }

    void HideBullet()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        transform.position += m_Direction * m_Speed * Time.deltaTime;
    }

    // 충돌시 호출되는 함수
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            other.gameObject.GetComponent<Enemy>().Set_Damage();
        }
    }

    // 물리적인 충돌시 호출되는 함수
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Wall"))
    //    {
    //        gameObject.SetActive(false);
    //    }
    //}
}
