using BL.Restaurant;
using Restaurant;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant
{
    public partial class FormLogin : Form
    {

        RestaurantSeguridadBL  _seguridad;

        public FormLogin()
        {
            InitializeComponent();

            _seguridad = new RestaurantSeguridadBL ();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("HOlaMundo"); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {


            string Usuario;
            string Contrasena;

            Usuario = textBox1.Text;
            Contrasena = textBox2.Text;


            var resultado = _seguridad.Autorizar (Usuario, Contrasena);

            if(resultado == true)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o Contrasena Incorrecta");
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
