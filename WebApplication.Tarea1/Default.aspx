<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication.Tarea1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Formulario para tarea #1</h1>
        </section>

        <div class="row">
            <asp:Panel ID="PanelFormulario" runat="server" CssClass="form-group" style="margin-top:30px;">
                <h3>Formulario de Registro</h3>
                <asp:Label ID="LabelNombre" runat="server" Text="Nombre:" AssociatedControlID="TextBoxNombre" />
                <asp:TextBox ID="TextBoxNombre" runat="server" CssClass="form-control" ClientIDMode="Static" />
                <span id="ErrorNombre" style="color: red; display: block;"></span>
                <br />
                <asp:Label ID="LabelCorreo" runat="server" Text="Correo electrónico:" AssociatedControlID="TextBoxCorreo" />
                <asp:TextBox ID="TextBoxCorreo" runat="server" CssClass="form-control" ClientIDMode="Static"/>
                <span id="ErrorCorreo" style="color: red; display: block;"></span>
                <br />
                <asp:Button ID="ButtonEnviar" runat="server" Text="Enviar" CssClass="btn btn-primary" OnClick="ButtonEnviar_Click" ClientIDMode="Static" />
            </asp:Panel>

            <asp:Panel ID="PanelTabla" runat="server" Style="margin-top: 30px;">
                <asp:GridView ID="GridViewDatos" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Correo" HeaderText="Correo electrónico" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </div>
    </main>

    <script src="Scripts/jquery-3.7.0.min.js"></script>
    <script src="Scripts/Formulario.js"></script>
</asp:Content>