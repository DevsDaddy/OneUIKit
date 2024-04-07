using DevsDaddy.OneUI.Scripts.Payloads;
using DevsDaddy.Shared.EventFramework;
using DevsDaddy.Shared.UIFramework.Core;

namespace DevsDaddy.OneUI.Views
{
    /// <summary>
    /// Preloader View
    /// </summary>
    public class PreloaderView : BaseView
    {
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
            EventMessenger.Main.Subscribe<PreloaderPayload>(OnPreloaderRequested);
        }

        /// <summary>
        /// Unbind Events
        /// </summary>
        private void UnbindEvents() {
            EventMessenger.Main.Unsubscribe<PreloaderPayload>(OnPreloaderRequested);
        }

        /// <summary>
        /// On Preloader Requested
        /// </summary>
        /// <param name="payload"></param>
        private void OnPreloaderRequested(PreloaderPayload payload) {
            if(IsVisible() == payload.IsVisible) return;
            
            if(payload.IsVisible)
                ShowView(new DisplayOptions { IsAnimated = true });
            else
                HideView(new DisplayOptions { IsAnimated = false });
        }
    }
}