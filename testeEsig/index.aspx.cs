using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Diagnostics;

namespace testeEsig
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Carregamento da página e ligação do ListView
            if (!IsPostBack)
            {
                BindListView();
            }
        }

        private void BindListView()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlQuery = "SELECT Pessoa.ID, Pessoa.Nome, Cargo.Nome AS CargoNome, Pessoa_Salario.Salario " +
                                      "FROM Pessoa " +
                                      "INNER JOIN Cargo ON Pessoa.CARGO_ID = Cargo.ID " +
                                      "INNER JOIN Pessoa_Salario ON Pessoa.ID = Pessoa_Salario.Pessoa_ID";

                    using (OracleCommand command = new OracleCommand(sqlQuery, connection))
                    {
                        using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            listViewDados.DataSource = dt.DefaultView;
                            listViewDados.DataBind();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("caiu aqui");
                }
            }
        }

        protected void listViewDados_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            dataPagerDados.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            BindListView();
        }
    }
}
