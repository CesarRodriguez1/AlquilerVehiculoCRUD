using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerVehiculo_DA
{
    public class DAMarca
    {
        static public List<Marca> ListadoMarca()
        {
            List<Marca> marca = new List<Marca>();
            using (var data = new BDAlquilerVehiculoEntities())
            {
                return data.Marca.ToList();
            }
        }
        static public bool RegistrarMarca(Marca marca)
        {
            bool exito = true;

            try
            {
                using (var data = new BDAlquilerVehiculoEntities())
                {
                    data.Marca.Add(marca); 
                    data.SaveChanges();
                }
            }
            catch (Exception)
            {
                exito = false;
                
            }
            return exito;
        }
        static public bool ActualizarMarca(Marca marca)
        {
            bool exito = true;

            try
            {
                using (var data = new BDAlquilerVehiculoEntities())
                {
                
                    Marca actual = data.Marca.Where(x => x.CodMarca == marca.CodMarca).FirstOrDefault();
                  
                    actual.Descripcion = marca.Descripcion;
                    actual.Pais = marca.Pais;
                  
                    data.SaveChanges();
                }
            }
            catch (Exception)
            {
                exito = false;
          
            }
            return exito;
        }
        static public bool EliminarMarca(string marcaID)
        {
            bool exito = true;

            try
            {
                using (var data = new BDAlquilerVehiculoEntities())
                {
                    Marca actual = data.Marca.Where(x => x.CodMarca == marcaID).FirstOrDefault();
                    data.Marca.Remove(actual);
                    data.SaveChanges();
                }
            }
            catch (Exception)
            {
                exito = false;
      
            }
            return exito;
        }
    }
}
