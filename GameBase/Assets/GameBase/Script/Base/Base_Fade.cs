using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Base
{
    public abstract class Base_Fade : MonoBehaviourEX
    {
        protected Canvas m_canvas = null;

        /// <summary>
        /// フェードアウト状態か
        /// </summary>
        public virtual bool IsFadeOut
        {
            get
            {
                return m_updateStep == FadeOutStep;
            }
        }
        
        /// <summary>
        /// フェードイン状態か
        /// </summary>
        public virtual bool IsFadeIn
        {
            get
            {
                return m_updateStep == FadeInStep;
            }
        }

        /// <summary>
        /// フェードイン開始
        /// </summary>
        public virtual void StartInFade()
        {
            m_updateStep = FadeInStep;
        }

        /// <summary>
        /// 初期更新
        /// </summary>
        protected virtual void Awake()
        {
            DontDestroyOnLoad(this.gameObject);

            //フェードアウト開始
            m_updateStep = FadeOutStep;

            //キャンバス設定
            m_canvas = GetComponent<Canvas>();
            m_canvas.enabled = true;
            m_canvas.sortingLayerName = "Fade";

        }

        /// <summary>
        /// フェードアウト更新
        /// </summary>
        protected abstract void FadeOutStep();

        /// <summary>
        /// フェードイン更新
        /// </summary>
        protected abstract void FadeInStep();

        /// <summary>
        /// 終了時更新
        /// </summary>
        protected virtual void EndStep()
        {
            Destroy(this.gameObject);
        }
    }

}
