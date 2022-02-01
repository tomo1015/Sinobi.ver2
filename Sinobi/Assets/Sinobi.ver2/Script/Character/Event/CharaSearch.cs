using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaSearch : MonoBehaviour
{
    [SerializeField, Header("追いかける対象（デバッグ用）")]
    private GameObject target_object = null;

    private GameObject parentObject;//親オブジェクト


    private void Start()
    {
        //親オブジェクトの情報を取得する
        parentObject = gameObject.transform.root.gameObject;
    }

    /// <summary>
    /// コライダーに入ったら追いかける
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //追いかける相手のオブジェクト情報を取得する
            target_object = other.gameObject;
        }
    }

    /// <summary>
    /// コライダーから出たら巡回処理に変える
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            //相手の情報を初期化する
            target_object = null;
        }
    }
}
