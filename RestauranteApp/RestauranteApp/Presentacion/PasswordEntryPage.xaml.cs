using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestauranteApp.Presentacion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PasswordEntryPage : ContentPage
    {
        public PasswordEntryPage()
        {
            InitializeComponent();
        }

        private void btn7_Clicked(object sender, EventArgs e)
        {
            txtPass.Text += 7;
        }

        private void btn8_Clicked(object sender, EventArgs e)
        {
            txtPass.Text += 8;
        }

        private void btn9_Clicked(object sender, EventArgs e)
        {
            txtPass.Text += 9;
        }

        private void btn4_Clicked(object sender, EventArgs e)
        {
            txtPass.Text += 4;
        }

        private void btn5_Clicked(object sender, EventArgs e)
        {
            txtPass.Text += 5;
        }

        private void btn6_Clicked(object sender, EventArgs e)
        {
            txtPass.Text += 6;
        }

        private void btn1_Clicked(object sender, EventArgs e)
        {
            txtPass.Text += 1;
        }

        private void btn2_Clicked(object sender, EventArgs e)
        {
            txtPass.Text += 2;
        }

        private void btn3_Clicked(object sender, EventArgs e)
        {
            txtPass.Text += 3;
        }

        private void btnBorrar_Clicked(object sender, EventArgs e)
        {
            txtPass.Text = string.Empty;
        }

        private void btn0_Clicked(object sender, EventArgs e)
        {
            txtPass.Text += 0;
        }

        private void btnBorrarChar_Clicked(object sender, EventArgs e)
        {
            if(txtPass.Text.Count() > 0)
            {
                txtPass.Text = txtPass.Text.Substring(0, txtPass.Text.Count() - 1);
            }

        }

        private void btnIniciarSesion_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Atención", "Iniciando Sesión", "Ok");
        }
    }
}