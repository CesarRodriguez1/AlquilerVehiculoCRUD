using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerVehiculo_DA
{
    public class DAModelo
    {

        ////////////////LISTADO
        static public List<Modelo> ListadoModelo()
        {
            List<Modelo> listado = new List<Modelo>();
            using (var data = new BDAlquilerVehiculoEntities())
            {
                return data.Modelo.ToList();
            }
        }

        ////////////////// Depende del listado:
        static public List<Marca> ListadoMarca()
        {
            using (var data = new BDAlquilerVehiculoEntities())
            {
                return data.Marca.ToList();
            }

        }


        //REGISTRAR
        static public bool RegistrarModelo(Modelo modelo)
        {
            bool exito = true;

            try
            {
                using (var data = new BDAlquilerVehiculoEntities())
                {
                    data.Modelo.Add(modelo);
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
        static public bool ActualizarModelo(Modelo modelo) // referido a objeto
        {
            bool exito = true; // validación del registro
            // para el manejo de excepciones
            try
            {
                using (var data = new BDAlquilerVehiculoEntities())
                {
                    // realizar la consulta y actualizar
                    Modelo actual = data.Modelo.Where(x => x.CodModelo == modelo.CodModelo).FirstOrDefault();// alias

                    actual.Descripcion = modelo.Descripcion;
                    actual.Puertas = modelo.Puertas;
                    actual.Precio = modelo.Precio;
                    actual.CodMarca = modelo.CodMarca;
                    //actual.Marca.Descripcion = modelo.Marca.Descripcion;
                   
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
        static public bool EliminarModelo(string CodModelo) // referido a borrar
        {
            bool exito = true;
            try
            {

                using (var data = new BDAlquilerVehiculoEntities())
                {
                    Modelo actual = data.Modelo.Where(z => z.CodModelo == CodModelo).FirstOrDefault();// alias
                    data.Modelo.Remove(actual);
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
