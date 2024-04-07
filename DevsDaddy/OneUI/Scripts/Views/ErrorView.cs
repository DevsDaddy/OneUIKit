using DevsDaddy.OneUI.Scripts.Payloads;
using DevsDaddy.Shared.EventFramework;
using DevsDaddy.Shared.UIFramework.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DevsDaddy.OneUI.Views
{
    /// <summary>
    /// Error View
    /// </summary>
    public class ErrorView : BaseView
    {
        [Header("Window Content References")] 
        [SerializeField] private TextMeshProUGUI Title;
        [SerializeField] private TextMeshProUGUI Message;
        [SerializeField] private Button ApplyButton;
        [SerializeField] private Button CancelButton;
        
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
            EventMessenger.Main.Subscribe<ErrorPayload>(OnWindowRequested);
        }

        /// <summary>
        /// Unbind Events
        /// </summary>
        private void UnbindEvents() {
            EventMessenger.Main.Unsubscribe<ErrorPayload>(OnWindowRequested);
        }

        /// <summary>
        /// On Window Requested
        /// </summary>
        /// <param name="payload"></param>
        private void OnWindowRequested(ErrorPayload payload) {
            Title.SetText(string.IsNullOrEmpty(payload.Title) ? "Unknown Error" : payload.Title);
            Message.SetText(string.IsNullOrEmpty(payload.Description) ? "An Unknown Error occured at game process. Please, try again later." : payload.Description);
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
            
            // Show Window
            if(IsVisible()) return;
            ShowView(new DisplayOptions { IsAnimated = true });
        }
    }
}