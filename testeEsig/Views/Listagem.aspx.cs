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
                                      "ORDER BY Pessoa.ID ASC";

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

        protected void lkCalculaRecalculaSalario_Click(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Chame a procedure aqui usando OracleCommand
                    using (OracleCommand command = new OracleCommand("calcular_salarios", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        // Defina os parâmetros da sua procedure, se houver

                        // Execute a procedure
                        command.ExecuteNonQuery();
                    }

                    // Após executar a procedure, atualize os dados na ListView chamando o método BindListView
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showSuccessModal", "$('#successModal').modal('show');", true);
                    BindListView();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Erro ao calcular/recalcular salários: " + ex.Message);
                }
            }
        }
    }
}