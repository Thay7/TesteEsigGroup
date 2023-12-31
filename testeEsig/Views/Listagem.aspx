﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Listagem.aspx.cs" Inherits="testeEsig.Views.Listagem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!DOCTYPE html>
    <html>
    <head>
        <title>Listagem</title>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
        <link href="~/Content/sweetalert2.min.css" rel="stylesheet" />
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" />
        <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
        <script src="~/Scripts/sweetalert2.all.min.js"></script>
    </head>
    <body>
        <div class="m-4">
            <div style="display: flex; flex-direction: row; justify-content: space-between; margin-bottom: 10px;">
                <h4></h4>
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-danger btn-rad btn-trans"
                    CommandName='<%# Bind("ID") %>' CommandArgument='<%# Bind("ID") %>'
                    data-placement="top" data-toggle="tooltip" OnClick="lkSair_Click" data-original-title="Sair"
                    Text='Sair'>
                </asp:LinkButton>
            </div>
            <hr />
            <div style="display: flex; flex-direction: row; justify-content: space-between;">
                <h4>Listagem de Pessoas</h4>
                <div>
                    <asp:LinkButton ID="lkCalculaRecalculaSalario" runat="server" CssClass="btn btn-primary btn-rad btn-trans"
                        CommandName='<%# Bind("ID") %>' CommandArgument='<%# Bind("ID") %>'
                        data-placement="top" data-toggle="tooltip" OnClick="lkCalculaRecalculaSalario_Click" data-original-title="Calcular/Recalcular Salario"
                        Text='<i class="fa fa-calculator" style="font-size: 15px; margin-right: 5px;"></i> Calcular/Recalcular Salários'>
                    </asp:LinkButton>
                </div>
            </div>
            <asp:ListView ID="listViewDados" runat="server" ItemType="System.Data.DataRowView" DataKeyNames="ID"
                OnPagePropertiesChanging="listViewDados_PagePropertiesChanging">
                <LayoutTemplate>
                    <table class="table table-hover table-striped table-bordered" style="margin-top: 20px;">
                        <thead>
                            <tr>
                                <th>Nome</th>
                                <th>Cidade</th>
                                <th>E-mail</th>
                                <th>CEP</th>
                                <th>Endereço</th>
                                <th>País</th>
                                <th>Usuário</th>
                                <th>Telefone</th>
                                <th>Data de Nascimento</th>
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
                        <td><%# Eval("Cidade") %></td>
                        <td><%# Eval("Email") %></td>
                        <td><%# Eval("CEP") %></td>
                        <td><%# Eval("Endereco") %></td>
                        <td><%# Eval("Pais") %></td>
                        <td><%# Eval("Usuario") %></td>
                        <td><%# Eval("Telefone") %></td>
                        <td><%# Eval("Data_Nascimento") %></td>
                        <td><%# Eval("Cargo_Nome") %></td>
                        <td><%# Eval("Salario") != DBNull.Value ? Convert.ToDecimal(Eval("Salario")).ToString("C2") : "" %></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <asp:DataPager ID="dataPagerDados" runat="server" PagedControlID="listViewDados" PageSize="7">
                <Fields>
                    <asp:NumericPagerField ButtonCount="5" />
                </Fields>
            </asp:DataPager>
            <hr />
        </div>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.min.js"></script>
    </body>
    </html>
</asp:Content>
