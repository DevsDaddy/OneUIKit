using DevsDaddy.Shared.UIFramework.Core;
using UnityEngine;
using UnityEngine.UI;

namespace DevsDaddy.OneUI.Views
{
    /// <summary>
    /// More Menu View
    /// </summary>
    public class MoreMenuView : BaseView
    {
        [Header("Menu General Preferences")]
        [SerializeField] private Button CloseButton;

        [Header("Menu Elements")] 
        [SerializeField] private Button CheckUpdates;
        [SerializeField] private Button DocumentationButton;
        [SerializeField] private Button BuyBeerButton;
        [SerializeField] private Button BlogButton;
        [SerializeField] private Button DiscordButton;
        
        /// <summary>
        /// On View Started
        /// </summary>
        public override void OnViewStart() {
            BindGeneralButtons();
        }
        
        /// <summary>
        /// On View Destroy
        /// </summary>
        public override void OnViewDestroy() {
            UnbindGeneralButtons();
        }
        
        /// <summary>
        /// Bind General Buttons Events
        /// </summary>
        private void BindGeneralButtons() {
            CloseButton.onClick.AddListener(() => {
                HideView(new DisplayOptions { IsAnimated = true });
            });
            
            DocumentationButton.onClick.AddListener(() => {
                HideView(new DisplayOptions { IsAnimated = true });
                Application.OpenURL("https://github.com/DevsDaddy/OneUIKit");
            });
            BlogButton.onClick.AddListener(() => {
                HideView(new DisplayOptions { IsAnimated = true });
                Application.OpenURL("https://devsdaddy.hashnode.dev/");
            });
            BuyBeerButton.onClick.AddListener(() => {
                HideView(new DisplayOptions { IsAnimated = true });
                Application.OpenURL("https://boosty.to/devsdaddy");
            });
            DiscordButton.onClick.AddListener(() => {
                HideView(new DisplayOptions { IsAnimated = true });
                Application.OpenURL("https://discord.gg/xuNTKRDebx");
            });
            CheckUpdates.onClick.AddListener(() => {
                HideView(new DisplayOptions { IsAnimated = true });
                Application.OpenURL("https://github.com/DevsDaddy/OneUIKit/releases");
            });
        }

        /// <summary>
        /// Unbind General Buttons Events
        /// </summary>
        private void UnbindGeneralButtons() {
            CloseButton.onClick.RemoveAllListeners();
            DocumentationButton.onClick.RemoveAllListeners();
            BlogButton.onClick.RemoveAllListeners();
            BuyBeerButton.onClick.RemoveAllListeners();
            DiscordButton.onClick.RemoveAllListeners();
            CheckUpdates.onClick.RemoveAllListeners();
        }
    }
}