<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControl.ascx.cs" Inherits="CMSWebParts_DoctorAppointments_WebUserControl" %>
<asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
<asp:TextBox ID="LastName" runat="server"></asp:TextBox>
<asp:TextBox ID="Email" runat="server"></asp:TextBox>
<asp:TextBox ID="DateOfBirth" runat="server"></asp:TextBox>
<asp:TextBox ID="PhoneNumber" runat="server"></asp:TextBox>
<asp:TextBox ID="DateOfTheAppointment" runat="server"></asp:TextBox>
<asp:DropDownList ID="Doctor" runat="server"></asp:DropDownList>
<asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />