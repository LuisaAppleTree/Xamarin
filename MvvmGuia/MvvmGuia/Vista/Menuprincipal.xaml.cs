using MvvmGuia.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MvvmGuia.Vista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Menuprincipal : ContentPage
	{
		public Menuprincipal ()
		{
			InitializeComponent ();
			BindingContext = new VMMenuprincipal(Navigation);
		}
	}
}