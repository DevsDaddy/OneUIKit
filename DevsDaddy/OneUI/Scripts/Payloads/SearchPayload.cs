using System;
using DevsDaddy.Shared.EventFramework.Core.Payloads;

namespace DevsDaddy.OneUI.Scripts.Payloads
{
    [System.Serializable]
    public class SearchPayload : IPayload
    {
        public Action<string> OnRequestFormed;
    }
}