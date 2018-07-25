namespace FireDAC.Stan
{
    public class TFDTopResourceOptions
    {
        private bool FAutoConnect;

        private bool GetAutoConnect()
        {
            return true;
        }

        private void SetAutoConnect(bool AValue)
        {
            
        }
        public bool AutoConnect { get { return GetAutoConnect(); } set { SetAutoConnect(value); } }
    }
}