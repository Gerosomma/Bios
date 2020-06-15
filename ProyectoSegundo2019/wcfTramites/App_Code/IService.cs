using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using EntidadesCompartidas;
using System.Xml;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface IService
{
    //[OperationContract]
    //void ParaSerializar(Empleado emp, Solicitante soli, Tramite tram, Solicitud sol, Documentacion doc);
    //Solicitante ParaSerializarsol();
    //[OperationContract]
    //Tramite serTramite();
    //[OperationContract]
    //Solicitud serSoli();
    //[OperationContract]
    //Documentacion serDoc();
    //[OperationContract]
    string GetData(int value);

    [OperationContract]
    CompositeType GetDataUsingDataContract(CompositeType composite);

    #region LogicaUsuario

    [OperationContract]
    Usuario LogueoUsuario(int documento, string contraseana);
    [OperationContract]
    Usuario BuscarUsuario(int documento, Usuario usLog);
    [OperationContract]
    void AltaUsuario(Usuario usuario, Usuario usLog);
    [OperationContract]
    void ModificarUsuario(Usuario empleado, Empleado empLog);
    [OperationContract]
    void BajaUsuario(Usuario empleado, Empleado empLog);

    #endregion

    [OperationContract]
    Documentacion BuscarDocumentacion(int codigoInterno);
    [OperationContract]
    void AltaDocumentacion(Documentacion documentacion, Empleado empLog);
    [OperationContract]
    void ModificarDocumentacion(Documentacion documentacion, Empleado empLog);
    [OperationContract]
    void BajaDocumentacion(Documentacion documentacion, Empleado empLog);
    [OperationContract]
    List<Documentacion> listadoDocumentacion(Empleado empLog);


    [OperationContract]
    void AltaSolicitud(Solicitud solicitud, Usuario empLog);
    [OperationContract]
    List<Solicitud> listadoSolicitud(Usuario usLog);
    [OperationContract]
    Solicitud BuscarSolicitud(int documento, Usuario usLog);
    [OperationContract]
    void CambiarEstadoSolicitud(int solicitud, int accion, Empleado usLog);
    [OperationContract]
    Tramite BuscarTramite(string codigoTramite, Usuario empLog);
    [OperationContract]
    void AltaTramite(Tramite tramite, Empleado empLog);
    [OperationContract]
    void ModificarTramite(Tramite tramite, Empleado empLog);
    [OperationContract]
    void BajaTramite(Tramite tramite, Empleado empLog);
    [OperationContract]
    List<Tramite> ListarTramites();
    [OperationContract]
    string listadoTramitesXml();
    [OperationContract]
    void AltaHoraExtra(EmpleadoHorasExtra hemp, Empleado empLog);

}

// Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
[DataContract]
public class CompositeType
{
    bool boolValue = true;
    string stringValue = "Hello ";

    [DataMember]
    public bool BoolValue
    {
        get { return boolValue; }
        set { boolValue = value; }
    }

    [DataMember]
    public string StringValue
    {
        get { return stringValue; }
        set { stringValue = value; }
    }
}
