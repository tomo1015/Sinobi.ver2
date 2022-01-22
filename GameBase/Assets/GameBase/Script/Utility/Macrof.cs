using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Constants;

namespace Utility
{
    /// <summary>
    /// 汎用的な関数リスト
    /// </summary>
    public static class Macrofs
    {
        /// <summary>
        /// 回転補正計算
        /// </summary>
        /// <param name="SelfObject">自身のゲームオブジェクト</param>
        /// <param name="TargetObject">ターゲットゲームオブジェクト</param>
        /// <param name="rotSpeed">回転スピード</param>
        /// <returns>回転計算結果</returns>
        public static Quaternion Slerp(GameObject SelfObject, GameObject TargetObject, float rotSpeed)
        {
            //回転値の初期化
            Quaternion rotation = Quaternion.identity;
            //計算を行う
            rotation = Quaternion.Slerp(SelfObject.transform.rotation,                                                    //自身の回転値
                Quaternion.LookRotation(new Vector3((TargetObject.transform.position.x - SelfObject.transform.position.x), //X
                0.0f,                                                                                                      //Y
                (TargetObject.transform.position.z - SelfObject.transform.position.z))),                                   //Z
                rotSpeed);                                                                                                 //回転スピード
            //計算結果を返す
            return rotation;
        }
        /// <summary>
        /// オブジェクト生成位置の設定(矢)
        /// </summary>
        /// <param name="SelfObject">生成する対象キャラクターオブジェクト</param>
        /// <returns>生成位置(座標)</returns>
        public static Vector3 InstanceObject(GameObject SelfObject)
        {
            //オブジェクト生成位置
            Vector3 value =
                new Vector3(SelfObject.transform.position.x + (SelfObject.transform.forward.x * 15.0f),
                            ObjectStatus.ARROW_HEIGHT,
                            SelfObject.transform.position.z + (SelfObject.transform.forward.z * 15.0f));
            //生成値を返す
            return value;
        }

        /// <summary>
        /// 2点間の距離を計算
        /// </summary>
        /// <param name="TargetStaticObject">対象固定オブジェクト</param>
        /// <param name="Character">キャラクターオブジェクト</param>
        /// <returns></returns>
        public static float TwoPointDistance(GameObject TargetStaticObject,GameObject Character)
        {
            float value = Vector3.Magnitude(TargetStaticObject.transform.position - Character.transform.position);
            return value;
        }
    }
}