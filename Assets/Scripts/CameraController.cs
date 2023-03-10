using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // 플레이어의 Transfrom
    public Transform m_Player;

    //-0.3479011
    //10.75287
    //-4.771211
    void Update()
    {
        // 카메라의 위치를 플레이어 기준으로 거리를 둔다
        transform.localPosition = m_Player.localPosition + new Vector3(-0.3479011f, 10.75287f, -4.771211f);
    }
}
