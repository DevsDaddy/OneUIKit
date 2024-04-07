using DevsDaddy.OneUI.Views;
using DevsDaddy.Shared.UIFramework;
using UnityEngine;

namespace DevsDaddy.OneUI.Demo
{
    /// <summary>
    /// Scene Basic Controller
    /// </summary>
    internal class SceneController : MonoBehaviour
    {
        // Application Quit Flag
        private bool isQuitting = false;

        /// <summary>
        /// On Scene Controller Awake
        /// </summary>
        private void Awake() {
            BindEvents();
        }

        /// <summary>
        /// On Scene Controller Started
        /// </summary>
        private void Start() {
            BindViews();
        }

        /// <summary>
        /// On Scene Controller Destroy
        /// </summary>
        private void OnDestroy() {
            if(!isQuitting) return;
            UnbindEvents();
        }

        /// <summary>
        /// On Application Quit
        /// </summary>
        private void OnApplicationQuit() {
            isQuitting = true;
        }

        /// <summary>
        /// Bind Events
        /// </summary>
        private void BindEvents() {
            
        }

        /// <summary>
        /// Unbind Events
        /// </summary>
        private void UnbindEvents() {
            
        }

        /// <summary>
        /// Bind Views
        /// </summary>
        private void BindViews() {
            UIFramework.BindView(FindObjectOfType<WelcomeView>());
            UIFramework.BindView(FindObjectOfType<HomeView>());
            UIFramework.BindView(FindObjectOfType<MoreMenuView>());
        }
    }
}
