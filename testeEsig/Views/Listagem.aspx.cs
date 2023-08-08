using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Diagnostics;

namespace testeEsig.Views
{
    public partial class Listagem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                    string sqlQuery = "SELECT Pessoa.*, Cargo.Nome AS Cargo_Nome, Pessoa_Salario.* " +
                                      "FROM Pessoa " +
                                      "INNER JOIN Cargo ON Pessoa.CARGO_ID = Cargo.ID " +
                                      "LEFT JOIN Pessoa_Salario ON Pessoa.ID = Pessoa_Salario.Pessoa_ID " +
                                      "ORDER BY Pessoa.Nome ASC";

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
                    string errorMessage = ex.Message.Replace("'", "\\'");
                    ExibeModalError(errorMessage);
                }
            }
        }

        protected void listViewDados_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            dataPagerDados.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            BindListView();
        }

        protected void lkCalculaRecalculaSalario_Click(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (OracleCommand command = new OracleCommand("calcular_salarios", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();
                    }

                    BindListView();
                    ExibeModalSucesso();
                }
                catch (Exception ex)
                {
                    string errorMessage = ex.Message.Replace("'", "\\'");
                    ExibeModalError(errorMessage);
                }
            }
        }

        protected void lkSair_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void ExibeModalSucesso()
        {
            string script = @"
                    <script>
                        Swal.fire('Sucesso!', 'Salários Calculados/Recalculados com sucesso!', 'success');
                    </script>";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script, false);
        }
        protected void ExibeModalError(string errorMessage)
        {
            string script = $@"
                        <script>
                            Swal.fire('Erro!', '{errorMessage}', 'error');
                        </script>";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script, false);
        }
    }
}