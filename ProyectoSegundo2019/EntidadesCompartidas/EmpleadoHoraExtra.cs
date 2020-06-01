using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    [DataContract]
    public class EmpleadoHorasExtra
    {
        private Empleado _empleado;
        private DateTime _fecha;
        private int _minutosExtra;

        [DataMember]
        public Empleado Empleado
        {
            get { return _empleado; }
            set
            {
                if (value == null)
                {
                    throw new Exception("El empleado no puede ser nulo.");
                }
                else
                {
                    _empleado = value;
                }
            }
        }

        [DataMember]
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        [DataMember]
        public int MinutosExtra
        {
            get { return _minutosExtra; }
            set
            {
                if (value >= 1)
                    _minutosExtra = value;
                else
                    throw new Exception("Los minutos extra deben ser mayores a 1");
            }
        }

        public EmpleadoHorasExtra() { }
        public EmpleadoHorasExtra(Empleado empleado, DateTime fecha, int minutosExtra)
        {
            Empleado = empleado;
            Fecha = fecha;
            MinutosExtra = minutosExtra;
        }
    }
}
