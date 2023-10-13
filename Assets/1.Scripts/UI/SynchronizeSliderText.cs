using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Com.Hide.UI
{
    public class SynchronizeSliderText : MonoBehaviour
    {
        public float Value { get; private set; }
        public UnityAction<float> OnValueChanged;

        [SerializeField] private TMP_Text valueText;
        [SerializeField] private bool isInt = true;
        [SerializeField] private float normalizedValue = 100f;
        
        private Slider _cachedSlider;

        private void Start()
        {
            _cachedSlider.onValueChanged.AddListener(UpdateValueText);
            _cachedSlider.onValueChanged.AddListener((v) => OnValueChanged(v));
        }

        public void UpdateValueText(float v)
        {
            if(_cachedSlider == null)
                _cachedSlider = GetComponent<Slider>();

            _cachedSlider.value = v;
            Value = v;
            valueText.text = $"{(isInt ? (int)(v * normalizedValue) : string.Format($"{v * normalizedValue:F1}"))}";
        }
    }
}