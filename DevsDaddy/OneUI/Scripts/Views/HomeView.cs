using DevsDaddy.OneUI.Scripts.Payloads;
using DevsDaddy.Shared.EventFramework;
using DevsDaddy.Shared.UIFramework;
using DevsDaddy.Shared.UIFramework.Core;
using DevsDaddy.Shared.UIFramework.Core.Components;
using UnityEngine;
using UnityEngine.UI;

namespace DevsDaddy.OneUI.Views
{
    /// <summary>
    /// Home View
    /// </summary>
    public class HomeView : BaseView
    {
        [Header("General Buttons")] 
        [SerializeField] private Button AvatarButton;
        [SerializeField] private Button SearchButton;
        [SerializeField] private Button MoreMenuButton;
        [SerializeField] private Button QuitButton;

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
            AvatarButton.onClick.AddListener(() => {
                EventMessenger.Main.Publish(new ConfirmDialoguePayload {
                    Title = "Are you Sure?",
                    Description = "Do you really want to change your avatar?",
                    OnConfirm = () => {
                        AvatarButton.gameObject.GetComponent<WebImage>().LoadImage();
                    },
                    ShowCancelButton = true,
                    ShowCloseButton = true
                });
            });
            SearchButton.onClick.AddListener(() => {
                EventMessenger.Main.Publish(new SearchPayload {
                    OnRequestFormed = (searchRequest) => {
                        EventMessenger.Main.Publish(new ConfirmDialoguePayload {
                            Title = "Your Search Request",
                            Description = $"Your Search Request is \"{searchRequest}\"",
                            OnConfirm = () => {
                                Debug.Log("It's just a demo of search request window.");
                            },
                            ShowCancelButton = false,
                            ShowCloseButton = false
                        });
                    }
                });
            });
            MoreMenuButton.onClick.AddListener(() => {
                UIFramework.GetView<MoreMenuView>().ShowView(new DisplayOptions { IsAnimated = true });
            });
            QuitButton.onClick.AddListener(() => {
                EventMessenger.Main.Publish(new ConfirmDialoguePayload {
                    Title = "Are you Sure?",
                    Description = "Do you really want to go to the home screen of the demo app?",
                    OnConfirm = () => {
                        HideView(new DisplayOptions { IsAnimated = true });
                        UIFramework.GetView<WelcomeView>().ShowView(new DisplayOptions { IsAnimated = true });
                    },
                    ShowCancelButton = true,
                    ShowCloseButton = true
                });
            });
        }

        /// <summary>
        /// Unbind General Buttons Events
        /// </summary>
        private void UnbindGeneralButtons() {
            AvatarButton.onClick.RemoveAllListeners();
            SearchButton.onClick.RemoveAllListeners();
            MoreMenuButton.onClick.RemoveAllListeners();
            QuitButton.onClick.RemoveAllListeners();
        }
    }
}