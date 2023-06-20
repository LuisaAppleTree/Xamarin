using MvvmGuia.Modelo;
using MvvmGuia.Vista;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MvvmGuia.VistaModelo
{
    public class VMMenuprincipal : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        public List<Mmenuprincipal> listapaginas { get; set; }
        #endregion

        #region CONSTRUCTOR
        public VMMenuprincipal(INavigation navigation)
        {
            Navigation = navigation;
            MostrarPaginas();
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

        public async Task Navegar(Mmenuprincipal parametros)
        {
            string pagina;
            pagina = parametros.Pagina;
            if(pagina.Contains("Entry, datepicker"))
            {
                await Navigation.PushAsync(new Page1());
            }
            if(pagina.Contains("CollectionView sin enlace"))
            {
                await Navigation.PushAsync(new Page2());
            }
            if (pagina.Contains("CRUD Pokemon"))
            {
                await Navigation.PushAsync(new Crudpokemon());
            }
        }

        //tareas no asíncronas, sencillas
        public void ProcesoSimple()
        {

        }

        public void MostrarPaginas()
        {
            listapaginas = new List<Mmenuprincipal>
            {
                new Mmenuprincipal
                {
                    Pagina = "Entry, datepicker, picker, label, navegación",
                    Icono = "a1.png"
                },
                new Mmenuprincipal
                {
                    Pagina = "CollectionView sin enlace a base de datos",
                    Icono = "a2.png"
                },
                new Mmenuprincipal
                {
                    Pagina = "CRUD Pokemon",
                    Icono = "a3.png"
                }
            };
        }

        #endregion

        #region COMANDOS
        //comando para tareas asíncronas
        public ICommand ProcesoAsyncCommand => new Command(async () => await ProcesoAsyncrono());

        public ICommand NavegarCommand => new Command<Mmenuprincipal>(async (p) => await Navegar(p));

        //comando para tareas simples
        public ICommand ProcesoSimpleCommand => new Command(ProcesoSimple);
        #endregion
    }
}
