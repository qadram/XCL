using System.Base;
using System.Classes;
using System.Generics.Collections;

namespace Data.DB
{
    public class TCustomConnection : TComponent
    {
        private TList<TObject> FClients;
        private TList<TDataSet> FDataSets;
        private bool FLoginPrompt = false;
        private TNotifyEvent FAfterConnect;
        private TNotifyEvent FAfterDisconnect;
        private TNotifyEvent FBeforeConnect;
        private TNotifyEvent FBeforeDisconnect;
        // private TLoginEvent FOnLogin;

        protected virtual void DoConnect()
        {
        }

        protected virtual void DoDisconnect()
        {

        }

        protected virtual bool GetConnected()
        {
            return false;
        }

        protected virtual TDataSet GetDataSet(int Index)
        {
            return null;

        }

        protected virtual int GetDataSetCount()
        {
            return -1;
        }

        public override void Loaded()
        {

        }

        protected virtual void SetConnected(bool Value)
        {

        }

        protected void SendConnectEvent(bool Connecting)
        {

        }

        public TCustomConnection(TComponent AOwner) : base(AOwner)
        {

        }

        //public override Dispose()

        public void Open()
        {

        }

        public void Close()
        {

        }

        public bool Connected { get => GetConnected(); set => SetConnected(value); }

        public bool LoginPrompt { get => FLoginPrompt; set => FLoginPrompt = value; }

        public TNotifyEvent AfterConnect { get => FAfterConnect; set => FAfterConnect = value; }

        public TNotifyEvent BeforeConnect { get => FBeforeConnect; set => FBeforeConnect = value; }

        public TNotifyEvent AfterDisconnect { get => FAfterDisconnect; set => FAfterDisconnect = value; }

        public TNotifyEvent BeforeDisconnect { get => FBeforeDisconnect; set => FBeforeDisconnect = value; }

        //public TNotifyEvent OnLogin { get => FOnLogin; set => FOnLogin = value; }
    }

    public class TDataSet: TComponent
    {
        public TDataSet(TComponent AOwner): base(AOwner)
        {
            
        }        
    }
}