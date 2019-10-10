using BLL;
using Entidades;
using ParcialSegundaOportunidad.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial1SegundaOportunidad.UI
{
    public partial class RegistroFactura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                int id = Utils.ToInt(Request.QueryString["id"]);
                if (id > 0)
                {
                    RepositorioBase<Factura> repositorio = new RepositorioBase<Factura>();
                    Factura user = repositorio.Buscar(id);
                    if (user == null)
                        Utils.ShowToastr(this, "Id no existe", "Error", "error");
                    else
                        LLenarCampo(user);
                }

                ViewState["Factura"] = new Factura();
            }

        }
        private Factura LlenarClase()
        {
            Factura factura = new Factura();
            factura = (Factura)ViewState["Factura"];
            factura.FacturaID = Convert.ToInt32(IdTextBox.Text);
            factura.Nombre = EstudianteTextBox.Text;
            factura.Total = Utils.ToInt(TotalTextBox.Text);
            return factura;
        }

        private void LLenarCampo(Factura factura)
        {
            Limpiar();
            IdTextBox.Text = factura.FacturaID.ToString();
            fechaTextBox.Text = factura.Fecha.ToString();
            EstudianteTextBox.Text = factura.Nombre;
            TotalTextBox.Text = factura.Total.ToString();
            ImporteTextBox.Text = factura.Total.ToString();
            ViewState["Factura"] = factura;
            this.BindGrid();
        }
        public void Limpiar()
        {
            IdTextBox.Text = "0";
            EstudianteTextBox.Text = string.Empty;
            ServicioTextBox.Text = string.Empty;
            CantidadTextBox.Text = 0.ToString();
            PrecioTextBox.Text = 0.ToString();
            ImporteTextBox.Text = 0.ToString();
            TotalTextBox.Text = 0.ToString();
            fechaTextBox.Text = DateTime.Now.ToString();
            ViewState["Factura"] = new Factura();
            GridView.DataSource = null;
            this.BindGrid();
        }

        private bool Validar()
        {
            bool estato = false;

            if (GridView.Rows.Count == 0)
            {
                Utils.ShowToastr(this, "Debe agregar detalle.", "Error", "error");
                estato = true;
            }
            if (String.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                Utils.ShowToastr(this, "Debe tener un Id para guardar", "Error", "error");
                estato = true;
            }
            return estato;
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Factura> rep = new RepositorioBase<Factura>();
            Factura a = rep.Buscar(Convert.ToInt32(IdTextBox.Text));
            if (a != null)
                LLenarCampo(a);
            else
            {
                Limpiar();
                Utils.ShowToastr(this.Page, "Id no exite", "Error", "error");

            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            GridViewRow grid = GridView.SelectedRow;
            RepositorioFactura repositorio = new RepositorioFactura();
            int id = Utils.ToInt(IdTextBox.Text);
            var evaluacion = repositorio.Buscar(id);

            if (evaluacion != null)
            {
                if (repositorio.Eliminar(id))
                {
                    Utils.ShowToastr(this.Page, "Exito Eliminado", "error");
                    Limpiar();
                }
                else
                    Utils.ShowToastr(this.Page, "No Eliminado", "error");
            }


        }
        protected void BindGrid()
        {
            GridView.DataSource = ((Factura)ViewState["Factura"]).Detalles;
            GridView.DataBind();
        }
        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            Factura factura = new Factura();
            decimal total = 0;
            factura.Detalles = new List<FacturaDetalle>();
            factura = (Factura)ViewState["Factura"];
            decimal Importe = Convert.ToDecimal(CantidadTextBox.Text) * Convert.ToDecimal(PrecioTextBox.Text);
            factura.AgragarDetalle(0, Utils.ToInt(IdTextBox.Text),ServicioTextBox.Text, Convert.ToDecimal(CantidadTextBox.Text),
            Convert.ToDecimal(PrecioTextBox.Text), Importe);
            ViewState["Factura"] = factura;
            this.BindGrid();
            foreach (var item in factura.Detalles)
            {
                total += item.Importe;
            }
            TotalTextBox.Text = total.ToString();
        }
        protected void RemoveLinkButton_Click(object sender, EventArgs e)
        {
            if (GridView.Rows.Count > 0 && GridView.SelectedIndex >= 0)
            {
                Factura factura = new Factura();
                factura = (Factura)ViewState["Factura"];
                GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
                factura.RemoverDetalle(row.RowIndex);
                ViewState["Factura"] = factura;
                this.BindGrid();

            }

        }
        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioFactura repositorio = new RepositorioFactura();
            Factura factura = repositorio.Buscar(Utils.ToInt(IdTextBox.Text));

            if (Validar())
            {
                return;
            }
            if (factura == null)
            {
                if (repositorio.Guardar(LlenarClase()))
                {

                    Utils.ShowToastr(this, "Guardado", "Exito", "success");
                    Limpiar();
                }
                else
                {
                    Utils.ShowToastr(this, "No existe", "Error", "error");
                    Limpiar();
                }

            }
            else
            {
                if (repositorio.Modificar(LlenarClase()))
                {
                    Utils.ShowToastr(this.Page, "Modificado con exito!!", "Guardado", "success");
                    Limpiar();
                }
                else
                {
                    Utils.ShowToastr(this.Page, "No se puede modificar", "Error", "error");
                    Limpiar();
                }
            }

        }


    }
}