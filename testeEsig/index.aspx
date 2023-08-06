<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="testeEsig.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!DOCTYPE html>
    <html>
    <head>
        <title>Listagem</title>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
        <link href="~/Content/fontawesome.css" rel="stylesheet" />
    </head>
    <body>
        <div class="container mt-5">
            <div style="display: flex; flex-direction: row; justify-content: space-between; margin-bottom: 20px">
                <h2 class="headwi primary">Listagem Pessoas</h2>
                <asp:LinkButton ID="lkCalculaRecalculaSalario" runat="server" CssClass="btn btn-primary btn-rad btn-trans"
                    CommandName='<%# Bind("ID") %>' CommandArgument='<%# Bind("ID") %>'
                    data-placement="top" data-toggle="tooltip" data-original-title="Calcular/Recalcular Salario" Text="Calcular/Recalcular Salário">
                </asp:LinkButton>
            </div>
            <asp:ListView ID="listViewDados" runat="server" ItemType="System.Data.DataRowView" DataKeyNames="ID"
                OnPagePropertiesChanging="listViewDados_PagePropertiesChanging">
                <LayoutTemplate>
                    <table class="table table-hover table-striped table-bordered">
                        <thead>
                            <tr>
                                <th>Nome</th>
                                <th>Cargo</th>
                                <th>Salário</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td style="display: none;"><%# Eval("ID") %></td>
                        <td><%# Eval("Nome") %></td>
                        <td><%# Eval("CargoNome") %></td>
                        <td><%# Eval("Salario") %></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <asp:DataPager ID="dataPagerDados" runat="server" PagedControlID="listViewDados" PageSize="10">
                <Fields>
                    <asp:NumericPagerField ButtonCount="5" />
                </Fields>
            </asp:DataPager>
        </div>
        <!-- Adicione mais linhas aqui, se necessário -->
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.min.js"></script>
    </body>
    </html>
</asp:Content>
