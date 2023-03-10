using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CubeController : GameModel
{
    // [Header ("== 캐릭터 데이터 ==")] // 인스펙터 창에서 문자열 표시
    // [Tooltip ("이동속도")]           // 변수명에 마우스로 정보 표시
    // [HideInInspector]                // 스크립트에서만 접근권한 "공개", 유니티 인스펙터 창에서는 "비공개"
    // [SerializeField]                 // 스크립트에서 "비공개", 유니티 인스펙터 창에서는 "공개"
    // [Range (1, 10)]                  // 인스펙터 창에서 데이터 수정 범위를 제한하고 싶을 때
    public int m_Speed = 4;
    // [Space(30)]                      // 인스펙터에 공개된 변수간의 표시거리 조절 (거리 조절한 변수 사이에 작성)
    public Animator m_Animator;
    public Animator m_AnimatorCannon;

    public Transform m_Cannon;
    public BulletManager m_BulletManager;

    private void Start()
    {
        m_maxHP = m_HP;

        InGameManager.instance.Set_PlayerHP(m_maxHP, m_HP);
    }

    //private void Start()
    //{
    //    m_Animator = transform.GetChild(0).GetComponent<Animator>(); // 자기 자신의 첫번째 자식의 컴포넌트 받아오기
    //}

    void Update()
    {
        if (m_isDeath == true)
            return;
        
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            m_Animator.SetBool("_IsMove", true);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            float _Vertical = Input.GetAxis("Vertical");
            float _Horizontal = Input.GetAxis("Horizontal");

            Vector3 _movePos = (Vector3.forward * _Vertical) + (Vector3.right * _Horizontal);

            transform.localPosition += _movePos.normalized * Time.deltaTime * m_Speed;
        }
        else
        {
            m_Animator.SetBool("_IsMove", false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            m_BulletManager.Shoot(m_Cannon.position, transform.forward);
            m_AnimatorCannon.SetTrigger("_Shoot");
        }

        Rotate();
    }

    void Rotate()
    {
        Vector3 _targetPos = Vector3.zero;

        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit _RaycastHit;

        if (Physics.Raycast(_ray, out _RaycastHit, Mathf.Infinity))
        {
            _targetPos = _RaycastHit.point;
        }

        Vector3 _myPosition = transform.position;

        float _dz = _targetPos.z - _myPosition.z;
        float _dx = _targetPos.x - _myPosition.x;

        float rotateDegree = Mathf.Atan2(_dx, _dz) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, rotateDegree, 0);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            // 게임이 재시작 되도록
            GameOver();
        }
    }

    public void Set_Damage()
    {
        m_HP--;

        InGameManager.instance.Set_PlayerHP(m_maxHP, m_HP);

        if (m_HP <= 0)
        {
            m_isDeath = true;
            m_Collider.enabled = false;

            GetComponent<Rigidbody>().useGravity = false;

            Invoke("GameOver", 1.5f);
        }
        else
            m_Animator.SetTrigger("_Damage");
    }

    void GameOver()
    {
        Debug.Log("게임 오버");

        InGameManager.instance.SaveData();

        SceneManager.LoadScene("GameOver");
    }
}
