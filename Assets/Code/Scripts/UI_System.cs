using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class UI_System : MonoBehaviour
    {
        #region Variables
        [Header("Main Properties")]
        public UI_Screen m_StartScreen;
        [Header("System Events")]
        public UnityEvent onSwitchedScreen = new UnityEvent();

        [Header("Fader Properties")]
        public Image m_Fader;
        public float m_FadeInDuration = 1f;
        public float m_FadeOutDuration = 1f;

        private Component[] screens = new Component[0];
        private UI_Screen previousScreen;
        public UI_Screen PreviousScreen { get { return previousScreen; } }

        private UI_Screen currentScreen;
        public UI_Screen CurrentScreen { get { return currentScreen; } }
        #endregion

        #region Main Methods
        // Start is called before the first frame update
        void Start()
        {
            screens = GetComponentsInChildren<UI_Screen>(true);

            if(m_StartScreen)
            {
                SwitchScreens(m_StartScreen);
            }

            if(m_Fader)
            {
                m_Fader.gameObject.SetActive(true);
            }
            FadeIn();
        }
        #endregion

        #region Helper Methods
        public void SwitchScreens(UI_Screen aScreen)
        {
            if(aScreen)
            {
                if(currentScreen)
                {
                    currentScreen.CloseScreen();
                    previousScreen = currentScreen;
                }

                currentScreen = aScreen;
                currentScreen.gameObject.SetActive(true);
                currentScreen.StartScreen();

                if(onSwitchedScreen != null)
                {
                    onSwitchedScreen.Invoke();
                }
            }
        }

        public void FadeIn()
        {
            if(m_Fader)
            {
                m_Fader.CrossFadeAlpha(0f, m_FadeInDuration, false);
            }
        }

        public void FadeOut()
        {
            if(m_Fader)
            {
                m_Fader.CrossFadeAlpha(0f, m_FadeOutDuration, false);
            }
        }

        public void GoToPreviouseScreen()
        {
            if(previousScreen)
            {
                SwitchScreens(previousScreen);
            }
        }

        public void LoadScene(int sceneIndex)
        {
            StartCoroutine(WaitToLoadScene(sceneIndex));
        }

        IEnumerator WaitToLoadScene(int SceneIndex)
        {
            yield return null;
        }
        #endregion
    }
}
