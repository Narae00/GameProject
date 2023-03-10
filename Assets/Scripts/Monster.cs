using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Model
{
    public Monster(string _name, int _attack, int _hp) : base(_name, _attack, _hp)
    {
        m_eModelType = eModelType.Monster;
    }

    public override void GetName()
    {
       
    }

    override public void Move()
    {
        Debug.Log(m_Name + "는 위, 아래로 움직입니다.");
    }
}
