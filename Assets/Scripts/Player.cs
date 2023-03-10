using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Model
{
    public Player(string _name, int _attack, int _hp) : base(_name, _attack, _hp)
    {
        m_eModelType = eModelType.Player;
    }

    public override void GetName()
    {
   
    }

    public void LevelUp()
    {
        m_Level++;
        Debug.Log(m_Name + "의 레벨이 올랐습니다. Level : " + m_Level);
    }

    override public void Move()
    {
        Debug.Log(m_Name + "는 좌, 우로 움직입니다.");
    }
}
