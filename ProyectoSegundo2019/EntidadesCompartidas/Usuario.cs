using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    [KnownType(typeof(Empleado))]
    [KnownType(typeof(Solicitante))]
    [DataContract]
    public class Usuario
    {
        private int _documento;
        private string _contrasenia;
        private string _nombreCompleto;
        //private Regex _expresion = new Regex(@"[a-zA-ZñÑ]{3}\d{2}[\|°¬¡!#$%&\/=()¿?'-_\\´{},;.:`+*~^<>@]");

        [DataMember]
        public int Documento
        {
            get { return _documento; }
            set
            {
                if (value < 1 || value > 999999999)
                    throw new Exception("Documento de usuario invalido");
                else
                    _documento = value;
            }
        }

        [DataMember]
        public string Contrasenia
        {
            get { return _contrasenia; }
            set
            {
                Regex _expresion = new Regex("[a-zA-ZñÑ]{3}[0-9]{2}[\\|°¬¡!#$%&\\/=()¿?'-_\\´{},;.:`+*~^<>@]");
                if ((value.Trim().Length > 6) || (value.Trim().Length <= 0))
                {
                    throw new Exception("La contraseña debe contener 6 caracteres en total.");
                }
                else if (!_expresion.IsMatch(value))
                {
                    throw new Exception("El formato de la contraseña no es válido.");
                }
                else
                {
                    _contrasenia = value;
                }
                //if (_expresion.IsMatch(value) && value.Trim().Length == 6) { _contrasenia = value; }
                //else { throw new Exception("El formato de la contraseña no es válido."); }
            }
        }

        [DataMember]
        public string NombreCompleto
        {
            get { return _nombreCompleto; }
            set
            {
                if ((value.Trim().Length > 50) || (value.Trim().Length <= 0))
                    throw new Exception("Error en Nombre cliente");
                else
                    _nombreCompleto = value;
            }
        }

        public Usuario()
        { }

        public Usuario(int documento, string contrasenia, string nombreCompleto)
        {
            Documento = documento;
            Contrasenia = contrasenia;
            NombreCompleto = nombreCompleto;
        }

    }
}
