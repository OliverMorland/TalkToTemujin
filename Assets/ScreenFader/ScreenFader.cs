using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

namespace VR_Utilities
{
    public class ScreenFader : MonoBehaviour
    {
        public float fadeTime = 1.0f;
        public Renderer fadeRenderer;
        public string newSceneName;

        public static ScreenFader Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        private void Start()
        {
            FadeToTransparent();
        }

        public void FadeToTransparent()
        {
            StartCoroutine(TransitionFromOpaqueToTransparent());
        }

        public void FadeToOpaqueAndLoadNewScene()
        {
            StartCoroutine(WaitForFadeBeforeLoadingNewScene(newSceneName));
        }

        IEnumerator WaitForFadeBeforeLoadingNewScene(string sceneName)
        {
            yield return WaitForFade(0f, 1f);
            SceneManager.LoadScene(sceneName);
        }

        IEnumerator WaitForFade(float startOpacity, float speed)
        {
            fadeRenderer.enabled = true;
            float elapsedTime = 0;
            while (elapsedTime < fadeTime)
            {
                float progress = elapsedTime / fadeTime;
                fadeRenderer.material.color = new Color(0, 0, 0, startOpacity + (speed * progress));
                yield return new WaitForEndOfFrame();
                elapsedTime += Time.deltaTime;
            }
        }

        IEnumerator TransitionFromOpaqueToTransparent()
        {
            yield return WaitForFade(1f, -1f);
        }
    }
}
