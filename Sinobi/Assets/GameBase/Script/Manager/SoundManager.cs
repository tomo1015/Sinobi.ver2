using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base;
using System.Linq;

namespace Utility
{
    /// <summary>
    /// Resourcesフォルダを使わずに全てのBGM/SEを管理するクラス。
    /// </summary>
    public class SoundManager : SingletonMonoBehaviour<SoundManager>
    {
        public struct DefaultVolume//サウンドの音量
        {
            public const float Level_1 = 0.1f;  
            public const float Level_2 = 0.25f;
            public const float Level_3 = 0.5f;
            public const float Level_4 = 0.8f;
            public const float Level_5 = 1.0f;
        }
        //――― 変数宣言 ―――
        [SerializeField, Header("オーディオゲームオブジェクトのプレハブ")]
        private AudioGameObject AUDIO_GAMEOBJ_PREFAB    = null;
        [SerializeField, Header("SEの最大再生数")]
        private int             MAX_PLAY_SE             = 10;
        [SerializeField, Header("BGMをリストに登録")]
        private List<AudioClip> m_bgmList               = null; 
        [SerializeField, Header("SEをリストに登録")]
        private List<AudioClip> m_seList                = null;
        [SerializeField, Header("マスター音量")]
        private float           m_masterVolume          = 1.0f;
        [SerializeField, Header("BGM音量")]
        private float           m_bgmVolume             = 1.0f;
        [SerializeField, Header("SE音量")]
        private float           m_seVolume              = 1.0f;
        
        private Dictionary<string, AudioClip> m_bgmDict        = null;
        private Dictionary<string, AudioClip> m_seDict         = null;
        private AudioGameObject               m_bgmAudioObject = null;
        private List<AudioGameObject>         m_seAudioObjects = null;
        private AudioListener                 m_audioListener  = null;

        /// <summary>
        /// マスター音量
        /// </summary>
        public float Volume
        {
            get
            {
                return m_masterVolume;
            }
            set
            {
                m_masterVolume = Mathf.Clamp01(value);
                m_bgmAudioObject.Source.volume = m_bgmVolume * m_masterVolume;
                m_seAudioObjects.ForEach(
                    s =>
                    {
                        if (s.Source) s.Source.volume = m_seVolume * m_masterVolume;
                    }
                );
            }
        }
        /// <summary>
        /// BGM音量
        /// </summary>
        public float BGMVolume
        {
            get
            {
                return m_bgmVolume;
            }
            set
            {
                m_bgmVolume = Mathf.Clamp01(value);
                m_bgmAudioObject.Volume = m_bgmVolume * m_masterVolume;
            }
        }
        /// <summary>
        /// SE音量
        /// </summary>
        public float SEVolume
        {
            get
            {
                return m_seVolume;
            }
            set
            {
                m_seVolume = Mathf.Clamp01(value);
                m_seAudioObjects.ForEach(
                    s =>
                    {
                        if (s.Source) s.Volume = m_seVolume * m_masterVolume;
                    }
                );
            }
        }


        protected override void Awake()
        {
            if (this != Instance)
            {
                Destroy(this);
                return;
            }
            DontDestroyOnLoad(gameObject);

            // 各種インスタンス
            m_bgmDict        = new Dictionary<string, AudioClip>();
            m_seDict         = new Dictionary<string, AudioClip>();
            m_bgmAudioObject = AudioGameObject.Instantiate(AUDIO_GAMEOBJ_PREFAB, transform);
            m_seAudioObjects = new List<AudioGameObject>();
            for (int i = 0; i < MAX_PLAY_SE; ++i)
            {
                AudioGameObject _obj = Instantiate(AUDIO_GAMEOBJ_PREFAB, transform);
                m_seAudioObjects.Add(_obj);
            }

            // 使用可能なBGM/SEを連想配列に登録
            {
                void AddClipDict(Dictionary<string, AudioClip> dict, AudioClip clip)
                {
                    if (!dict.ContainsKey(clip.name)) dict.Add(clip.name, clip);
                }
                m_bgmList.ForEach(bgm => AddClipDict(m_bgmDict, bgm));
                m_seList. ForEach(se  => AddClipDict(m_seDict,  se));
            }

            // リスナー検索
            foreach (var _listener in FindObjectsOfType<AudioListener>())
                if (_listener.gameObject != gameObject)
                    m_audioListener = _listener;
        }

        /// <summary>
        /// SEを再生
        /// </summary>
        /// <param name="seName">ハンドル名</param>
        /// <param name="defaultVolume">基礎音量</param>
        /// <param name="isLoop">ループフラグ</param>
        /// <returns>使用されたオーディオオブジェクト</returns>
        public AudioGameObject PlaySE_2D(string seName, float defaultVolume = 1.0f, bool isLoop = false)
        {
            if (!m_seDict.ContainsKey(seName)) return null;

            AudioGameObject _audioObj = m_seAudioObjects.FirstOrDefault(s => !s.IsPlaying);
            if (!_audioObj)
            {
#if UNITY_EDITOR
                Debug.Log("再生可能なSEが最大数を越えました。");
#endif
                return null;
            }
            _audioObj.PlayStart(m_seDict[seName], Vector3.zero, null, defaultVolume, isLoop, 0.0f);
            return _audioObj;
        }

        /// <summary>
        /// SEを再生
        /// </summary>
        /// <param name="seName">ハンドル名</param>
        /// <param name="pos">発生位置</param>
        /// <param name="target">ターゲット</param>
        /// <param name="defaultVolume">基礎音量</param>
        /// <param name="isLoop">ループフラグ</param>
        /// <returns>使用されたオーディオオブジェクト</returns>
        public AudioGameObject PlaySE_3D(string seName, Vector3 pos, Transform target, float defaultVolume = 1.0f, bool isLoop = false)
        {
            if (!m_seDict.ContainsKey(seName)) return null;

            AudioGameObject _audioObj = m_seAudioObjects.FirstOrDefault(s => !s.IsPlaying);
            if (!_audioObj)
            {
#if UNITY_EDITOR
                Debug.Log("再生可能なSEが最大数を越えました。");
#endif
                return null;
            }

            _audioObj.PlayStart(m_seDict[seName], pos, target, defaultVolume, isLoop, 1.0f);
            return _audioObj;
        }

        /// <summary>
        /// SEを停止
        /// </summary>
        /// <param name="seName">ハンドル名</param>
        /// <param name="user">使用者</param>
        public void StopSE(string seName, Transform user)
        {
            bool FindSE(AudioGameObject s)
            {
                return s.IsPlaying && s.Source.clip.name == seName && s.Target == user;
            }
            AudioGameObject _source = m_seAudioObjects.FirstOrDefault(s => FindSE(s));
            if (_source) _source.Stop();
        }

        /// <summary>
        /// SEを全て停止
        /// </summary>
        public void StopSE()
        {
            m_seAudioObjects.ForEach(s => s.Stop());
        }

        /// <summary>
        /// BGMを再生
        /// </summary>
        /// <param name="bgmName">ハンドル名</param>
        /// <param name="defaultVolume">基礎音量</param>
        /// <param name="isLoop">BGMをループするか</param>
        /// <returns>使用されたオーディオオブジェクト</returns>
        public AudioGameObject PlayBGM(string bgmName, float defaultVolume = 1.0f, bool isLoop = true)
        {
            if (!m_bgmDict.ContainsKey(bgmName)) return null;
            m_bgmAudioObject.Stop();
            m_bgmAudioObject.PlayStart(m_bgmDict[bgmName], Vector3.zero, null, defaultVolume, isLoop, 0.0f);
            return m_bgmAudioObject;
        }

        /// <summary>
        /// BGMを停止
        /// </summary>
        public void StopBGM()
        {
            m_bgmAudioObject.Stop();
        }

        /// <summary>
        /// リスナー変更
        /// </summary>
        /// <param name="obj">対象のオブジェクト</param>
        public void ChangeListener(GameObject obj)
        {
            if (m_audioListener) m_audioListener.enabled = false;

            var _listener = obj.GetComponent<AudioListener>();
            if (!_listener) _listener = obj.AddComponent<AudioListener>();
            else            _listener.enabled = true;
            
            m_audioListener = _listener;
        }
    }
}
