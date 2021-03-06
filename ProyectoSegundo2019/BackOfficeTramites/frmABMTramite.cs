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
using System.Collections;

namespace BackOfficeTramites
{
    public partial class frmABMTramite : Form
    {
        List<BackOfficeTramites.wcfTramite.Documentacion> DocumentacionActiva = new List<BackOfficeTramites.wcfTramite.Documentacion>();
        List<BackOfficeTramites.wcfTramite.Documentacion> DocumentacionTramite = new List<BackOfficeTramites.wcfTramite.Documentacion>();
        Empleado empleadoLogueado = null;
        Tramite tramite = null;
        public frmABMTramite(Empleado empleado)
        {
            InitializeComponent();
            empleadoLogueado = empleado;
            controlDocumentos(false);
            try
            {
                ServiceClient wcf = new ServiceClient();
                DocumentacionActiva = wcf.listadoDocumentacion(empleadoLogueado).ToList<Documentacion>();
                var res = (from doc in DocumentacionActiva
                           select new
                           {
                               Codigo = doc.CodigoInterno,
                               Nombre = doc.NomDocumentacion,
                               Lugar = doc.Lugar
                           }).ToList();

                dgvDocumentosActivos.DataSource = res;

                var rest = (from doc in DocumentacionTramite
                            select new
                            {
                                Codigo = doc.CodigoInterno,
                                Nombre = doc.NomDocumentacion,
                                Lugar = doc.Lugar
                            }).ToList();
                dgvDocumentosTramite.DataSource = rest;
            }
            catch (Exception ex)
            {
                if (ex.Message.Length > 40)
                    LblError.Text = ex.Message.Substring(0, 40);
                else
                    LblError.Text = ex.Message;
            }
        }

        private void txtNumero_Validating(object sender, CancelEventArgs e)
        {
            String codigo = txtCodigo.Text;
            try
            {
                if (codigo.Length != 9)
                {
                    throw new FormatException("Codigo invalido, (debe componerse de 4 numeros y 5 letras respectivamente).");
                }
                for (int i = 0; i < codigo.Length; i++)
                {
                    if (i <= 3)
                    {
                        if (!Char.IsNumber(codigo[i]))
                        {
                            throw new FormatException("Codigo invalido, (debe componerse de 4 numeros y 5 letras respectivamente).");
                        }
                    }
                    else
                    {
                        if (!Char.IsLetter(codigo[i]))
                        {
                            throw new FormatException("Codigo invalido, (debe componerse de 4 numeros y 5 letras respectivamente).");
                        }
                    }
                }

                ServiceClient wcf = new ServiceClient();
                Tramite unTramite = wcf.BuscarTramiteAux(codigo, empleadoLogueado);
                if (unTramite == null)
                {
                    BtnAlta.Enabled = true;
                    txtCodigo.Enabled = false;
                    LblError.Text = "No existe tramite, puede agregarlo.";
                }
                else
                {
                    BtnModificar.Enabled = true;
                    BtnBaja.Enabled = true;
                    tramite = unTramite;
                    txtCodigo.Enabled = false;
                    txtNombre.Text = tramite.NombreTramite;
                    txtDescripcion.Text = tramite.Descripcion;
                    txtPrecio.Text = tramite.Precio.ToString();
                    DocumentacionTramite = tramite.DocumentacionExigida.ToList<Documentacion>();
                    var rest = (from doc in DocumentacionTramite
                                select new
                                {
                                    Codigo = doc.CodigoInterno,
                                    Nombre = doc.NomDocumentacion,
                                    Lugar = doc.Lugar
                                }).ToList();
                    dgvDocumentosTramite.DataSource = rest;
                    btnActivo.Text = "Activo";
                    if (!unTramite.Activo)
                    {
                        btnActivo.Enabled = true;
                        LblError.Text = "El tramite esta inactivo.";
                        btnActivo.Image = BackOfficeTramites.Properties.Resources.inactivo;
                        btnActivo.Text = "Activar";
                        BtnBaja.Enabled = false;
                        BtnModificar.Enabled = false;
                    }
                    else
                    {
                        LblError.Text = "Tramite encontrado.";
                    }

                }
                controlDocumentos(true);
            }
            catch (FormatException ex)
            {
                LblError.Text = ex.Message;
                txtCodigo.Focus();
            }
            catch (Exception ex)
            {
                if (ex.Message.Length > 40)
                    LblError.Text = ex.Message.Substring(0, 40);
                else
                    LblError.Text = ex.Message;
            }
        }
        private void BtnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                Tramite unTramite = new Tramite();
                unTramite.CodigoTramite = txtCodigo.Text;
                unTramite.NombreTramite = txtNombre.Text;
                unTramite.Descripcion = txtDescripcion.Text;
                unTramite.Precio = Convert.ToInt32(txtPrecio.Text);
                unTramite.DocumentacionExigida = new Documentacion[DocumentacionTramite.Count];
                for (int i = 0; i < DocumentacionTramite.Count; i++)
                {
                    unTramite.DocumentacionExigida[i] = DocumentacionTramite[i];
                }

                ServiceClient wcf = new ServiceClient();
                wcf.AltaTramite(unTramite, empleadoLogueado);
                this.DesActivoBotones();
                this.LimpioControles();

                txtCodigo.Enabled = true;
                txtCodigo.ReadOnly = false;

                LblError.Text = "Alta con Exito";

                if (!tramite.Activo)
                {
                    LblError.Text = "Se activo tramite con Exito.";
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

        private void BtnBaja_Click(object sender, EventArgs e)
        {
            if (tramite != null)
            {
                try
                {
                    ServiceClient wcf = new ServiceClient();
                    wcf.BajaTramite(tramite, empleadoLogueado);
                    this.DesActivoBotones();
                    this.LimpioControles();
                    txtCodigo.Enabled = true;
                    LblError.Text = "El tramite se a eliminado";
                }
                catch (Exception ex)
                {
                    if (ex.Message.Length > 40)
                        LblError.Text = ex.Message.Substring(0, 40);
                    else
                        LblError.Text = ex.Message;
                }
            }
            else
            {
                LblError.Text = "Debe buscar un Tramite para eliminar";
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (tramite != null)
            {
                try
                {
                    tramite.NombreTramite = txtNombre.Text.Trim();
                    tramite.Descripcion = txtDescripcion.Text.Trim();
                    tramite.DocumentacionExigida = new Documentacion[DocumentacionTramite.Count];
                    for (int i = 0; i < DocumentacionTramite.Count; i++)
                    {
                        tramite.DocumentacionExigida[i] = DocumentacionTramite[i];
                    }
                    tramite.Precio = Convert.ToDecimal(txtPrecio.Text);

                    ServiceClient wcf = new ServiceClient();
                    wcf.ModificarTramite(tramite, empleadoLogueado);
                    this.DesActivoBotones();
                    this.LimpioControles();

                    LblError.Text = "Modificacion con Exito";
                }
                catch (FormatException ex)
                {
                    LblError.Text = "Precio invalido.";
                }
                catch (Exception ex)
                {
                    if (ex.Message.Length > 40)
                        LblError.Text = ex.Message.Substring(0, 40);
                    else
                        LblError.Text = ex.Message;
                }
            }
            else
            {
                LblError.Text = "Debe buscar un Tramite para eliminar";
            }
        }

        private void BtnDeshacer_Click(object sender, EventArgs e)
        {
            DesActivoBotones();
            LimpioControles();
        }

        private void DesActivoBotones()
        {
            BtnAlta.Enabled = false;
            BtnBaja.Enabled = false;
            BtnModificar.Enabled = false;
            controlDocumentos(false);
            btnActivo.Enabled = false;
        }

        private void controlDocumentos(bool estado)
        {
            label4.Visible = estado;
            label6.Visible = estado;
            dgvDocumentosActivos.Visible = estado;
            dgvDocumentosTramite.Visible = estado;
            btnAgregarDoc.Visible = estado;
            btnQuitarDoc.Visible = estado;
            
            label4.Enabled = estado;
            label6.Enabled = estado;
            btnAgregarDoc.Enabled = estado;
            btnQuitarDoc.Enabled = estado;
        }

        private void LimpioControles()
        {
            txtCodigo.Text = "";
            txtCodigo.Focus();
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            LblError.Text = "";
            txtCodigo.Enabled = true;
            DocumentacionTramite = new List<Documentacion>();
            var rest = (from doc in DocumentacionTramite
                        select new
                        {
                            Codigo = doc.CodigoInterno,
                            Nombre = doc.NomDocumentacion,
                            Lugar = doc.Lugar
                        }).ToList();
            dgvDocumentosTramite.DataSource = rest;
            btnActivo.Text = "Activo";
            btnActivo.Image = BackOfficeTramites.Properties.Resources.activo;
        }

        private void btnQuitarDoc_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> noSeleccionado = new List<DataGridViewRow>();

            try
            {
                List<Documentacion> documentos = new List<Documentacion>();

                foreach (DataGridViewRow fila in dgvDocumentosTramite.Rows)
                {
                    if (!fila.Selected)
                    {
                        noSeleccionado.Add(fila);
                    }
                }

                foreach (DataGridViewRow row in noSeleccionado)
                {
                    Documentacion doc = new Documentacion();
                    doc.CodigoInterno = Convert.ToInt32(row.Cells["Codigo"].Value);
                    doc.NomDocumentacion = row.Cells["Nombre"].Value.ToString();
                    doc.Lugar = row.Cells["Lugar"].Value.ToString();
                    documentos.Add(doc);
                }
                DocumentacionTramite = documentos;
                var res = (from doc in documentos
                           select new
                           {
                               Codigo = doc.CodigoInterno,
                               Nombre = doc.NomDocumentacion,
                               Lugar = doc.Lugar
                           }).ToList();

                dgvDocumentosTramite.DataSource = res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnAgregarDoc_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> seleccion = new List<DataGridViewRow>();

            try
            {
                List<Documentacion> documentos = new List<Documentacion>();
                if (DocumentacionTramite == null || DocumentacionTramite.Count == 0)
                {
                    documentos = new List<Documentacion>();
                }
                else
                {
                    documentos = DocumentacionTramite;
                }

                foreach (DataGridViewRow fila in dgvDocumentosActivos.Rows)
                {
                    if (fila.Selected)
                    {
                        bool bandera = true;
                        foreach (Documentacion item in DocumentacionTramite)
                        {
                            if (item.CodigoInterno == Convert.ToInt32(fila.Cells["Codigo"].Value))
                            {
                                bandera = false;
                            }
                        }

                        if (bandera)
                        {
                            seleccion.Add(fila);
                        }
                    }
                }
                if (seleccion.Count != 0)
                {
                    foreach (DataGridViewRow row in seleccion)
                    {
                        Documentacion doc = new Documentacion();
                        doc.CodigoInterno = Convert.ToInt32(row.Cells["Codigo"].Value);
                        doc.NomDocumentacion = row.Cells["Nombre"].Value.ToString();
                        doc.Lugar = row.Cells["Lugar"].Value.ToString();
                        documentos.Add(doc);
                    }
                    DocumentacionTramite = documentos;
                }

                var res = (from doc in documentos
                           select new
                           {
                               Codigo = doc.CodigoInterno,
                               Nombre = doc.NomDocumentacion,
                               Lugar = doc.Lugar
                           }).ToList();
                dgvDocumentosTramite.DataSource = res;

            }
            catch (Exception ex)
            {
                if (ex.Message.Length > 40)
                    LblError.Text = ex.Message.Substring(0, 40);
                else
                    LblError.Text = ex.Message;
            }
        }

    }
}
