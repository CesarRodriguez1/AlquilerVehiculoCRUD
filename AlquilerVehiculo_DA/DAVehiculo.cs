using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerVehiculo_DA
{
    public class DAVehiculo
    {
        ////////////////LISTADO
        static public List<Vehiculo> ListadoVehiculo()
        {
            List<Vehiculo> listado = new List<Vehiculo>();
            using (var data = new BDAlquilerVehiculoEntities())
            {
                return data.Vehiculo.ToList();
            }
        }

        ////////////////// Depende del listado:
        //static public List<Modelo> ListadoModelo()
        //{
        //    using (var data = new BDAlquilerVehiculoEntities())
        //    {
        //        return data.Modelo.ToList();
        //    }

        //}


        //REGISTRAR
        static public bool RegistrarVehiculo(Vehiculo vehiculo)
        {
            bool exito = true;

            try
            {
                using (var data = new BDAlquilerVehiculoEntities())
                {
                    data.Vehiculo.Add(vehiculo);
                    data.SaveChanges();
                }
            }
            catch
            {
                exito = false;
            }

            return exito;
        }

        //ACTUALIZAR
        static public bool ActualizarVehiculo(Vehiculo vehiculo) // referido a objeto
        {
            bool exito = true; // validación del registro
            // para el manejo de excepciones
            try
            {
                using (var data = new BDAlquilerVehiculoEntities())
                {
                    // realizar la consulta y actualizar
                    Vehiculo actual = data.Vehiculo.Where(x => x.CodVehiculo == vehiculo.CodVehiculo).FirstOrDefault();// alias

                    actual.Descripcion = vehiculo.Descripcion;
                    actual.Placa = vehiculo.Placa;
                    actual.Color = vehiculo.Color;
                    actual.CodModelo = vehiculo.CodModelo;
                    actual.Disponible = vehiculo.Disponible;

                    data.SaveChanges(); // guarda los cambios
                }
            }

            catch (Exception)
            {
                // cuando ocurre el error
                exito = false;
            }
            return exito;

        }



        //ELIMINAR
        static public bool EliminarVehiculo(string CodVehiculo) // referido a borrar
        {
            bool exito = true;
            try
            {

                using (var data = new BDAlquilerVehiculoEntities())
                {
                    Vehiculo actual = data.Vehiculo.Where(z => z.CodVehiculo == CodVehiculo).FirstOrDefault();// alias
                    data.Vehiculo.Remove(actual);
                    data.SaveChanges();
                }
            }
            catch (Exception)
            {

                exito = false;
            }

            return exito;
        }

        /////
    }
}
