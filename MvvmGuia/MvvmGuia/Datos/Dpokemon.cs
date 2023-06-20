using System;
using System.Collections.Generic;
using System.Text;
using MvvmGuia.Modelo;
using MvvmGuia.Conexion;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Firebase.Database;

namespace MvvmGuia.Datos
{
    public class Dpokemon
    {
        public async Task InsertarPokemon(Mpokemon parametros)
        {
            await Cconexion.firebase
                .Child("Pokemon")
                .PostAsync(new Mpokemon()
                {
                    Colorfondo = parametros.Colorfondo,
                    Icono = parametros.Icono,
                    Nombre = parametros.Nombre,
                    Numorden = parametros.Numorden,
                    Poder = parametros.Poder,
                    Colorpoder = parametros.Colorpoder
                });
        }
        public async Task<ObservableCollection <Mpokemon>> MostrarPokemon()
        {
            //var data = (await Cconexion.firebase
            //    .Child("Pokemon")
            //    .OnceAsync<Mpokemon>())
            //    .Where(a => a.Key != "Modelo")
            //    .Select(item => new Mpokemon
            //    {
            //        Idpokemon = item.Key,
            //        Nombre = item.Object.Nombre,
            //        Colorfondo = item.Object.Colorfondo,
            //        Colorpoder = item.Object.Colorpoder,
            //        Numorden = item.Object.Numorden,
            //        Poder = item.Object.Poder,
            //        Icono = item.Object.Icono,
            //    });


            var data = await Task.Run(() => Cconexion.firebase
                .Child("Pokemon")
                .AsObservable<Mpokemon>()
                .AsObservableCollection());
            return data;
        }
    }
}

