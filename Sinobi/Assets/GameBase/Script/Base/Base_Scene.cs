using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Base
{
    /// <summary>
    /// シーンクラス
    /// </summary>
    public class Base_Scene : MonoBehaviourEX
    {
        [SerializeField, Header("別シーン遷移時に呼び出されるオブジェクト")]
        private Base_Fade NEXT_FADE_PREFAB = null;
        [SerializeField, Header("再度シーン読み込み時に呼び出されるオブジェクト")]
        private Base_Fade RELOAD_FADE_PREFAB = null;
        [SerializeField, Header("次のシーン名")]
        private string NEXT_SCENE_DEFAULT = string.Empty;

        private Base_Fade m_nextSceneFade = null;//呼び出すフェードを保持する
        private string m_nextSceneName = string.Empty;

        private static string m_currentSceneName = string.Empty;
        private static string m_prevSceneName = string.Empty;
        private LoadSceneCoroutine m_loadSceneCoroutine = null;

        /// <summary>
        /// 現在のシーン名取得
        /// </summary>
        public static string CurrentSceneName
        {
            get
            {
                return m_currentSceneName;
            }
        }

        /// <summary>
        /// 前回のシーン名取得
        /// </summary>
        public static string PrevSceneName
        {
            get
            {
                return m_prevSceneName;
            }
        }

        protected virtual void Awake()
        {
            m_currentSceneName = SceneManager.GetActiveScene().name;
            m_loadSceneCoroutine = GetComponentInChildren<LoadSceneCoroutine>();
            m_loadSceneCoroutine.transform.parent = null;

#if UNITY_EDITOR
            if (m_prevSceneName == string.Empty)
            {
                m_prevSceneName = "Stagenull";
            }
#endif
        }

        protected virtual void OnDestroy()
        {
            m_prevSceneName = m_currentSceneName;
        }

        /// <summary>
        /// シーン変更。シーン遷移時はこの関数を呼ぶ。
        /// </summary>
        /// <param name="sceneName">シーン名</param>
        /// <param name="saveStart">セーブするか否か</param>
        public void NextScene(string sceneName, bool saveStart)
        {
            NextScene_Internal(sceneName, saveStart, NEXT_FADE_PREFAB);
        }

        /// <summary>
        /// シーン変更。シーン遷移時はこの関数を呼ぶ。
        /// </summary>
        /// <param name="saveStart">セーブするか否か</param>
        public void NextScene(bool saveStart)
        {
            NextScene_Internal(NEXT_SCENE_DEFAULT, saveStart, NEXT_FADE_PREFAB);
        }

        /// <summary>
        /// シーン再読み込み
        /// </summary>
        /// <param name="saveStart">セーブするか否か</param>
        public void ReloadScene(bool saveStart)
        {
            NextScene_Internal(CurrentSceneName, saveStart, RELOAD_FADE_PREFAB);
        }


        private void NextScene_Internal(string sceneName, bool saveStart, Base_Fade fade)
        {
            if (m_nextSceneName != string.Empty) return;

            // フェードオブジェクト生成
            if (fade) m_nextSceneFade = Instantiate(fade);

            m_nextSceneName = sceneName;
            m_updateStep = null;

            // シーン遷移を委託
            m_loadSceneCoroutine.LoadSceneStart(m_nextSceneName, m_nextSceneFade);

            if (saveStart)
            {
                // ロードUI生成
                //Instantiate(LOAD_UI_PREFAB);

                // データセーブ
                //GameFlagManager.Save();
            }
            else
            {
                //セーブなしでロードUI生成のみ
                //Instantiate(LOAD_UI_PREFAB)
            }

#if UNITY_EDITOR
            Debug.Log("ステージ状態[今/前]：" + CurrentSceneName + ":" + PrevSceneName);
            //Debug.Log("ステージ番号：" + StageManager.Instance.StageNumber);
#endif
        }
    }
}