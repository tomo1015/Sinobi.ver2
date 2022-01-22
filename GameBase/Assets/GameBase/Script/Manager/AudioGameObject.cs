using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Utility
{
    public class AudioGameObject : MonoBehaviour
    {
        private AudioSource m_source        = null;
        private Transform   m_target        = null;
        private float       m_defaultVolume = 1.0f;

        public AudioSource Source
        {
            get
            {
                return m_source;
            }
        }
        public float Volume
        {
            set
            {
                m_source.volume = value * m_defaultVolume;
            }
        }
        public bool IsPlaying
        {
            get
            {
                return m_source && m_source.isPlaying;
            }
        }
        public void Stop()
        {
            m_source.Stop();
        }
        public Transform Target
        {
            get
            {
                return m_target;
            }
        }

        void Awake()
        {
            // 親が登録したのでコメントアウト
            //DontDestroyOnLoad(gameObject);

            m_source = GetComponent<AudioSource>();
        }

        void Update()
        {
            if (m_target) transform.position = m_target.position;
        }

        /// <summary>
        /// 再生開始
        /// </summary>
        /// <param name="clip">対象クリップ</param>
        /// <param name="startPos">発生初期位置</param>
        /// <param name="target">対象から音を発生させる</param>
        /// <param name="defaultVolume">基礎音量</param>
        /// <param name="isLoop">ループフラグ</param>
        /// <param name="spatialBlend">立体音響設定(0.0～1.0)</param>
        public void PlayStart(AudioClip clip, Vector3 startPos, Transform target, float defaultVolume, bool isLoop, float spatialBlend)
        {
            m_target            = target;
            m_defaultVolume     = defaultVolume;
            transform.position  = startPos;

            m_source.Stop();
            m_source.clip           = clip;            
            m_source.spatialBlend   = spatialBlend;
            m_source.loop           = isLoop;
            m_source.Play();
        }
        
    }
}