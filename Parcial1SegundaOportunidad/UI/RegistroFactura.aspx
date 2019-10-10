<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroFactura.aspx.cs" Inherits="Parcial1SegundaOportunidad.UI.RegistroFactura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading">Registros Factura</div>
            <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">
                    <%--IdFactura--%>
                    <div class="form-group">
                        <label for="IdTextBox" class="col-md-3 control-label input-sm">ID: </label>
                        <div class="col-md-4">
                            <asp:TextBox CssClass="form-control input-sm" TextMode="Number" ID="IdTextBox" Text="0" runat="server"></asp:TextBox>
                        </div>
                        <asp:Button CssClass="col-md-1 btn btn-info btn-sm" ID="BuscarButton" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
                        <label for="fechaTextBox" class="col-md-2 control-label input-sm">Fecha: </label>
                        <div class="col-md-2">
                            <asp:TextBox CssClass="form-control" ID="fechaTextBox" TextMode="Date" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <%--Estudiante--%>
                    <div class="form-group">
                        <label for="EstudianteID" class="col-md-3 control-label input-sm">Estudiante: </label>
                        <div class="col-md-6">
                            <asp:TextBox CssClass="form-control input-sm" ID="EstudianteTextBox" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="EstudianteID" runat="server" MaxLength="200"
                                ControlToValidate="EstudianteTextBox"
                                ErrorMessage="Campo Estudiante obligatorio" ForeColor="Red"
                                Display="Dynamic" SetFocusOnError="True"
                                ToolTip="Campo Estudiante obligatorio" ValidationGroup="Guardar">Por favor llenar el campo Estudiante
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <%--Servicio--%>
                    <div class="form-group">
                        <label for="Servicio" class="col-md-3 control-label input-sm">Servicio: </label>
                        <div class="col-md-6">
                            <asp:TextBox CssClass="form-control input-sm" ID="ServicioTextBox" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" MaxLength="200"
                                ControlToValidate="ServicioTextBox"
                                ErrorMessage="Campo Servicio obligatorio" ForeColor="Red"
                                Display="Dynamic" SetFocusOnError="True"
                                ToolTip="Campo Servicio obligatorio" ValidationGroup="Guardar">Por favor llenar el campo Estudiante
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>


                    <%-- Cantidad--%>
                    <div class="form-group">
                        <label for="Cantidad:" class="col-md-3 control-label input-sm">Cantidad: </label>
                        <div class="col-md-6">
                            <asp:TextBox class="form-control input-sm" TextMode="Number" ID="CantidadTextBox" Text="0" runat="server" Visible="true"></asp:TextBox>
                        </div>
                    </div>

                    <%-- Precio--%>
                    <div class="form-group">
                        <label for="Precio:" class="col-md-3 control-label input-sm">Precio: </label>
                        <div class="col-md-6">
                            <asp:TextBox class="form-control input-sm" TextMode="Number" ID="PrecioTextBox" Text="0" runat="server" Visible="true"></asp:TextBox>
                        </div>
                    </div>

                    <%-- Importe--%>
                    <div class="form-group">
                        <label for="Importe:" class="col-md-3 control-label input-sm">Importe: </label>
                        <div class="col-md-6">
                            <asp:TextBox class="form-control input-sm" ReadOnly="True" TextMode="Number" ID="ImporteTextBox" Text="0" runat="server" Visible="true"></asp:TextBox>
                        </div>
                        <asp:Button class="btn btn-info btn-sm" ID="AgregardoButton" runat="server" Text="Agregar" OnClick="AgregarButton_Click" />
                    </div>
                    <div class="table-responsive">
                        <div class="center">
                            <asp:GridView ID="GridView"
                                runat="server"
                                class="table table-condensed table-bordered table-responsive"
                                CellPadding="4" ForeColor="#333333" GridLines="None">

                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField ShowHeader="False" HeaderText="Remover">
                                        <ItemTemplate>
                                            <asp:Button ID="RemoveLinkButton" runat="server" CausesValidation="false" CommandName="Select"
                                                Text="Remover " class="btn btn-success btn-sm" OnClick="RemoveLinkButton_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>                                                             
                                </Columns>
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#EFF3FB" />
                            </asp:GridView>
                        </div>
                    </div>
                     <div class="form-group">
                        <label for="Total:" class="col-md-3 control-label input-sm">Total: </label>
                        <div class="col-md-4">
                            <asp:TextBox class="form-control input-sm" ReadOnly="True" ID="TotalTextBox" Text="0" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <div class="panel-footer">
            <div class="text-center">
                <div class="form-group" style="display: inline-block">

                    <asp:Button Text="Nuevo" CssClass="btn btn-warning btn-sm" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
                    <asp:Button Text="Guardar" CssClass="btn btn-success btn-sm" runat="server" ID="GuadarButton" OnClick="GuardarButton_Click" ValidationGroup="Guardar" />
                    <asp:Button Text="Eliminar" CssClass="btn btn-danger btn-sm" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click" />
                    <asp:RequiredFieldValidator ID="EliminarRequiredFieldValidator" CssClass="col-md-1 col-sm-1" runat="server" ControlToValidate="IdTextBox" ErrorMessage="Es necesario elegir ID valido para eliminar" ValidationGroup="Eliminar">Porfavor elige un ID valido.</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="EliminarRegularExpressionValidator" CssClass="col-md-1 col-sm-1 col-md-offset-1 col-sm-offset-1" runat="server" ControlToValidate="PresupuestoTextBox" ErrorMessage="RegularExpressionValidator" ValidationExpression="\d+ " ValidationGroup="Eliminar" Visible="False"></asp:RegularExpressionValidator>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
