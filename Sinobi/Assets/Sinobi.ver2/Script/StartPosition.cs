using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// プレイヤーオブジェクト
/// </summary>
public class StartPosition : MonoBehaviour
{
    [SerializeField, Header("プレイヤープレハブ")]
    private GameObject m_PlayerObject = null;

    private void Start()
    {
        // TODO: 出現エフェクトとアニメーションを考える
        //インスタンス
        Instantiate(m_PlayerObject, this.gameObject.transform);
    }
}
