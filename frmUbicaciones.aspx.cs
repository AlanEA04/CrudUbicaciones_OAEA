using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Capas
using  BILL;
using DAL;

namespace CrudUbicaciones_OAEA
{
    public partial class frmUbicaciones : System.Web.UI.Page
    {
        Ubicaciones_BILL oUbicaciones_BILL;
        Ubicaciones__DAL oUbicaciones__DAL;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ListarUbicacion();
            }
           
        }

        //Metodo encargado de listra los datos de la BD en un Griview
        public void ListarUbicacion()
        {
            oUbicaciones__DAL = new Ubicaciones__DAL();
            gvUbicaciones.DataSource = oUbicaciones__DAL.Listar();
            gvUbicaciones.DataBind();
        }

        //Recolectar datos de la capa de presentacion
        public Ubicaciones_BILL datosUbicacion()
        {
            int ID = 0;
            int.TryParse(txtID.Value, out ID);
            oUbicaciones_BILL =  new Ubicaciones_BILL();
            oUbicaciones_BILL.ID = ID;
            oUbicaciones_BILL.Ubicacion = txtUbicacion.Text;
            oUbicaciones_BILL.Latitud = txtLat.Text;
            oUbicaciones_BILL.Longitud = txtLong.Text;



            return oUbicaciones_BILL;

        }





        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

   
        protected void AgregarRegistro(object sender, EventArgs e)
        {
            oUbicaciones__DAL = new Ubicaciones__DAL();
            oUbicaciones__DAL.Agregrar(datosUbicacion());
            ListarUbicacion(); //Para mostarlo en el GV
        }

        protected void EliminarRegistro(object sender, EventArgs e)
        {
            oUbicaciones__DAL = new Ubicaciones__DAL();
            oUbicaciones__DAL.Eliminar(datosUbicacion());
            ListarUbicacion();
        }

        protected void SeleccionarRegistro(object sender, GridViewCommandEventArgs e)
        {
            int FilaSelecionada = int.Parse(e.CommandArgument.ToString());

            txtID.Value = gvUbicaciones.Rows[FilaSelecionada].Cells[1].Text;
            txtUbicacion.Text = gvUbicaciones.Rows[FilaSelecionada].Cells[2].Text;
            txtLat.Text = gvUbicaciones.Rows[FilaSelecionada].Cells[3].Text;
            txtLong.Text = gvUbicaciones.Rows[FilaSelecionada].Cells[4].Text;
            // AHORA AL MOMENTO QIE DICES CLICK EN " SELECCIONAR " HABILITAREMOS
            //LOS BOTONES  ELIMINAR Y MODIFICAR  Y A LA VEZ INABILITAREMOS
            // EL BOTON AGREGAR

            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
            btnAgregar.Enabled = true;


        }

        protected void ModificarRegistro(object sender, EventArgs e)
        {
            oUbicaciones__DAL = new Ubicaciones__DAL();
            oUbicaciones__DAL.Modificar(datosUbicacion());
            ListarUbicacion();

        }

        protected void LimpiarRegistro(object sender, EventArgs e)
        {
            txtLat.Text = "27.365938954017043";
            txtLong.Text = "-109.93136356074504";
            btnAgregar.Enabled = true;
        }
    }
}