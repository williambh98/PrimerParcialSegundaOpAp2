using DAL;
using Entidades;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class RepositorioFactura : RepositorioBase<Factura>
    {
        public override Factura Buscar(int id)
        {
            Factura facturas = new Factura();
            Contexto contexto = new Contexto();
            try
            {
                facturas = contexto.Factura.Include(t=>t.Detalles).Where(x => x.FacturaID == id).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return facturas;
        }
        public override bool Modificar(Factura factura)
        {
            var Anterior = Buscar(factura.FacturaID);
            bool paso = false;

            try
            {
                using (Contexto contexto = new Contexto())
                {
                    foreach (var item in Anterior.Detalles.ToList())
                    {
                        if (!factura.Detalles.Exists(d => d.DetalleID == item.DetalleID))
                        {
                            contexto.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                        }
                    }
                    contexto.SaveChanges();
                }
                foreach (var item in factura.Detalles)
                {
                    var estado = item.DetalleID > 0 ? EntityState.Unchanged : EntityState.Added;
                    _contexto.Entry(item).State = estado;
                }
                _contexto.Entry(factura).State = EntityState.Modified;
                if (_contexto.SaveChanges() > 0)
                    paso = true;
            }
            catch
            {
                throw;
            }
            return paso;
        }

    }
}

