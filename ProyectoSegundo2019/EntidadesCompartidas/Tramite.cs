using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;

namespace EntidadesCompartidas
{
    [DataContract]
    public class Tramite
    {
        private string _codigoTramite;
        private string _nombreTramite;
        private string _descripcion;
        private decimal _precio;
        private List<Documentacion> _documentacionExigida = new List<Documentacion>();
        
        [DataMember]
        public string CodigoTramite
        {
            get { return _codigoTramite; }
            set
            {
                if (value.Trim().Length > 9 || value.Trim().Length <= 0)
                {
                    throw new Exception("El codigo debe tener 9 caracteres en total.");
                }
                else
                {
                    Regex _expresion = new Regex("[0-9]{4}[a-zA-ZñÑ]{5}");
                    if (_expresion.IsMatch(value))
                    {
                        _codigoTramite = value;
                    }
                    else
                    {
                        throw new Exception("El codigo debe contener 4 numeros (año) y 5 caracteres.");
                    }
                }
            }
        }

        [DataMember]
        public string NombreTramite
        {
            get { return _nombreTramite; }
            set
            {
                if (value.Trim().Length > 1 && value.Trim().Length <= 50)
                    _nombreTramite = value;
                else
                    throw new Exception("El nombre de tramite es invalido");
            }
        }

        [DataMember]
        public string Descripcion
        {
            get { return _descripcion; }
            set
            {
                if (value.Trim().Length <= 80)
                    _descripcion = value;
                else
                    throw new Exception("La descripcion de tramite supera el limite");
            }
        }

        [DataMember]
        public decimal Precio
        {
            get { return _precio; }
            set
            {
                if (value >= 0)
                    _precio = value;
                else
                    throw new Exception("El precio de un tramite no puede ser negativo");
            }
        }

        [DataMember]
        public List<Documentacion> DocumentacionExigida
        {
            get { return _documentacionExigida; }
            set
            {
                if (value == null)
                {
                    throw new Exception("El trámite no exige ninguna documentación.");
                }
                else
                {
                    _documentacionExigida = value;
                }
            }
        }

        public Tramite()
        { }

        public Tramite(string codigoTramite, string nombreTramite, string descripcion, decimal precio, List<Documentacion> documentacionExigida)
        {
            CodigoTramite = codigoTramite;
            NombreTramite = nombreTramite;
            Descripcion = descripcion;
            Precio = precio;
            DocumentacionExigida = documentacionExigida;
        }
    }
}
