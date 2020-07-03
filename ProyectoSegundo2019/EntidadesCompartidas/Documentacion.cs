using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    [DataContract]
    public class Documentacion
    {
        private int _codigoInterno;
        private string _nomDocumentacion;
        private string _lugar;
        private bool _activo;

        [DataMember]
        public int CodigoInterno
        {
            get { return _codigoInterno; }
            set
            {
                if (value > 0)
                    _codigoInterno = value;
                else
                    throw new Exception("El codigo interno no puede ser negativo");
            }
        }

        [DataMember]
        public string NomDocumentacion
        {
            get { return _nomDocumentacion; }
            set
            {
                if (value.Trim().Length > 0 && value.Trim().Length <= 50)
                    _nomDocumentacion = value;
                else
                    throw new Exception("Nombre de documentacion invalido");
            }
        }

        [DataMember]
        public string Lugar
        {
            get { return _lugar; }
            set
            {
                if (value.Trim().Length > 0 && value.Trim().Length <= 50)
                    _lugar = value;
                else
                    throw new Exception("Lugar de documentacion invalido");
            }
        }

        [DataMember]
        public bool Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }
        public Documentacion()
        { }

        public Documentacion(int codigoInterno, string nomDocumentacion, string lugar, bool activo)
        {
            CodigoInterno = codigoInterno;
            NomDocumentacion = nomDocumentacion;
            Lugar = lugar;
            Activo = activo;
        }
    }
}

