using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base;
using Utility;

namespace Scene
{
    public class Title : Base_Scene
    {
        [SerializeField, Header("BGM�t�@�C����")]
        private string m_TitleBgm = string.Empty;
        
        private void Start()
        {
            m_updateStep = UpdateSequence;
        }

        /// <summary>
        /// ����������
        /// </summary>
        /// <returns></returns>
        private bool StartSequence()
        {
            //BGM�Đ�
            SoundManager.Instance.PlayBGM(m_TitleBgm);
            //�X�V������
            m_updateStep = UpdateSequence;

            return false;
        }

        /// <summary>
        /// �X�V����
        /// </summary>
        /// <returns></returns>
        private bool UpdateSequence()
        {
            return true;
        }

        /// <summary>
        /// �I������
        /// </summary>
        /// <returns></returns>
        private bool EndSequence()
        {
            return true;
        }
    }
}

