using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MvvmGuia.VistaModelo
{
    public class VMpatron:BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        #endregion

        #region CONSTRUCTOR
        public VMpatron(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref  _Texto, value); }
        }
        #endregion

        #region PROCESOS
        //tareas asincronas
        public async Task ProcesoAsyncrono()
        {

        }
        //tareas no asíncronas, sencillas
        public void ProcesoSimple()
        {

        }
        #endregion

        #region COMANDOS
        //comando para tareas asíncronas
        public ICommand ProcesoAsyncCommand => new Command(async () => await ProcesoAsyncrono());

        //comando para tareas simples
        public ICommand ProcesoSimpleCommand => new Command(ProcesoSimple);
        #endregion
    }
}
