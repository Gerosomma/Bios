using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace EntidadesCompartidas
{
    [DataContract]
    public class Solicitud
    {
        private int _numero;
        private string _estado;
        private DateTime _fechaHora;
        private Solicitante _solicitante;
        private Tramite _tramite;

        [DataMember]
        public int Numero
        {
            get { return _numero; }
            set
            {
                _numero = value;
            }
        }

        [DataMember]
        public string Estado
        {
            get { return _estado; }
            set
            {
                if (value.Trim().Length >= 0 && value.Trim().Length < 20)
                {
                    switch (value)
                    {
                        case "alta":
                            _estado = value;
                            break;
                        case "ejecutada":
                            _estado = value;
                            break;
                        case "anulada":
                            _estado = value;
                            break;
                        default:
                            throw new Exception("Estado de solicitud invalido");
                            break;
                    }
                }
                else
                {
                    throw new Exception("Estado de solicitud invalido");
                }
            }
        }

        [DataMember]
        public DateTime FechaHora
        {
            get { return _fechaHora; }
            set { _fechaHora = value; }
        }

        [DataMember]
        public Solicitante Solicitante
        {
            get { return _solicitante; }
            set
            {
                if (value == null)
                {
                    throw new Exception("El solicitante no puede ser nulo.");
                }
                else
                {
                    _solicitante = value;
                }
            }
        }

        [DataMember]
        public Tramite Tramite
        {
            get { return _tramite; }
            set
            {
                if (value == null)
                {
                    throw new Exception("El tipo de tramite no puede ser nulo.");
                }
                else
                {
                    _tramite = value;
                }
            }
        }

        public Solicitud()
        { }

        public Solicitud(string estado, DateTime fechaHora, Solicitante solicitante, Tramite tramite)
        {
            Estado = estado;
            FechaHora = fechaHora;
            Solicitante = solicitante;
            Tramite = tramite;
        }

        public Solicitud(int numero, string estado, DateTime fechaHora, Solicitante solicitante, Tramite tramite)
        {
            Numero = numero;
            Estado = estado;
            FechaHora = fechaHora;
            Solicitante = solicitante;
            Tramite = tramite;
        }
    }
}
