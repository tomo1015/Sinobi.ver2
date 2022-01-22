using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Base
{
    public abstract class MonoBehaviourEX : MonoBehaviour
    {
        protected delegate bool FuncUpdateStep();//falseで再更新
        protected FuncUpdateStep m_updateStep;//呼び出される関数

        /// <summary>
        /// 更新内容があるか
        /// </summary>
        public bool IsUpdateStep
        {
            get
            {
                return m_updateStep != null;
            }
        }

        protected virtual void Update()
        {
            m_updateStep?.Invoke();
        }
    }
}

