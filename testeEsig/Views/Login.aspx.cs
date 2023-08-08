using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

            if (username == "user" && password == "password")
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
}