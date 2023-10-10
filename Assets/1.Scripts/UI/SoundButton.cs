using System.Collections;
using System.Collections.Generic;
using Com.Hide.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Com.Hide.UI
{
    public class SoundButton : Button
    {
        [Header("Sound")] 
        [SerializeField] private AudioClip clickSound;
        [SerializeField] private AudioClip hoverSound;
        [SerializeField] private AudioClip unHoverSound;

        [SerializeField] private AudioSource audioSource;

        private TMP_Text _buttonText;

        protected override void Awake()
        {
            base.Awake();

            _buttonText = GetComponentInChildren<TMP_Text>(true);
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            if (audioSource == null)
                audioSource = FindObjectOfType<AudioSource>(true);
        }

        public void ChangeText(string msg)
        {
            _buttonText.text = msg;
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            if (clickSound != null)
                audioSource.PlayOneShot(clickSound);

            base.OnPointerClick(eventData);
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            if (hoverSound != null)
                audioSource.PlayOneShot(hoverSound);

            base.OnPointerEnter(eventData);
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            if (unHoverSound != null)
                audioSource.PlayOneShot(unHoverSound);

            base.OnPointerExit(eventData);
        }

        protected override void OnDestroy()
        {
            onClick?.RemoveAllListeners();
        }
    }
}