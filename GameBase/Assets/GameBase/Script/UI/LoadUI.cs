using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Base;
using Utility;

namespace UI
{
    public class LoadUI : MonoBehaviour
    {
        [SerializeField, Header("点滅速度")]
        private float SPEED = 0.5f;
        [SerializeField, Header("更新速度")]
        private float COROUTINE_SPEED = 0.02f;

        private Image m_image;

        private float m_start = 0.0f;
        private float m_end = 1.0f;
        private float m_lerp = 0.0f;

        private Base_Fade m_fadeObj = null;
        private int m_step = 0;

        private delegate bool LoadUpdateFunc();
        private LoadUpdateFunc m_updateFunc = null;
        private Canvas m_canas;

        IEnumerator Start()
        {
            if (m_updateFunc == null) m_updateFunc = InitStep;

            if (m_canas) m_canas.worldCamera = Camera.main;

            while (!m_updateFunc()) yield return new WaitForSeconds(COROUTINE_SPEED);

            Destroy(gameObject);
        }

        private bool InitStep()
        {
            DontDestroyOnLoad(gameObject);

            m_fadeObj = FindObjectOfType<Base_Fade>();
            m_image = GetComponentInChildren<Image>();
            m_canas = GetComponent<Canvas>();
            m_canas.worldCamera = Camera.main;
            m_canas.sortingLayerName = Constants.SortingLayerName.Fade;
            m_image.color = new Color(1, 1, 1, 0);
            m_updateFunc = FadeOutStep;
            return false;
        }

        private bool FadeOutStep()
        {
            if (m_fadeObj.IsFadeIn)
            {
                m_updateFunc = FadeInStep;
                return false;
            }

            m_lerp += COROUTINE_SPEED * SPEED;
            m_image.color = new Color(
                m_image.color.r, m_image.color.g, m_image.color.b, Mathf.Lerp(m_start, m_end, m_lerp));
            if (m_lerp >= 1.0f)
            {
                MacroFunc.Swap(ref m_start, ref m_end);
                m_lerp -= 1.0f;
            }

            return false;
        }

        private bool FadeInStep()
        {
            m_lerp += COROUTINE_SPEED * SPEED;
            m_image.color = new Color(
                m_image.color.r, m_image.color.g, m_image.color.b, Mathf.Lerp(m_start, m_end, m_lerp));
            if (m_lerp >= 1.0f)
            {
                if (m_end == 0.0f)
                {
                    return true;
                }
                else
                {
                    MacroFunc.Swap(ref m_start, ref m_end);
                    m_lerp -= 1.0f;
                }
            }
            return false;
        }
    }
}