using FireDAC.Stan;
using System.Classes;

namespace FireDAC.Phys
{
    public interface IFDStanObject
    {
        
    }

    public interface IFDPhysDriverMetadata
    {
        string GetBaseDriverID();
        string GetBaseDrvID();
        string GetBaseDrvDesc();
        int GetDbKind();

        string DriverID { get; }
        string BaseDriverID { get; }
        string BaseDriverDesc { get; }
        int RDBMSKind { get; }
    }

    public enum TFDPhysDriverState { cdrsUnknown, drsRegistered, drsLoading, drsLoaded };

    public interface IFDPhysDriver
    {
        void CreateConnection(IFDStanConnectionDef AConnectionDef, out IFDPhysConnection AConn);
        void CloseConnectionDef(IFDStanConnectionDef AConnectionDef);
        string DriverID { get; }
        string BaseDriverID { get; }
        TFDPhysDriverState State { get; }
    }

    public interface IFDStanDefinition
    {
        TStrings Params { get; set; }
        string Name { get; set; }
        IFDStanDefinition ParentDefinition { get; set; }
    }

    public interface IFDPhysConnection
    {
        void Open();
        void Close();
    }

    public interface IFDPhysManager
    {
        IFDStanConnectionDefs GetConnectionDefs();
        IFDStanConnectionDefs ConnectionDefs { get; }
    }
}