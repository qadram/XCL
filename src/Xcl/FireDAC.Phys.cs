using FireDAC.Stan;

namespace FireDAC.Phys
{
    public class TFDPhysDriver: IFDStanObject, IFDPhysDriver, IFDPhysDriverMetadata
    {
        protected string GetDriverID()
        {
            return FDriverID;
        }

        public virtual string GetBaseDriverID()
        {
            return sGetBaseDriverID();
        }

        public virtual string GetBaseDriverDesc()
        {
            return sGetBaseDriverDesc();
        }

        // Need to implement these static methods in descendents classes
        // C# doesn't allow static methods to be virtual
        public static string sGetBaseDriverID()
        {
            return "";
        }

        public static string sGetBaseDriverDesc()
        {
            return "";
        }

        public string GetBaseDrvID()
        {
            return GetBaseDriverID();
        }

        public string GetBaseDrvDesc()
        {
            return GetBaseDriverDesc();
        }

        public int GetDbKind()
        {
            return -1;
        }

        public void CreateConnection(IFDStanConnectionDef AConnectionDef, out IFDPhysConnection AConn)
        {
            AConn = null;
        }

        public void CloseConnectionDef(IFDStanConnectionDef AConnectionDef)
        {
        }

        private string FDriverID;
        public string DriverID { get { return FDriverID; } }
        public string BaseDriverID { get { return GetBaseDrvID(); } set { FDriverID = value; }}
        public TFDPhysDriverState State { get; }
        public string BaseDriverDesc { get; set; }
        public int RDBMSKind { get; }
    }

    public class TFDPhysConnection: IFDPhysConnection
    {
        public void Open() { }
        public void Close() { }
    }
}