using System;
using System.Collections.Generic;
using Com.Hide.Utils;
using TMPro;
using UnityEngine;

namespace Com.Hide.Dialog
{
    public abstract class Dialog<T> : SingletonMonoBehaviour<T>
    {
        [SerializeField] protected GameObject dimmedPanel;
        [SerializeField] protected GameObject windowPanel;
        
        [SerializeField] protected TMP_Text titleText;
        [SerializeField] protected TMP_Text contentText;

        private Queue<Message> _storedMessages = new();
        private bool _isShow = false;

        public void Show(string title, string msg)
        {
            if(_isShow)
            {
                _storedMessages.Enqueue(new Message(title, msg));
                return;
            }
            
            _isShow = true;

            titleText.SetText(title);
            contentText.SetText(msg);
            
            dimmedPanel.SetActive(true);
            windowPanel.SetActive(true);
            
            OnShow();
        }

        public void Hide()
        {
            _isShow = false;

            dimmedPanel.SetActive(false);
            windowPanel.SetActive(false);
            
            OnHide();
            
            if (_storedMessages.Count <= 0) return;

            var m = _storedMessages.Dequeue();
            Show(m.Title, m.Msg);
        }

        protected virtual void OnShow()
        {
        }

        protected virtual void OnHide()
        {
        }
    }
}