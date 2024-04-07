using DevsDaddy.OneUI.Scripts.Payloads;
using DevsDaddy.Shared.EventFramework;
using DevsDaddy.Shared.UIFramework.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DevsDaddy.OneUI.Views
{
    /// <summary>
    /// Search View
    /// </summary>
    public class SearchView : BaseView
    {
        [Header("Search Window Content References")]
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
            EventMessenger.Main.Subscribe<SearchPayload>(OnWindowRequested);
        }

        /// <summary>
        /// Unbind Events
        /// </summary>
        private void UnbindEvents() {
            EventMessenger.Main.Unsubscribe<SearchPayload>(OnWindowRequested);
        }
        
        /// <summary>
        /// On Window Requested
        /// </summary>
        /// <param name="payload"></param>
        private void OnWindowRequested(SearchPayload payload) {
            ApplyButton.interactable = false;
            ApplyButton.onClick.RemoveAllListeners();
            ApplyButton.onClick.AddListener(() => {
                payload.OnRequestFormed?.Invoke(Field.text);
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