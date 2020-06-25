using System;
using System.Runtime.Serialization;

namespace EntidadesCompartidas
{
    [DataContract]
    public class Solicitante : Usuario
    {
        private int _telefono;

        [DataMember]
        public int Telefono
        {
            get { return _telefono; }
            set
            {
                if (value > 1)
                    _telefono = value;
                else
                    throw new Exception("El numero de telefono es invalido");
            }
        }

        public Solicitante()
        { }

        public Solicitante(int documento, string contrasenia, string nombreCompleto, int telefono)
            : base(documento, contrasenia, nombreCompleto)
        {
            Telefono = telefono;
        }
    }
}
