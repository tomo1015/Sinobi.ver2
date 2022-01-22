using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Base;

public class FadeNormal : Base_Fade
{
    [SerializeField]
    private Color COVER_COLOR  = Color.black; // フェードアウト時の色指定
    [SerializeField]
    private float SPEED        = 1.0f;        // フェードイン/アウトの速度

    private float m_alpha = 0.0f;
    private Image m_image = null;
    

    protected override void Awake()
    {
        base.Awake();

        m_image = GetComponentInChildren<Image>();
    }

    protected override bool FadeOutStep()
    {
        m_alpha += Time.deltaTime * SPEED;
        m_image.color = new Color(COVER_COLOR.r, COVER_COLOR.g, COVER_COLOR.b, m_alpha);
        if (m_alpha >= 1.0f)
        {
            m_updateStep = null;
            m_alpha      = 1.0f;
        }
        return true;
    }

    protected override bool FadeInStep()
    {
        m_alpha -= Time.deltaTime * SPEED;
        m_image.color = new Color(COVER_COLOR.r, COVER_COLOR.g, COVER_COLOR.b, m_alpha);
        if (m_alpha <= 0.0f) m_updateStep = EndStep;
        return true;
    }
}
