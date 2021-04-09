<%@ Page Title="MstSection_Edit" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MstSection_Edit.aspx.cs" Inherits="MstSection_Edit" %>
<%@  Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
<link rel="stylesheet" href="style/StyleSheet.css" type="text/css" />
<link rel="Stylesheet" href="style/Master.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="sc1" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="up1" runat="server">
<ContentTemplate>
<table border="2px" frame="void" 
        style="border-color: #753D31; border-style: solid; height: 138px; width: 314px;";">
        <tr><td colspan="3"  style="background-color:#753D31; color:White;" align="center" > Section  Master Edit Record </td></tr>

<tr>
<td>Section Name</td>
<td><asp:TextBox ID="txtsname" runat="server"></asp:TextBox></td>
<td>
    <asp:RequiredFieldValidator ID="reqname" runat="server" ErrorMessage="*Required" ControlToValidate="txtsname"></asp:RequiredFieldValidator></td>
</tr>
<tr>
<td>Header Name:</td>
<td><asp:TextBox ID="txth" runat="server" ></asp:TextBox></td>
<td>
    <asp:RequiredFieldValidator ID="reqh" runat="server" ErrorMessage="*Required" ControlToValidate="txth"></asp:RequiredFieldValidator></td>
</tr>
<tr>
<td>Description:</td>
<td> <CKEditor:CKEditorControl ID="ck1" runat="server" Height="139px" Width="450px"></CKEditor:CKEditorControl></td>
</tr>
<tr>
<td colspan="2" align="center">
    <asp:Button ID="btnedit" runat="server" Text="Edit" 
       Width="86px" onclick="btnedit_Click" /></td>
</tr>
<tr>
<td align="right" colspan="2"><asp:HyperLink ID="hlink" runat="server" Text="Back" NavigateUrl="~/MstSection_View.aspx">Back</asp:HyperLink></td>
</tr>
</table>
<asp:Label ID="lblmsg" runat="server"></asp:Label>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

