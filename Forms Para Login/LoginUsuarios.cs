﻿using SIMED_V1.Entidades;
using SIMED_V1.Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIMED_V1
{
    public partial class LoginUsuarios : Form
    {

        public LoginUsuarios()
        {
            InitializeComponent();

            if (Properties.Settings.Default.Recuerdame)
            {
                txtNombreUsuario.Text = Properties.Settings.Default.UserName;
                txtPassword.Text = Properties.Settings.Default.Password;
                swtRecordame.Checked = true;
                this.SetStyle(ControlStyles.ResizeRedraw, true);
            }


        }
        private const int cGrip = 16;
        private const int cCaption = 32;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
            }
            base.WndProc(ref m);
        }



        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void LoginUsuarios_Load(object sender, EventArgs e)
        {
          
        }

        private void txtNombreUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnInciarSesion_Click(object sender, EventArgs e)
        {
            

            if (txtNombreUsuario.Text.Equals("") || txtPassword.Text.Equals(""))
            {

                ErroresForm window = new ErroresForm();
                window.show("Error: debe ingresar un nombre de usuario y password");
            }
            else
            {
                string nombreDeUsuario = txtNombreUsuario.Text;
                string password = txtPassword.Text;
                bool resultado = false;

                try
                {
                    resultado = UsuarioBD.ValidarUsuario(nombreDeUsuario, password);
                    if (resultado == true)
                    {
                        string correo = UsuarioBD.ObtenerEmail(nombreDeUsuario);
                        Usuarios user = new Usuarios(nombreDeUsuario, password,correo);
                        ProgressBar ventana = new ProgressBar();
                        ventana.Show();
                        this.Hide();
                    }
                    else
                    {
                        ErroresForm window = new ErroresForm();
                        window.show("Error: Usuario inexistente. Ingrese los datos nuevamente");
                    }

                }
                catch (Exception ex)
                {

                    ErroresForm window = new ErroresForm();
                    window.show("Error al consultar usuarios" + ex);
                }




            }
        }

        private void btnOlvideDatos_Click(object sender, EventArgs e)
        {
            EnviarCodigoFormcs eco = new EnviarCodigoFormcs(this);
            this.Hide();
            eco.Show();
        }

        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            NuevoUsuario ventana = new NuevoUsuario();
            ventana.Show();
            this.Hide();
        }
        
       
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void swtRecordame_CheckedChanged(object sender, EventArgs e)
        {
            if (swtRecordame.Checked)
            {
                string username = txtNombreUsuario.Text;
                string password = txtPassword.Text;

                Properties.Settings.Default.UserName = username;
                Properties.Settings.Default.Password = password;
                Properties.Settings.Default.Recuerdame = true;
                Properties.Settings.Default.Save();
            }
            else 
            {
                Properties.Settings.Default.UserName = "";
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.Recuerdame = false;
                Properties.Settings.Default.Save();
            }
        }

        private void btnCerrarApp_Click(object sender, EventArgs e)
        {
            //System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            //player.SoundLocation = "C:\\Facultad\\Tercer Año\\PAV 1\\practicas\\archivos para proyecto\\sonidoPS2.wav";
            //player.Play();
            this.Close();
     
        }

        public string obtenerNombreUsuario()
        { 
            string nombreUsu = txtNombreUsuario.Text;
            return nombreUsu;
        
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void lblInicioSesion_Click(object sender, EventArgs e)
        {

        }

        private void lblRecordame_Click(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
