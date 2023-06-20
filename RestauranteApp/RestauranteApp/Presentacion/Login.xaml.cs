using RestauranteApp.Datos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestauranteApp.Presentacion
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
			try
			{
                dibujarUsuarios();
            }
			catch (Exception ex)
			{
                MostrarButtonSinConexion();
            }
			
		}

		public void dibujarUsuarios()
		{
			try
			{
                PanelUsuarios.Children.Clear ();
				conexionMaestra.Abrir();
				SqlCommand cmd = new SqlCommand ("select*from Usuarios where Estado = 'Activo'", conexionMaestra.conectar);
				SqlDataReader rdr = cmd.ExecuteReader ();
				while (rdr.Read ())
				{
					Label b = new Label ();
					StackLayout p1 = new StackLayout ();
					ImageButton I1 = new ImageButton ();
					b.Text = rdr["Login"].ToString();
					b.HeightRequest = 25;
					b.FontAttributes = FontAttributes.Bold;
					b.BackgroundColor = Color.Transparent;
					b.TextColor = Color.White;
					b.HorizontalTextAlignment=TextAlignment.Center;
					b.VerticalTextAlignment=TextAlignment.Center;

					p1.HeightRequest = 167;
					p1.WidthRequest = 155;
					p1.BackgroundColor = Color.FromRgb(37, 200, 67);

					I1.Source = null;
					byte[] bi = (Byte[])rdr["Icono"];
					MemoryStream ms = new MemoryStream (bi);
					I1.Source = ImageSource.FromStream(() => ms);
					I1.HeightRequest = 140;
					I1.WidthRequest = 140;
					I1.BackgroundColor = Color.Transparent;

					Frame frameImageButton = new Frame ();
					frameImageButton.Content = I1;
					frameImageButton.Margin = 0;
					frameImageButton.Padding = -6;
					frameImageButton.WidthRequest = I1.WidthRequest;
					frameImageButton.HeightRequest = I1.HeightRequest;
					frameImageButton.CornerRadius = 70;
					frameImageButton.HasShadow = false;
					frameImageButton.VerticalOptions = LayoutOptions.Center;
					frameImageButton.HorizontalOptions = LayoutOptions.Center;

					p1.Children.Add(frameImageButton);
					p1.Children.Add(b);

                    Frame framestackLayout = new Frame();
                    framestackLayout.Content = p1;
                    framestackLayout.Margin = 10;
                    framestackLayout.Padding = 5;
                    framestackLayout.HeightRequest = p1.HeightRequest;
                    framestackLayout.WidthRequest = p1.WidthRequest;
                    framestackLayout.HasShadow = true;
                    framestackLayout.CornerRadius = 40;
                    framestackLayout.VerticalOptions = LayoutOptions.Center;
                    framestackLayout.HorizontalOptions = LayoutOptions.Center;
                    framestackLayout.BackgroundColor = p1.BackgroundColor;

                    PanelUsuarios.Children.Add(framestackLayout);
                }
				conexionMaestra.Cerrar();
				
            }
            catch (Exception ex)
			{
				conexionMaestra.Cerrar();
				MostrarButtonSinConexion();

            }
		}
		private void MostrarButtonSinConexion()
		{
			Button btn = new Button();
			btn.BackgroundColor = Color.FromRgb(124,170,135);
			btn.WidthRequest = 120;
			btn.HeightRequest = 50;
			btn.HorizontalOptions = LayoutOptions.Center;
			btn.VerticalOptions = LayoutOptions.Center;
			btn.Clicked += Btn_Clicked;
			btn.Text = "Conectar";
			btn.TextColor = Color.White;
			gridVistas.Children.Remove(lbltitulo);
			gridVistas.Children.Add(btn);

		}

        private void Btn_Clicked(object sender, EventArgs e)
        {
           ((NavigationPage)this.Parent).PushAsync( new PedidodeIP());
        }
    }
}