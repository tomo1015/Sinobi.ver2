using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Base
{
    public class LoadSceneCoroutine : MonoBehaviour
    {
        private string m_nextSceneName = string.Empty;
        private Base.Base_Fade m_nextSceneFade = null;

        void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void LoadSceneStart(string nextSceneName, Base.Base_Fade fade)
        {
            m_nextSceneName = nextSceneName;
            m_nextSceneFade = fade;
            StartCoroutine("LoadScene");
        }

        IEnumerator LoadScene()
        {
            // ÉVÅ[ÉìïœçX
            while (m_nextSceneFade && m_nextSceneFade.IsFadeOut) yield return null;

            //yield return SceneManager.LoadSceneAsync(m_nextSceneName);

            //if (m_nextSceneFade) m_nextSceneFade.StartFadeIn();
            Destroy(gameObject);
        }
    }

}