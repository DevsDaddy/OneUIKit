using System;
using DevsDaddy.Shared.EventFramework.Core.Payloads;

namespace DevsDaddy.OneUI.Scripts.Payloads
{
    [System.Serializable]
    public class ConfirmDialoguePayload : IPayload
    {
        public string Title = "";
        public string Description = "";
        public Action OnConfirm;
        public Action OnCancel;
        public Action OnClose;

        public bool ShowCancelButton;
        public bool ShowCloseButton;
    }
}