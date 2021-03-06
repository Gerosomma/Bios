﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BackOfficeTramites.wcfTramite;
using MisControles;

namespace BackOfficeTramites
{
    public partial class frmABMEmpleado : Form
    {
        private Empleado empleadoLogueado = null;
        private Empleado objEmpleado = null;

        public frmABMEmpleado(Empleado Empleado)
        {
            InitializeComponent();
            empleadoLogueado = Empleado;
        }

        private void TxtNumero_Validating(object sender, CancelEventArgs e)
        {
            if (TxtNumero.Text.Trim() != "")
            {
                buscarEmpleado(TxtNumero.Text);
            }
            else
            {
                LblError.Text = "No ingreso documento.";
            }
        }

        private void BtnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                Empleado empleado = new Empleado();
                empleado.Documento = Convert.ToInt32(TxtNumero.Text);
                empleado.Contrasenia = TxtPassword.Text.Trim();
                empleado.NombreCompleto = TxtNombre.Text.Trim();
                empleado.HoraInicio = dtpInicio.Value.TimeOfDay.ToString();
                empleado.HoraFin = dtpFin.Value.TimeOfDay.ToString();

                ServiceClient wcf = new ServiceClient();
                wcf.AltaUsuario(empleado, empleadoLogueado);
                this.DesActivoBotones();
                this.LimpioControles();

                TxtNumero.Enabled = true;
                TxtNumero.ReadOnly = false;

                LblError.Text = "Alta con Exito";
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
            }
        }

        private void BtnBaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (objEmpleado != null)
                {
                    ServiceClient wcf = new ServiceClient();
                    wcf.BajaUsuario(objEmpleado, empleadoLogueado);
                    this.DesActivoBotones();
                    this.LimpioControles();
                    TxtNumero.Enabled = true;
                    TxtNumero.ReadOnly = false;

                    LblError.Text = "Baja con Exito";
                }
                else
                {
                    LblError.Text = "Debe buscar empleado para dar de baja";
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Length > 40)
                    LblError.Text = ex.Message.Substring(0, 40);
                else
                    LblError.Text = ex.Message;
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (objEmpleado != null)
                {
                    objEmpleado.NombreCompleto = TxtNombre.Text.Trim();
                    objEmpleado.Contrasenia = TxtPassword.Text.Trim();
                    objEmpleado.HoraInicio = dtpInicio.Value.TimeOfDay.ToString();
                    objEmpleado.HoraFin = dtpFin.Value.TimeOfDay.ToString();

                    ServiceClient wcf = new ServiceClient();
                    wcf.ModificarUsuario(objEmpleado, empleadoLogueado);
                    this.DesActivoBotones();
                    this.LimpioControles();

                    TxtNumero.Enabled = true;
                    TxtNumero.ReadOnly = false;

                    LblError.Text = "Modificacion con Exito";
                }
                else
                {
                    LblError.Text = "Debe buscar empleado para dar de baja";
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Length > 40)
                    LblError.Text = ex.Message.Substring(0, 40);
                else
                    LblError.Text = ex.Message;
            }
        }

        public void buscarEmpleado(string doc)
        {
            int cedula = 0;
            try
            {
                cedula = Convert.ToInt32(doc);

                Empleado _unEmpleado = null;
                ServiceClient wcf = new ServiceClient();
                _unEmpleado = (Empleado)wcf.BuscarUsuario(cedula, empleadoLogueado);
                if (_unEmpleado == null)
                {
                    BtnAlta.Enabled = true;
                    TxtNumero.Enabled = false;
                    LblError.Text = "No existe documento, puede agregarlo.";
                }
                else
                {
                    BtnModificar.Enabled = true;
                    BtnBaja.Enabled = true;
                    objEmpleado = _unEmpleado;
                    TxtNumero.Text = _unEmpleado.Documento.ToString();
                    TxtNombre.Text = _unEmpleado.NombreCompleto;
                    TxtPassword.Text = _unEmpleado.Contrasenia;
                    dtpInicio.Value = Convert.ToDateTime(_unEmpleado.HoraInicio);
                    dtpFin.Value = Convert.ToDateTime(_unEmpleado.HoraFin);
                }
            }
            catch (FormatException)
            {
                LblError.Text = "La cedula es invalida.";
            }
            catch (Exception ex)
            {
                if (ex.Message.Length > 40)
                    LblError.Text = ex.Message.Substring(0, 40);
                else
                    LblError.Text = ex.Message;
            }
        }

        private void DesActivoBotones()
        {
            BtnAlta.Enabled = false;
            BtnBaja.Enabled = false;
            BtnModificar.Enabled = false;
        }

        private void LimpioControles()
        {
            TxtNumero.Text = "";
            TxtNombre.Text = "";
            TxtPassword.Text = "";
            dtpInicio.Value = Convert.ToDateTime("08:00");
            dtpFin.Value = Convert.ToDateTime("17:00");
            LblError.Text = "";
            TxtNumero.Enabled = true;
        }

        private void BtnDeshacer_Click(object sender, EventArgs e)
        {
            DesActivoBotones();
            LimpioControles();
        }

        private void TxtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            utiles.soloNumeros(e);
        }
    }
}
