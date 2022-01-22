using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base;
using Utility;

namespace Scene
{
    public class Title : Base_Scene
    {
        [SerializeField, Header("BGMファイル名")]
        private string m_TitleBgm = string.Empty;
        
        private void Start()
        {
            m_updateStep = UpdateSequence;
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <returns></returns>
        private bool StartSequence()
        {
            //BGM再生
            SoundManager.Instance.PlayBGM(m_TitleBgm);
            //更新処理へ
            m_updateStep = UpdateSequence;

            return false;
        }

        /// <summary>
        /// 更新処理
        /// </summary>
        /// <returns></returns>
        private bool UpdateSequence()
        {
            return true;
        }

        /// <summary>
        /// 終了処理
        /// </summary>
        /// <returns></returns>
        private bool EndSequence()
        {
            return true;
        }
    }
}

