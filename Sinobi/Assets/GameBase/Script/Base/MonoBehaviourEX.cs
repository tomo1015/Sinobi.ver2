using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Base
{
    public abstract class MonoBehaviourEX : MonoBehaviour
    {
        protected delegate bool FuncUpdateStep();//false�ōčX�V
        protected FuncUpdateStep m_updateStep;//�Ăяo�����֐�

        /// <summary>
        /// �X�V���e�����邩
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

