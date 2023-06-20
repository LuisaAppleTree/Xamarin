using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using MvvmGuia.Vista.Pokemon;
using MvvmGuia.Modelo;
using MvvmGuia.Datos;
using System.Collections.ObjectModel;

namespace MvvmGuia.VistaModelo
{
    public class VMlistapokemon:BaseViewModel
    {
        #region VARIABLES
        ObservableCollection<Mpokemon> _listapokemon;
        #endregion

        #region CONSTRUCTOR
        public VMlistapokemon(INavigation navigation)
        {
            Navigation = navigation;
            Mostrar();
        }
        #endregion

        #region OBJETOS
        public ObservableCollection<Mpokemon> Listapokemon
        {
            get { return _listapokemon; }
            set { SetValue(ref _listapokemon, value); 
                OnPropertyChanged(); }
        }
        #endregion

        #region PROCESOS
        //tareas asincronas
        public async Task Iraregistro()
        {
            await Navigation.PushAsync(new Registrarpokemon());
        }

        public async Task Mostrar()
        {
            var funcion = new Dpokemon();
            Listapokemon = await funcion.MostrarPokemon();
        }

        public async Task Iradetalle(Mpokemon parametros)
        {
            await Navigation.PushAsync(new Detallepokemon(parametros));
        }
        //tareas no asíncronas, sencillas
        public void ProcesoSimple()
        {

        }
        #endregion

        #region COMANDOS
        //comando para tareas asíncronas
        public ICommand IraregistroCommand => new Command(async () => await Iraregistro());

        public ICommand IradetalleCommand => new Command<Mpokemon>(async (p) => await Iradetalle(p));

        //comando para tareas simples
        public ICommand ProcesoSimpleCommand => new Command(ProcesoSimple);
        #endregion
    }
}
