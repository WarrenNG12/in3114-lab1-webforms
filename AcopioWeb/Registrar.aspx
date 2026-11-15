<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Registrar.aspx.vb" Inherits="AcopioWeb.Registrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4" style="max-width: 600px;">
        <h2>Registrar entrega</h2>

        <asp:ValidationSummary ID="resumen" runat="server" CssClass="alert alert-danger" HeaderText="Corrija lo siguiente:" />
        <asp:Label ID="lblResultado" runat="server" Visible="false" CssClass="alert alert-success d-block"></asp:Label>

        <div class="mb-3">
            <label class="form-label">Productor</label>
            <asp:DropDownList ID="ddlProductor" runat="server" CssClass="form-select" AppendDataBoundItems="true">
                <asp:ListItem Value="" Text="-- Seleccione --"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvProductor" runat="server" ControlToValidate="ddlProductor"
                InitialValue="" ErrorMessage="Seleccione un productor." Text="*" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>

        <div class="mb-3">
            <label class="form-label">Número de boleta (ejemplo: B-000123)</label>
            <asp:TextBox ID="txtBoleta" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvBoleta" runat="server" ControlToValidate="txtBoleta"
                ErrorMessage="La boleta es obligatoria." Text="*" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revBoleta" runat="server" ControlToValidate="txtBoleta"
                ValidationExpression="^B-\d{6}$" ErrorMessage="La boleta debe ser B- seguido de seis dígitos."
                Text="*" CssClass="text-danger" Display="Dynamic"></asp:RegularExpressionValidator>
            <asp:CustomValidator ID="cvBoleta" runat="server" ControlToValidate="txtBoleta"
                ErrorMessage="Esa boleta ya fue registrada." Text="*" CssClass="text-danger" Display="Dynamic"></asp:CustomValidator>
        </div>

        <div class="mb-3">
            <label class="form-label">Peso neto (kg)</label>
            <asp:TextBox ID="txtPeso" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPeso" runat="server" ControlToValidate="txtPeso"
                ErrorMessage="El peso es obligatorio." Text="*" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rvPeso" runat="server" ControlToValidate="txtPeso" Type="Integer"
                MinimumValue="100" MaximumValue="30000" ErrorMessage="El peso debe ser un número entero entre 100 y 30 000."
                Text="*" CssClass="text-danger" Display="Dynamic"></asp:RangeValidator>
        </div>

        <div class="mb-3">
            <label class="form-label d-block">Calidad</label>
            <asp:RadioButtonList ID="rblCalidad" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="A" Text="A &nbsp;&nbsp;"></asp:ListItem>
                <asp:ListItem Value="B" Text="B &nbsp;&nbsp;"></asp:ListItem>
                <asp:ListItem Value="C" Text="C"></asp:ListItem>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="rfvCalidad" runat="server" ControlToValidate="rblCalidad"
                ErrorMessage="Seleccione la calidad." Text="*" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>

        <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-primary" />
    </div>
</asp:Content>
