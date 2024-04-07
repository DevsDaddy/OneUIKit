using DevsDaddy.Shared.EventFramework.Core.Payloads;

namespace DevsDaddy.OneUI.Scripts.Payloads
{
    [System.Serializable]
    public class PreloaderPayload : IPayload
    {
        public bool IsVisible;
    }
}