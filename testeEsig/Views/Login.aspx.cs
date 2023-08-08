using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;

namespace testeEsig.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString;
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlQuery = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = :Username AND Senha = :Password";

                    using (OracleCommand command = new OracleCommand(sqlQuery, connection))
                    {
                        command.Parameters.Add(":Username", OracleDbType.Varchar2).Value = username;
                        command.Parameters.Add(":Password", OracleDbType.Varchar2).Value = password;

                        int count = Convert.ToInt32(command.ExecuteScalar());
                        if (count > 0)
                        {
                            Response.Redirect("Listagem.aspx");
                        }
                        else
                        {
                            string script = $@"
                                    <script>
                                        Swal.fire('Erro!', 'Usuário ou senha incorretos!', 'error');
                                    </script>";
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", script, false);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessage = ex.Message.Replace("'", "\\'");
                    string script = $@"
                        <script>
                            Swal.fire('Erro!', '{errorMessage}', 'error');
                        </script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, false);
                }
            }
        }


    }
}