using MvvmGuia.Vista;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MvvmGuia.VistaModelo
{
    public class VMPage1 : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        string _Mensaje;
        string _N1;
        string _N2;
        string _Resultado;
        string _TipoUsuario;
        DateTime _Fecha;
        string _ResultadoFecha;
        #endregion

        #region CONSTRUCTOR
        public VMPage1(INavigation navigation)
        {
            Navigation = navigation;
            Fecha = DateTime.Now;
        }
        #endregion

        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }

        public string Mensaje
        {
            get { return _Mensaje; }
            set { SetValue(ref _Mensaje, value); }
        }

        public string N1
        {
            get { return _N1; }
            set { SetValue(ref _N1, value); }
        }

        public string N2
        {
            get { return _N2; }
            set { SetValue(ref _N2, value); }
        }

        public string Resultado
        {
            get { return _Resultado; }
            set { SetValue(ref _Resultado, value); }
        }

        public string TipoUsuario
        {
            get { return _TipoUsuario; }
            set { SetValue(ref _TipoUsuario, value); }
        }

        public string SeleccionarTipoUser
        {
            get { return _TipoUsuario; }
            set
            {
                SetProperty(ref _TipoUsuario, value);
                TipoUsuario = _TipoUsuario;
            }
        }

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { SetValue(ref _Fecha, value);
                ResultadoFecha = _Fecha.ToString("dd/MM/yyyy");
            }
        }

        public string ResultadoFecha
        {
            get { return _ResultadoFecha; }
            set { SetValue(ref _ResultadoFecha, value); }
        }

        #endregion

        #region PROCESOS
        //tareas asincronas
        public async Task ProcesoAsyncrono()
        {

        }

        public async Task Alerta()
        {
            await DisplayAlert("Titulo del alert", Mensaje , "Ok");
        }

        public async Task NavegacionPage2()
        {
            await Navigation.PushAsync(new Page2());
        }

        public async Task VolverMainMenu()
        {
            await Navigation.PopAsync();
        }

        //tareas no asíncronas, sencillas
        public void ProcesoSimple()
        {

        }

        public void Sumar()
        {
            double n1 = 0;
            double n2 = 0;
            double resultado = 0;

            n1 = Convert.ToDouble(N1);
            n2 = Convert.ToDouble(N2);

            resultado = n1 + n2;

            Resultado = resultado.ToString();
        }
        #endregion

        #region COMANDOS
        //comando para tareas asíncronas
        public ICommand ProcesoAsyncCommand => new Command(async () => await ProcesoAsyncrono());

        public ICommand AlertaCommand => new Command(async () => await Alerta());

        public ICommand NavegarPage2Command => new Command(async () => await NavegacionPage2());

        public ICommand VolvermainmenuCommand => new Command(async()=> await VolverMainMenu());

        //comando para tareas simples
        public ICommand ProcesoSimpleCommand => new Command(ProcesoSimple);

        public ICommand SumarCommand => new Command(Sumar);
        #endregion
    }
}

