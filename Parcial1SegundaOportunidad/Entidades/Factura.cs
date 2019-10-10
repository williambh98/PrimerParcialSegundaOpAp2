using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Factura
    {
        
            [Key]
            public int FacturaID { get; set; }
            public string Nombre { get; set; }
            public decimal Total { get; set; }
            public DateTime Fecha { get; set; }
            public virtual List<FacturaDetalle> Detalles { get; set; }
            public Factura()
            {
                FacturaID = 0;
                this.Nombre = string.Empty;
                this.Total = 0;
                Fecha = DateTime.Now;
                Detalles = new List<FacturaDetalle>();
            }

            public Factura(int facturaID, string nombre, decimal total, DateTime fecha, List<FacturaDetalle> detalles)
            {
            FacturaID = facturaID;
                this.Nombre = nombre;
                Total = total;
                Fecha = fecha;
                this.Detalles = detalles;
            }

            public void AgragarDetalle(int DetalleID, int FacturaID, string nombre, decimal cantidad, decimal precio, decimal importe)
            {
                this.Detalles.Add(new FacturaDetalle(DetalleID, FacturaID, nombre, cantidad, precio, importe));
            }

            public void RemoverDetalle(int Index)
            {
               this.Detalles.RemoveAt(Index);
            }

        }
    }

