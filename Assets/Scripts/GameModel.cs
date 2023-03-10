using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : MonoBehaviour
{
    public int m_HP = 3;
    protected int m_maxHP = 0;

    [HideInInspector]
    public bool m_isDeath = false;

    public Collider m_Collider;
}
