using System;
using Com.Hide.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Com.Hide.Handler
{
    public class LoadingUIHandler : MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        
        [SerializeField] private Slider progressSlider;
        [SerializeField] private TMP_Text progressText;

        public void Show()
        {
            progressSlider.value = 0f;
            progressText.text = "0%";
            
            panel.SetActive(true);
        }

        public void Hide()
        {
            panel.SetActive(false);
        }
        
        public void UpdateProgress(float value)
        {
            progressSlider.value = value;
            progressText.text = $"{value * 100f:##.#}%";
        }
    }
}