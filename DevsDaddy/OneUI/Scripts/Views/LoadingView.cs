using DevsDaddy.OneUI.Scripts.Payloads;
using DevsDaddy.Shared.EventFramework;
using DevsDaddy.Shared.UIFramework.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DevsDaddy.OneUI.Views
{
    /// <summary>
    /// Loading View
    /// </summary>
    public class LoadingView : BaseView
    {
        [Header("Loading View Preferences")]
        [SerializeField] private Slider progressSlider;
        [SerializeField] private TextMeshProUGUI title;
        
        /// <summary>
        /// On View Awake
        /// </summary>
        public override void OnViewAwake() {
            SetAsGlobalView();
            BindEvents();
        }

        /// <summary>
        /// On View Started
        /// </summary>
        public override void OnViewStart() {
            UpdateProgress(0);
            UpdateText("");
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
            EventMessenger.Main.Subscribe<LoadingPayload>(OnLoadingViewRequested);
        }

        /// <summary>
        /// Unbind Events
        /// </summary>
        private void UnbindEvents() {
            EventMessenger.Main.Unsubscribe<LoadingPayload>(OnLoadingViewRequested);
        }

        /// <summary>
        /// Update Loading Progress
        /// </summary>
        private void UpdateProgress(int progress) {
            progressSlider.value = progress;
        }

        /// <summary>
        /// Update Loading Text
        /// </summary>
        /// <param name="text"></param>
        private void UpdateText(string text = "") {
            if(title == null) return;
            text = string.IsNullOrEmpty(text) ? "Loading. Please, wait..." : text;
            title.SetText(text);
        }
        
        /// <summary>
        /// On Loading View Requested
        /// </summary>
        /// <param name="payload"></param>
        private void OnLoadingViewRequested(LoadingPayload payload) {
            if(IsVisible() == payload.IsVisible) return;
            
            if(payload.IsVisible)
                ShowView(new DisplayOptions { IsAnimated = true });
            else
                HideView(new DisplayOptions { IsAnimated = false });
            
            UpdateProgress(payload.Progress);
            UpdateText(payload.Text);
        }
    }
}