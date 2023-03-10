using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    void Start()
    {
        Player _Player = new Player("플레이어", 10, 50);
        Monster _Monster = new Monster("몬스터", 5, 30);

        //_Player.Move();
        //_Monster.Move();

        List<Model> _ModelList = new List<Model>();
        _ModelList.Add(_Player);
        _ModelList.Add(_Monster);

        for (int i = 0; i< _ModelList.Count; i++)
        {
            _ModelList[i].Move();
        }

        //string _string = "문자열";
        //int _int = _string;

        //// 업캐스팅 : 자식을 부모의 형태로 캐스팅
        //Model _Model = _Player;
        //Model _ModelMonster = _Monster;

        //// 다운캐스팅 : 부모를 자식의 형태로 캐스팅
        //Player _Monster2 = (Player)_Model;s
        //Debug.Log("Monster2 : " + _Monster2.m_Attack);

        Debug.Log("===== 전투 시작 =====");
        while(_Monster.Get_IsDie() == false && _Player.Get_IsDie() == false) // && 둘다 true여야만 true가 반환됩니다.
        {
            _Monster.Damage(_Player);
            if (_Monster.Get_IsDie() == false)
                _Player.Damage(_Monster);
        }
        Debug.Log("===== 전투 종료 =====");

        //Debug.Log(_Player.m_Name + " 레벨 : " +
        //          _Player.m_Level + " 공격력 : " +
        //          _Player.m_Attack + " 체력 : " +
        //          _Player.m_HP);

        //Debug.Log(_Monster.m_Name + " 레벨 : " +
        //          _Monster.m_Level + " 공격력 : " +
        //          _Monster.m_Attack + " 체력 : " +
        //          _Monster.m_HP);
    }
}
