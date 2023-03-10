using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eModelType
{
    Player = 0,
    Monster,
}

abstract public class Model
{
    // private   : 현재 작성중인 클래스 내부에서만 사용 가능
    // protected : 자기 자신과 상속받은 클래스 내부에서만 사용 가능
    // public    : 자기 자신과 상속받은 클래스와 클래스 외부에서도 접근가능
    public string m_Name;
    public int m_Level;
    public int m_Attack;
    public int m_HP;

    public eModelType m_eModelType;

    bool m_IsDie = false;

    public Model(string _name, int _attack, int _hp)
    {
        m_Name = _name;
        m_Level = 1;
        m_Attack = _attack;
        m_HP = _hp;
    }

    // 가상 함수 사용
    public void Damage(Model _model)
    {
        m_HP -= _model.m_Attack;
        Debug.Log(m_Name + " 남은 체력 : " + m_HP);

        if(m_HP <= 0)
        {
            m_IsDie = true;

            if (_model.m_eModelType == eModelType.Player)
            {
                Player _player = (Player)_model;
                _player.LevelUp();
            }
        }
    }

    public bool Get_IsDie()
    {
        return m_IsDie;
    }

    // 가상함수로 이동
    virtual public void Move()
    {

    }

    abstract public void GetName();
}
