using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    [DataContract]
    public class Empleado : Usuario
    {
        private string _horaInicio;
        private string _horaFin;

        [DataMember]
        public string HoraInicio
        {
            get { return _horaInicio; }
            set
            {
                if (validarHora(value))
                    _horaInicio = value;
                else
                    throw new Exception("Hora inicio invalida");
            }
        }

        [DataMember]
        public string HoraFin
        {
            get { return _horaFin; }
            set
            {
                if (validarHora(value))
                    _horaFin = value;
                else
                    throw new Exception("Hora fin invalida");
            }
        }

        public Boolean validarHora(string hora)
        {
            Boolean bandera = false;
            try
            {
                string horas = hora.Substring(0, 2);
                string minutos = hora.Substring(3, 2);
                int h = Convert.ToInt32(horas);
                int m = Convert.ToInt32(minutos);
                if (h <= 24 && m < 60)
                {
                    bandera = true;
                }
                else
                {
                    bandera = false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return bandera;
        }

        public Empleado()
        { }

        public Empleado(int documento, string contrasenia, string nombreCompleto, string horaInicio, string horaFin)
            : base(documento, contrasenia, nombreCompleto)
        {
            HoraInicio = horaInicio;
            HoraFin = horaFin;
        }
    }
}

