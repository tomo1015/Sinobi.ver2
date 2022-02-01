using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゴールオブジェクト
/// </summary>
public class GoalPosition : MonoBehaviour
{
    /// <summary>
    /// 衝突
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        //ぶつかってきたオブジェクトがプレイヤーならば
        if (collision.transform.tag == "Player")
        {
            //ゴール演出
            //クリア状態を保存（AutoSaveUIをついでに）


        }
        else
        {
            //なにもしない
            return;
        }
    }
}

