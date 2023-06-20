using MvvmGuia.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MvvmGuia.VistaModelo
{
    public class VMdetallepokemon : BaseViewModel
    {
        #region VARIABLES
        public Mpokemon parametrosRecibe { get; set; }
        #endregion

        #region CONSTRUCTOR
        public VMdetallepokemon(INavigation navigation, Mpokemon parametrosTrae)
        {
            Navigation = navigation;
            parametrosRecibe = parametrosTrae;
        }
        #endregion

        #region OBJETOS
        #endregion

        #region PROCESOS
        //tareas asincronas
        public async Task VolverLista()
        {
            await Navigation.PopAsync();
        }
        //tareas no asíncronas, sencillas
        public void ProcesoSimple()
        {

        }
        #endregion

        #region COMANDOS
        //comando para tareas asíncronas
        public ICommand VolverlistaCommand => new Command(async () => await VolverLista());

        //comando para tareas simples
        public ICommand ProcesoSimpleCommand => new Command(ProcesoSimple);
        #endregion
    }
}
