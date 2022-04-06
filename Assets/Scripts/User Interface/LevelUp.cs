using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Isekai
{
    public class LevelUp : MonoBehaviour
    {
        public CanvasGroup canvasGroup;
        public float stayOnScreenTimer;
        public bool fadeIN;
        public float realTimer;

        private void Awake()
        {
            BaseStats.onLevelUp += ShowLevelUp;
        }
        private void Start()
        {
            realTimer = stayOnScreenTimer;
        }
        private void Update()
        {
            if (fadeIN)
            {
                FadeIn();
                Timer();
            }
            if(realTimer <= 0)
            {
                fadeIN = false;
            }
            if(fadeIN == false)
            {
                FadeOut();
                realTimer = stayOnScreenTimer;
            }
        }

        IEnumerator FadeOuting()
        {
            FadeOut();
            yield return new WaitForSeconds(2f);
            fadeIN = false;
            realTimer = stayOnScreenTimer;
        }
        void FadeIn()
        {
            canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, 1f, 2f * Time.deltaTime);
        }

        void FadeOut()
        {
            canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, 0f, 2f * Time.deltaTime);
        }

        void Timer()
        {
            realTimer-= Time.deltaTime;
        }

        private void ShowLevelUp()
        {
            fadeIN=true;
        }
    }
}
