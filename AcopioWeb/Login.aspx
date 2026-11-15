<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.vb" Inherits="AcopioWeb.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4" style="max-width: 480px;">
        <h2>Ingresar</h2>
        <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
        <div class="mb-3 mt-3">
            <label class="form-label">Correo</label>
            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Contraseña</label>
            <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
        </div>
        <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="btn btn-primary" />
    </div>
</asp:Content>
