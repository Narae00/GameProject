using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : GameModel
{
    public Animator m_Animator;
    public float m_CreateTime = 2.0f;
    public NavMeshAgent m_NavMeshAgent;

    [HideInInspector]
    public float m_Speed = 3.5f; // 이동속도
    [HideInInspector]
    public float m_AngularSpeed = 120f; // 회전속도

    Transform m_PlayerTF;

    void Start()
    {
        m_maxHP = m_HP;

        m_PlayerTF = GameObject.FindGameObjectWithTag("Player").transform;

        ReCreate();
    }

    void Update()
    {
        if (m_NavMeshAgent.enabled == true)
            m_NavMeshAgent.SetDestination(m_PlayerTF.position);
    }

    public void Set_Damage()
    {
        m_HP--;

        InGameManager.instance.Set_EnemyHP(m_maxHP, m_HP);

        if (m_HP <= 0)
        {
            m_Animator.SetTrigger("_Death");
            m_isDeath = true;
            m_Collider.enabled = false;
            m_NavMeshAgent.enabled = false;

            Invoke("ReCreate", m_CreateTime);

            InGameManager.instance.Kill_Enemy();
        }
        else
            m_Animator.SetTrigger("_Damage");
    }

    public void ReCreate()
    {
        m_HP = 3;

        m_isDeath = false;
        m_Collider.enabled = true;
        m_NavMeshAgent.enabled = true;

        m_Speed += 0.5f;
        m_AngularSpeed += 10;

        m_NavMeshAgent.speed = m_Speed;
        m_NavMeshAgent.angularSpeed = m_AngularSpeed;

        Vector3 _createPos = EnemyManager.instance.Get_CreatPoint();
        transform.position = _createPos;

        m_Animator.SetTrigger("_Show");
    }

    // 물리적인 충돌시 호출되는 함수
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ReCreate();
            collision.gameObject.GetComponent<CubeController>().Set_Damage();
        }
    }
}
