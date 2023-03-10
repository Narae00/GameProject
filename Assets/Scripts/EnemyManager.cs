using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Transform> m_CreatePointList = new List<Transform> ();
    public List<GameObject> m_EnemyList = new List<GameObject>();
    int m_EnemyListIndex = 0;

    static public EnemyManager instance = null;

    private void Awake()
    {
        instance = this;

        StartCoroutine("EnemyCreateLoop");
    }

    IEnumerator EnemyCreateLoop()
    {
        while (m_EnemyListIndex < m_EnemyList.Count)
        {
            yield return new WaitForSeconds(1.0f);

            m_EnemyList[m_EnemyListIndex].SetActive(true);
            m_EnemyListIndex++;
        }
    }

    public Vector3 Get_CreatPoint()
    {
        return m_CreatePointList[Random.Range(0, m_CreatePointList.Count)].position;
    }
}
