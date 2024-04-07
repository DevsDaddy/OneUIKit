using DevsDaddy.OneUI.Scripts.Payloads;
using DevsDaddy.Shared.EventFramework;
using DevsDaddy.Shared.UIFramework.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DevsDaddy.OneUI.Views
{
    /// <summary>
    /// Pop-Up View
    /// </summary>
    public class PopupView : BaseView
    {
        [Header("Window Content References")] 
        [SerializeField] private TextMeshProUGUI Title;
        [SerializeField] private TextMeshProUGUI Message;
        [SerializeField] private Button ApplyButton;
        [SerializeField] private Button CancelButton;
        [SerializeField] private Button CloseButton;
        
        /// <summary>
        /// On View Awake
        /// </summary>
        public override void OnViewAwake() {
            SetAsGlobalView();
            BindEvents();
        }

        /// <summary>
        /// On View Destroy
        /// </summary>
        public override void OnViewDestroy() {
            UnbindEvents();
        }

        /// <summary>
        /// Bind Events
        /// </summary>
        private void BindEvents() {
            EventMessenger.Main.Subscribe<ConfirmDialoguePayload>(OnWindowRequested);
        }

        /// <summary>
        /// Unbind Events
        /// </summary>
        private void UnbindEvents() {
            EventMessenger.Main.Unsubscribe<ConfirmDialoguePayload>(OnWindowRequested);
        }
        
        /// <summary>
        /// On Window Requested
        /// </summary>
        /// <param name="payload"></param>
        private void OnWindowRequested(ConfirmDialoguePayload payload) {
            Title.SetText(string.IsNullOrEmpty(payload.Title) ? "Are you Sure?" : payload.Title);
            Message.SetText(payload.Description);
            ApplyButton.onClick.RemoveAllListeners();
            ApplyButton.onClick.AddListener(() => {
                payload.OnConfirm?.Invoke();
                HideView(new DisplayOptions { IsAnimated = true });
            });
            CancelButton.onClick.RemoveAllListeners();
            CancelButton.onClick.AddListener(() => {
                payload.OnCancel?.Invoke();
                HideView(new DisplayOptions { IsAnimated = true });
            });
            CloseButton.onClick.RemoveAllListeners();
            CloseButton.onClick.AddListener(() => {
                payload.OnClose?.Invoke();
                HideView(new DisplayOptions { IsAnimated = true });
            });
            
            // Change Visibility
            CancelButton.gameObject.SetActive(payload.ShowCancelButton);
            CloseButton.gameObject.SetActive(payload.ShowCloseButton);

            // Show Window
            if(IsVisible()) return;
            ShowView(new DisplayOptions { IsAnimated = true });
        }
    }
}