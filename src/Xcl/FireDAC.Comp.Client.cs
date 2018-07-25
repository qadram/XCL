using System;
using System.Classes;
using Data.DB;
using FireDAC.Stan;
using FireDAC.Phys;
//using FireDAC.Phys.

namespace FireDAC.Comp
{
    public partial class _
    {
        public static TFDCustomManager FDManager { get { return TFDCustomManager.GetSingleton(); } }

        public static IFDPhysManager FDPhysManager { get { return null; }}
    }

    public class TFDCustomManager: TFDComponent
    {
        private static TFDCustomManager FSingleton;

        public TFDCustomManager(TComponent AOwner): base(AOwner)
        {
            
        }

        public static TFDCustomManager GetSingleton()
        {
            if (FSingleton == null)
            {
                FSingleton = new TFDCustomManager(null);
            }
            return FSingleton;
        }

        private void SetActive(Boolean AValue)
        {
            
        }

        private Boolean GetActive()
        {
            return false;
        }

        public Boolean Active { get { return GetActive(); } set { SetActive(value); } }

        private TFDTopResourceOptions GetResourceOptions()
        {
            return null;
        }

        private void SetResourceOptions(TFDTopResourceOptions AValue)
        {
            
        }

        public  TFDTopResourceOptions ResourceOptions { get { return GetResourceOptions(); } set { SetResourceOptions(value); } }

        private IFDStanConnectionDefs GetConnectionDefs()
        {
            return null;
        }

        public IFDStanConnectionDefs ConnectionDefs { get { return GetConnectionDefs(); } }

        public void Open()
        {
            Active = true;
        }

        public void CheckActive()
        {
            if (!Active)
                if (ResourceOptions.AutoConnect)
                    Open();
        }
    }

    public class TFDManager: TFDCustomManager
    {
        public TFDManager(TComponent AOwner): base(AOwner)
        {
            
        }        
    }

    public class TFDCustomConnection: TCustomConnection
    {
        private IFDStanConnectionDef FParams;
        private IFDPhysConnection FConnectionIntf;

        public IFDStanConnectionDef Params
        {
            get
            {
                return FParams;
            }
            set
            {
                FParams = value;
            }
        }

        public TFDCustomConnection(TComponent AOwner): base(AOwner)
        {
            
        }

        private void DoInternalLogin()
        {
            
        }

        private void PrepareConnectionDef(bool ACheckDef)
        {
            if ((ConnectionDefName != "") || (ConnectionName != ""))
                _.FDManager.CheckActive();

            FParams.ParentDefinition = null;
            if (ConnectionDefName != "")
            {
                if (ACheckDef)
                    FParams.ParentDefinition = _.FDManager.ConnectionDefs.ConnectionDefByName(ConnectionDefName);
                else
                    FParams.ParentDefinition = _.FDManager.ConnectionDefs.FindConnectionDef(ConnectionDefName);
            }
            else 
                if (ConnectionName != "")
                    FParams.ParentDefinition = _.FDManager.ConnectionDefs.FindConnectionDef(ConnectionName);
        }

        public virtual void CheckConnectionDef()
        {
            PrepareConnectionDef(true);
            if (FParams.Params.DriverID == "")
                throw new Exception("Wrong parameters");
        }

        private void AcquireConnectionInf(out IFDPhysConnection AConnIntf)
        {
            CheckConnectionDef();
            AConnIntf = null;
        }

        protected override void DoConnect()
        {
            if(!Connected)
            {
                base.DoConnect();
                AcquireConnectionInf(out FConnectionIntf);
                //LoginPrompt stuff
                DoInternalLogin();
            }
        }

        private void SetConnectionName(string AName)
        {
            
        }

        private string FConnectionName;
        public string ConnectionName
        {
            get { return FConnectionName; }
            set { SetConnectionName(value); }
        }

        private string GetConnectionDefName()
        {
            return FParams.Params.ConnectionDef;
        }

        private void SetConnectionDefName(string AName)
        {
            
        }

        public string ConnectionDefName
        {
            get { return GetConnectionDefName(); }
            set { SetConnectionDefName(value); }
        }
    }

    public class TFDConnection: TFDCustomConnection
    {
        public TFDConnection(TComponent AOwner): base(AOwner)
        {
                        
        }        
    }
}