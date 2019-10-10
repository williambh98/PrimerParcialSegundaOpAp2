using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
   public class FacturaDetalle
    {
        [Key]
        public int DetalleID { get; set; }
        public int FacturaID { get; set; }
        public string servicio { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Importe { get; set; }

        [ForeignKey("FacturaID")]
        public virtual Factura factura { get; set; }

        public FacturaDetalle()
        {
            this.DetalleID = 0;
            this.FacturaID = 0;
            this.servicio = string.Empty;
            this.Cantidad = 0;
            this.Precio = 0;
            this.Importe = 0;

        }

        public FacturaDetalle(int detalleID, int facturaID, string servicio, decimal cantidad, decimal precio, decimal importe)
        {
            DetalleID = detalleID;
            FacturaID = facturaID;
            this.servicio = servicio;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
        }
    }
}
