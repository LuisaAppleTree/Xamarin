using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using MvvmGuia.Vista.Pokemon;
using MvvmGuia.Datos;
using MvvmGuia.Modelo;

namespace MvvmGuia.VistaModelo
{
    public class VMregistrarpokemon : BaseViewModel
    {
        #region VARIABLES
        string _txtcolorfondo;
        string _txtcolorpoder;
        string _txtnombre;
        string _txtnro;
        string _txtpoder;
        string _txticono;
        #endregion

        #region CONSTRUCTOR
        public VMregistrarpokemon(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region OBJETOS
        public string Txtcolorfondo
        {
            get { return _txtcolorfondo; }
            set { SetValue(ref _txtcolorfondo, value); }
        }

        public string Txtcolorpoder
        {
            get { return _txtcolorpoder; }
            set { SetValue(ref _txtcolorpoder, value); }
        }

        public string Txtnombre
        {
            get { return _txtnombre; }
            set { SetValue(ref _txtnombre, value); }
        }

        public string Txtnro
        {
            get { return _txtnro; }
            set { SetValue(ref _txtnro, value); }
        }

        public string Txtpoder
        {
            get { return _txtpoder; }
            set { SetValue(ref _txtpoder, value); }
        }

        public string Txticono
        {
            get { return _txticono; }
            set { SetValue(ref _txticono, value); }
        }
        #endregion

        #region PROCESOS
        //tareas asincronas
        public async Task Volveralistapokemon()
        {
            await Navigation.PopAsync();
        }

        public async Task Insertar()
        {
            var funcion = new Dpokemon();
            var parametros = new Mpokemon();
            parametros.Colorfondo = Txtcolorfondo;
            parametros.Colorpoder = Txtcolorpoder;
            parametros.Icono = Txticono;
            parametros.Nombre = Txtnombre;
            parametros.Numorden = Txtnro;
            parametros.Poder = Txtpoder;

            await funcion.InsertarPokemon(parametros);

            await Volveralistapokemon();
        }
        //tareas no asíncronas, sencillas
        public void ProcesoSimple()
        {

        }
        #endregion

        #region COMANDOS
        //comando para tareas asíncronas
        public ICommand VolveralistapokemonCommand => new Command(async () => await Volveralistapokemon());

        public ICommand InsertarCommand => new Command(async () => await Insertar());   

        //comando para tareas simples
        public ICommand ProcesoSimpleCommand => new Command(ProcesoSimple);
        #endregion
    }
}
