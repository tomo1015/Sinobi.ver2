using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Base
{
    public abstract class Base_Fade : MonoBehaviourEX
    {
        protected Canvas m_canvas = null;

        /// <summary>
        /// �t�F�[�h�A�E�g��Ԃ�
        /// </summary>
        public virtual bool IsFadeOut
        {
            get
            {
                return m_updateStep == FadeOutStep;
            }
        }
        
        /// <summary>
        /// �t�F�[�h�C����Ԃ�
        /// </summary>
        public virtual bool IsFadeIn
        {
            get
            {
                return m_updateStep == FadeInStep;
            }
        }

        /// <summary>
        /// �t�F�[�h�C���J�n
        /// </summary>
        public virtual void StartInFade()
        {
            m_updateStep = FadeInStep;
        }

        /// <summary>
        /// �����X�V
        /// </summary>
        protected virtual void Awake()
        {
            DontDestroyOnLoad(this.gameObject);

            //�t�F�[�h�A�E�g�J�n
            m_updateStep = FadeOutStep;

            //�L�����o�X�ݒ�
            m_canvas = GetComponent<Canvas>();
            m_canvas.enabled = true;
            m_canvas.sortingLayerName = "Fade";

        }

        /// <summary>
        /// �t�F�[�h�A�E�g�X�V
        /// </summary>
        protected abstract void FadeOutStep();

        /// <summary>
        /// �t�F�[�h�C���X�V
        /// </summary>
        protected abstract void FadeInStep();

        /// <summary>
        /// �I�����X�V
        /// </summary>
        protected virtual void EndStep()
        {
            Destroy(this.gameObject);
        }
    }

}
