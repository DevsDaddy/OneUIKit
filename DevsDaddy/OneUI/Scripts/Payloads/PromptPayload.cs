using System;
using DevsDaddy.Shared.EventFramework.Core.Payloads;

namespace DevsDaddy.OneUI.Scripts.Payloads
{
    [System.Serializable]
    public class PromptPayload : IPayload
    {
        public string Title = "";
        public string Description = "";
        public Action<string> OnConfirm;
    }
}