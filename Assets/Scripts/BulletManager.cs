using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public List<Bullet> m_BulletList = new List<Bullet>();
    int m_Index = 0;

    public void Shoot(Vector3 _startPos, Vector3 _direction)
    {
        m_BulletList[m_Index].Shoot(_startPos, _direction);
        m_Index++;

        if (m_Index >= m_BulletList.Count)
            m_Index = 0;
    }
}
