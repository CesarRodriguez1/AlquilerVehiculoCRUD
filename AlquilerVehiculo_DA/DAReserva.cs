using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerVehiculo_DA
{
    public class DAReserva
    {
        ////////////////LISTADO
        static public List<Reserva> ListadoReserva()
        {
            List<Reserva> reserva = new List<Reserva>();
            using (var data = new BDAlquilerVehiculoEntities())
            {
                return data.Reserva.ToList();
            }
        }

        //////////////// Depende del listado:
        static public List<Cliente> ListadoCliente()
        {
            using (var data = new BDAlquilerVehiculoEntities())
            {
                return data.Cliente.ToList();
            }

        }


        //REGISTRAR
        static public bool RegistrarReserva(Reserva reserva)
        {
            bool exito = true;

            try
            {
                using (var data = new BDAlquilerVehiculoEntities())
                {
                    data.Reserva.Add(reserva);
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
        static public bool ActualizarReserva(Reserva reserva) // referido a objeto
        {
            bool exito = true; // validación del registro
            // para el manejo de excepciones
            try
            {
                using (var data = new BDAlquilerVehiculoEntities())
                {
                    // realizar la consulta y actualizar
                    Reserva actual = data.Reserva.Where(x => x.CodReserva == reserva.CodReserva).FirstOrDefault();// alias

                    actual.CodVehiculo = reserva.CodVehiculo;
                    actual.CodCliente = reserva.CodCliente;
                    actual.FechaReserva = reserva.FechaReserva;
                    actual.Precio = reserva.Precio;
                    actual.NroDias = reserva.NroDias;
                    actual.NroRetraso = reserva.NroRetraso;
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
        static public bool EliminarReserva(int CodReserva) // referido a borrar
        {
            bool exito = true;
            try
            {

                using (var data = new BDAlquilerVehiculoEntities())
                {
                    Reserva actual = data.Reserva.Where(z => z.CodReserva == CodReserva).FirstOrDefault();// alias
                    data.Reserva.Remove(actual);
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
