using DevsDaddy.Shared.UIFramework;
using DevsDaddy.Shared.UIFramework.Core;
using DevsDaddy.Shared.UIFramework.Payloads;
using UnityEngine;
using UnityEngine.UI;

namespace DevsDaddy.OneUI.Views
{
    /// <summary>
    /// Welcome View
    /// </summary>
    public class WelcomeView : BaseView
    {
        [Header("View Setup")] 
        [SerializeField] private Button GetStartedButton;
        
        /// <summary>
        /// On View Awake
        /// </summary>
        public override void OnViewAwake() {
            OnViewShown += Canvas.ForceUpdateCanvases;
        }

        /// <summary>
        /// On View Started
        /// </summary>
        public override void OnViewStart() {
            GetStartedButton.onClick.AddListener(OnStartClicked);
        }
        
        /// <summary>
        /// On View Destroy
        /// </summary>
        public override void OnViewDestroy() {
            GetStartedButton.onClick.RemoveListener(OnStartClicked);
        }

        /// <summary>
        /// On Start Clicked
        /// </summary>
        private void OnStartClicked() {
            HideView(new DisplayOptions { IsAnimated = true });
            UIFramework.GetView<HomeView>().ShowView(new DisplayOptions { IsAnimated = true });
        }
    }
}