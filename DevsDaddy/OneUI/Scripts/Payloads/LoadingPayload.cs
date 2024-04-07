using DevsDaddy.Shared.EventFramework.Core.Payloads;

namespace DevsDaddy.OneUI.Scripts.Payloads
{
    [System.Serializable]
    public class LoadingPayload : IPayload
    {
        public bool IsVisible = false;
        public int Progress = 0;
        public string Text = "";
    }
}