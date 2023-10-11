using UnityEngine;

namespace Com.Hide.UI
{
    public class WindowCanvas : MonoBehaviour
    {
        [SerializeField] protected GameObject dimmedPanel;
        [SerializeField] protected GameObject windowPanel;

        protected bool IsDisplayed { get; private set; }
        
        public void Show()
        {
            OnShow();

            dimmedPanel.SetActive(true);
            windowPanel.SetActive(true);

            IsDisplayed = true;
        }

        public void Hide()
        {
            dimmedPanel.SetActive(false);
            windowPanel.SetActive(false);

            OnHide();
            
            IsDisplayed = false;
        }

        protected virtual void OnShow()
        {
            
        }

        protected virtual void OnHide()
        {
            
        }
    }
}