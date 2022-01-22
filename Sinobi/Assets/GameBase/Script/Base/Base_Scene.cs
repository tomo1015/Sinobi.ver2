using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Base
{
    /// <summary>
    /// �V�[���N���X
    /// </summary>
    public class Base_Scene : MonoBehaviourEX
    {
        [SerializeField, Header("�ʃV�[���J�ڎ��ɌĂяo�����I�u�W�F�N�g")]
        private Base_Fade NEXT_FADE_PREFAB = null;
        [SerializeField, Header("�ēx�V�[���ǂݍ��ݎ��ɌĂяo�����I�u�W�F�N�g")]
        private Base_Fade RELOAD_FADE_PREFAB = null;
        [SerializeField, Header("���̃V�[����")]
        private string NEXT_SCENE_DEFAULT = string.Empty;

        private Base_Fade m_nextSceneFade = null;//�Ăяo���t�F�[�h��ێ�����
        private string m_nextSceneName = string.Empty;

        private static string m_currentSceneName = string.Empty;
        private static string m_prevSceneName = string.Empty;
        private LoadSceneCoroutine m_loadSceneCoroutine = null;

        /// <summary>
        /// ���݂̃V�[�����擾
        /// </summary>
        public static string CurrentSceneName
        {
            get
            {
                return m_currentSceneName;
            }
        }

        /// <summary>
        /// �O��̃V�[�����擾
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
        /// �V�[���ύX�B�V�[���J�ڎ��͂��̊֐����ĂԁB
        /// </summary>
        /// <param name="sceneName">�V�[����</param>
        /// <param name="saveStart">�Z�[�u���邩�ۂ�</param>
        public void NextScene(string sceneName, bool saveStart)
        {
            NextScene_Internal(sceneName, saveStart, NEXT_FADE_PREFAB);
        }

        /// <summary>
        /// �V�[���ύX�B�V�[���J�ڎ��͂��̊֐����ĂԁB
        /// </summary>
        /// <param name="saveStart">�Z�[�u���邩�ۂ�</param>
        public void NextScene(bool saveStart)
        {
            NextScene_Internal(NEXT_SCENE_DEFAULT, saveStart, NEXT_FADE_PREFAB);
        }

        /// <summary>
        /// �V�[���ēǂݍ���
        /// </summary>
        /// <param name="saveStart">�Z�[�u���邩�ۂ�</param>
        public void ReloadScene(bool saveStart)
        {
            NextScene_Internal(CurrentSceneName, saveStart, RELOAD_FADE_PREFAB);
        }


        private void NextScene_Internal(string sceneName, bool saveStart, Base_Fade fade)
        {
            if (m_nextSceneName != string.Empty) return;

            // �t�F�[�h�I�u�W�F�N�g����
            if (fade) m_nextSceneFade = Instantiate(fade);

            m_nextSceneName = sceneName;
            m_updateStep = null;

            // �V�[���J�ڂ��ϑ�
            m_loadSceneCoroutine.LoadSceneStart(m_nextSceneName, m_nextSceneFade);

            if (saveStart)
            {
                // ���[�hUI����
                //Instantiate(LOAD_UI_PREFAB);

                // �f�[�^�Z�[�u
                //GameFlagManager.Save();
            }
            else
            {
                //�Z�[�u�Ȃ��Ń��[�hUI�����̂�
                //Instantiate(LOAD_UI_PREFAB)
            }

#if UNITY_EDITOR
            Debug.Log("�X�e�[�W���[��/�O]�F" + CurrentSceneName + ":" + PrevSceneName);
            //Debug.Log("�X�e�[�W�ԍ��F" + StageManager.Instance.StageNumber);
#endif
        }
    }
}