<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Consultar.aspx.vb" Inherits="AcopioWeb.Consultar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2>Consultar entregas</h2>
        <asp:GridView ID="gvEntregas" runat="server" AutoGenerateColumns="False"
            AllowPaging="True" PageSize="8"
            CssClass="table table-striped table-bordered"
            EmptyDataText="No hay entregas registradas.">
            <Columns>
                <asp:BoundField DataField="Boleta" HeaderText="Boleta" />
                <asp:BoundField DataField="Productor" HeaderText="Productor" />
                <asp:BoundField DataField="PesoKg" HeaderText="Peso (kg)" DataFormatString="{0:N0}" />
                <asp:BoundField DataField="Calidad" HeaderText="Calidad" />
                <asp:BoundField DataField="Pago" HeaderText="Pago" DataFormatString="₡{0:N0}" />
                <asp:BoundField DataField="UsuarioRegistro" HeaderText="Registrado por" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
