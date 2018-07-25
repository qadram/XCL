using System.Classes;

namespace FireDAC.Stan
{
    public interface IFDStanDefinition
    {
        string GetAsString(string AName);
        void SetAsString(string AName, string AValue);
        bool GetAsBoolean(string AName);
        void SetAsBoolean(string AName, bool AValue);
        int GetAsInteger(string AName);
        IFDStanDefinition ParentDefinition { get; set; }
    }

    public class TFDStringList: TStringList
    {
        
    }

    public class TFDConnectionDefParams: TFDStringList
    {
        private string GetDriverID()
        {
            return "";
        }

        private void SetDriverID(string AValue)
        {
            
        }

        private string GetDatabase()
        {
            return "";
        }

        private void SetDatabase(string AValue)
        {
            
        }

        private string GetUserName()
        {
            return "";
        }

        private void SetUserName(string AValue)
        {
            
        }

        private string GetPassword()
        {
            return "";
        }

        private void SetPassword(string AValue)
        {
            
        }

        protected IFDStanDefinition FDef;

        private string GetConnectionDef()
        {
            return FDef.GetAsString("ConnectionDef");
        }

        private void SetConnectionDef(string AValue)
        {
            
        }

        public string ConnectionDef
        {
            get { return GetConnectionDef(); }
            set { SetConnectionDef(value); }
        }

        public string DriverID
        {
            get { return GetDriverID(); }
            set { SetDriverID(value); }
        }

        public string Database
        {
            get { return GetDatabase(); }
            set { SetDatabase(value); }
        }

        public string UserName
        {
            get { return GetUserName(); }
            set { SetUserName(value); }
        }

        public string Password
        {
            get { return GetPassword();  }
            set { SetPassword(value); }
        }                     
    }

    public interface IFDStanDefinitions
    {
        
    }

    public interface IFDStanConnectionDef : IFDStanDefinition
    {
        TFDConnectionDefParams GetConnectionDefParams();
        void SetConnectionDefParams(TFDConnectionDefParams AParams);
        TFDConnectionDefParams Params { get; set; }
    }

    public interface IFDStanConnectionDefs : IFDStanDefinitions
    {
        IFDStanConnectionDef ConnectionDefByName(string AName);
        IFDStanConnectionDef FindConnectionDef(string AName);
    }

    public class TFDComponent: TComponent
    {
        // Empty class
        public TFDComponent(TComponent AOwner) : base(AOwner)
        {
            
        }
    }
}