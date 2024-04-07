using DevsDaddy.OneUI.Scripts.Payloads;
using DevsDaddy.Shared.EventFramework;
using DevsDaddy.Shared.UIFramework.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DevsDaddy.OneUI.Views
{
    /// <summary>
    /// Prompt View
    /// </summary>
    public class PromptView : BaseView
    {
        [Header("Window Content References")] 
        [SerializeField] private TextMeshProUGUI Title;
        [SerializeField] private TextMeshProUGUI Message;
        [SerializeField] private TMP_InputField Field;
        [SerializeField] private Button ApplyButton;
        
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
            EventMessenger.Main.Subscribe<PromptPayload>(OnWindowRequested);
        }

        /// <summary>
        /// Unbind Events
        /// </summary>
        private void UnbindEvents() {
            EventMessenger.Main.Unsubscribe<PromptPayload>(OnWindowRequested);
        }
        
        /// <summary>
        /// On Window Requested
        /// </summary>
        /// <param name="payload"></param>
        private void OnWindowRequested(PromptPayload payload) {
            Title.SetText(payload.Title);
            Message.SetText(payload.Description);
            ApplyButton.interactable = false;
            ApplyButton.onClick.RemoveAllListeners();
            ApplyButton.onClick.AddListener(() => {
                payload.OnConfirm?.Invoke(Field.text);
                HideView(new DisplayOptions { IsAnimated = true });
            });
            Field.onValueChanged.RemoveAllListeners();
            Field.onValueChanged.AddListener(text => {
                ApplyButton.interactable = !string.IsNullOrEmpty(text);
            });

            // Show Window
            if(IsVisible()) return;
            ShowView(new DisplayOptions { IsAnimated = true });
        }
    }
}