using System;
using DevsDaddy.Shared.EventFramework.Core.Payloads;

namespace DevsDaddy.OneUI.Scripts.Payloads
{
    [System.Serializable]
    public class ErrorPayload : IPayload
    {
        public string Title = "";
        public string Description = "";
        public Action OnConfirm;
        public Action OnCancel;
    }
}