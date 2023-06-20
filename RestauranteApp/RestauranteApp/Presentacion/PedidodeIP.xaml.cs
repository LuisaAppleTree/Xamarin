using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestauranteApp.Presentacion
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PedidodeIP : ContentPage
	{
		public PedidodeIP ()
		{
			InitializeComponent ();
			btnConectar.Clicked += btnConectar_Clicked;
		}

        private void btnConectar_Clicked(object sender, EventArgs e)
        {
			crear_archivo();
            DisplayAlert("Error", "Conexión fallida", "Ok");
            //System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
        }

		private void crear_archivo()
		{
			string ruta;
			ruta = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "connection.txt");
			FileInfo fi = new FileInfo(ruta);
			StreamWriter sw;
			try
			{
				string parte1 = "Data Source=";
				string parte2 = ";Initial Catalog=Restaurante;Integrated Security=true";
				if (File.Exists (ruta) == false) 
				{
					sw = File.CreateText(ruta);
					sw.WriteLine(parte1 + txtconexion.Text + parte2);
					sw.Flush();
					sw.Close();

				}
				else if (File.Exists (ruta) == true)
				{
					File.Delete(ruta);
					sw = File.CreateText(ruta);
					sw.WriteLine(parte1 + txtconexion.Text + parte2);
					sw.Flush();
					sw.Close();
				}

            }
            catch (Exception ex)
			{
				DisplayAlert("Error", ex.Message, "Ok");
			}
		}
    }
}