using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base;

namespace Excutive
{
    /// <summary>
    /// ゲーム管理
    /// </summary>
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        //―――　変数宣言　―――
        private Base_Scene m_scene;             //シーンクラス

        //――― プロパティ宣言 ―――
        // 現在のシーン管理クラスを取得
        public Base_Scene Scene
        {
            get
            {
                if (!m_scene)
                {
                    m_scene = FindObjectOfType<Base_Scene>();
                }
                return m_scene;
            }
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void Awake()
        {
            //インスタンスがあれば
            if (this != Instance)
            {
                //削除する
                Destroy(this);
                return;
            }
            //削除しない
            DontDestroyOnLoad(gameObject);

            // カーソル非表示
            Cursor.visible = false;
        }

        /// <summary>
        /// 更新処理
        /// </summary>
        private void Update()
        {
            // エスケープキーで終了
            if (Input.GetKey(KeyCode.Escape))
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
            }
        }
    }
}
