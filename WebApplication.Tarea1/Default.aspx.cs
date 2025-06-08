using System;
using System.Collections.Generic;
using System.Web.UI;

namespace WebApplication.Tarea1
{
    public partial class _Default : Page
    {
        private List<string[]> DatosIngresados
        {
            get
            {
                // Usar ViewState para mantener los datos entre postbacks
                if (ViewState["DatosIngresados"] == null)
                    ViewState["DatosIngresados"] = new List<string[]>();
                return (List<string[]>)ViewState["DatosIngresados"];
            }
            set
            {
                ViewState["DatosIngresados"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridViewDatos.DataSource = DatosIngresados;
                GridViewDatos.DataBind();
            }
        }

        protected void ButtonEnviar_Click(object sender, EventArgs e)
        {
            string nombre = TextBoxNombre.Text.Trim();
            string correo = TextBoxCorreo.Text.Trim();

            // Validar que no estén vacíos
            if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(correo))
            {
                // Agregar los datos a la lista
                var lista = DatosIngresados;
                lista.Add(new string[] { nombre, correo });
                DatosIngresados = lista;

                // Actualizar el GridView
                GridViewDatos.DataSource = DatosIngresados;
                GridViewDatos.DataBind();

                // Limpiar los campos
                TextBoxNombre.Text = "";
                TextBoxCorreo.Text = "";
            }
        }
    }
}