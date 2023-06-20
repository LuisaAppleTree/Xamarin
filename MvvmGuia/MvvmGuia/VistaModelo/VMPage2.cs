using MvvmGuia.Vista;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using MvvmGuia.Modelo;

namespace MvvmGuia.VistaModelo
{
    public class VMPage2 : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        public List<Musuarios> listausuarios { get; set; }
        #endregion

        #region CONSTRUCTOR
        public VMPage2(INavigation navigation)
        {
            Navigation = navigation;
            MostrarUsuarios();
        }
        #endregion

        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        #endregion

        #region PROCESOS
        //tareas asincronas
        public async Task ProcesoAsyncrono()
        {

        }

        public async Task VolverPage1()
        {
            await Navigation.PopAsync();
        }

        public async Task Alerta(Musuarios parametros)
        {
            await DisplayAlert("Saludo", parametros.Nombre + " dice hola!! ", "Ok");
        }

        //tareas no asíncronas, sencillas
        public void ProcesoSimple()
        {

        }

        public void MostrarUsuarios()
        {
            listausuarios = new List<Musuarios>
            {
                new Musuarios
                {
                    Nombre = "Luisa",
                    Imagen = "pancito.png"
                },
                new Musuarios
                {
                    Nombre = "Migue",
                    Imagen = "limon.png"
                },
                new Musuarios
                {
                    Nombre = "Artu",
                    Imagen = "rol.png"
                }
            };
        }

        #endregion

        #region COMANDOS
        //comando para tareas asíncronas
        public ICommand ProcesoAsyncCommand => new Command(async () => await ProcesoAsyncrono());

        public ICommand Volverpage1Command => new Command(async () => await VolverPage1());

        public ICommand AlertaCommand => new Command<Musuarios>(async (p) => await Alerta(p));

        //comando para tareas simples
        public ICommand ProcesoSimpleCommand => new Command(ProcesoSimple);
        #endregion
    }
}
