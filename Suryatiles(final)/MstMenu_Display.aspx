<%@ Page Title="MstMenu_Display" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MstMenu_Display.aspx.cs" Inherits="MstMenu_Display" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">

 <link rel="stylesheet" href="style/StyleSheet.css" type="text/css" />
    <link rel="Stylesheet" href="style/Master.css" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div>
    <table>
    <tr><td colspan="3" align="center" style="background-color:#753D31; color:White"> Menu Master View Record </td></tr>
<tr>
<td>Menu Group Name</td>
<td><asp:DropDownList ID="ddmgnm" runat="server" AppendDataBoundItems="true" 
        Enabled="False" Visible="false">
    </asp:DropDownList>
    <asp:TextBox ID="txtddmgnm" runat="server" ReadOnly="true"></asp:TextBox>
  </td>
<td>
    &nbsp;</td>
</tr>
<tr>
<td>Parent Menu Name</td>
<td><asp:DropDownList ID="ddlpmsno" runat="server" Enabled="False" Visible="false" >
    </asp:DropDownList>
     <asp:TextBox ID="txtddlpmsno" runat="server" ReadOnly="true"></asp:TextBox>
    </td>
<td></td>
</tr>
<tr>
<td>Menu Name</td>
<td><asp:TextBox ID="txtmnm" runat="server" ReadOnly="true"></asp:TextBox></td>
</tr>
<tr>
<td>Priority</td>
<td>
<asp:TextBox ID="txtpr" runat="server" ReadOnly="true"></asp:TextBox>
</td>


</tr>
<tr>
<td>Is URL</td>
<td><asp:DropDownList ID="ddlurl" runat="server" ReadOnly="true" Visible="false">
    <asp:ListItem>Yes</asp:ListItem>
    <asp:ListItem>No</asp:ListItem>
    </asp:DropDownList>
     <asp:TextBox ID="txtddlurl" runat="server" ReadOnly="true"></asp:TextBox>
    </td>
<td>
    <asp:RequiredFieldValidator ID="reurl" runat="server" ErrorMessage="*Required" ControlToValidate="ddlurl"></asp:RequiredFieldValidator></td>

</tr>
<tr>
<td>Module Name</td>
<td><asp:DropDownList ID="ddlmnm" runat="server" Enabled="False" Visible="false" >
    </asp:DropDownList>
     <asp:TextBox ID="txtddlmnm" runat="server" ReadOnly="true"></asp:TextBox>
    </td>
<td></td>
</tr>

<tr>
<td>Folder Path</td>
<td>
<asp:TextBox ID="txtfpath" runat="server" ReadOnly="true"></asp:TextBox>
</td>
<td></td>
</tr>
<tr>
<td>Page Name</td>
<td>
<asp:TextBox ID="txtpname" runat="server" ReadOnly="true"></asp:TextBox>
</td>
<td></td>
</tr>
<tr>
<td>Folder Path PageName</td>
<td>
<asp:TextBox ID="txtfppnm" runat="server" ReadOnly="true"></asp:TextBox>
</td>
<td></td>
</tr>
<tr>
<td>Page Title</td>
<td>
<asp:TextBox ID="txtptitle" runat="server" ReadOnly="true"></asp:TextBox>
</td>
<td>
    <asp:RequiredFieldValidator ID="reptitle" runat="server" ErrorMessage="*Required" ControlToValidate="txtptitle"></asp:RequiredFieldValidator>
</td>

</tr>
<tr>
<td>Page Description</td>
<td>
<asp:TextBox ID="txtpdesc" runat="server" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
<%--<CKEditor:CKEditorControl id="ck1" runat="server"></CKEditor:CKEditorControl>
</td>--%>
<td></td>
</tr>

<tr>
<td>Hits</td>
<td>
<asp:TextBox ID="txthits" runat="server" ReadOnly="true"></asp:TextBox>
</td>
<td></td>
</tr>
<tr>
<td>Facebook Like Code</td>
<td>
<asp:TextBox ID="txtfcode" runat="server" ReadOnly="true"></asp:TextBox>
</td>
<td></td>
</tr>
<tr>
<td>Email To</td>
<td>
<asp:TextBox ID="txtemailto" runat="server" ReadOnly="true"></asp:TextBox>
</td>
<td></td>
</tr>
<tr>
<td>Email Cc</td>
<td>
<asp:TextBox ID="txtemailcc" runat="server" ReadOnly="true"></asp:TextBox>
</td>
<td></td>
</tr>
<tr>
<td>Active</td>
<td><asp:DropDownList ID="ddlactive" runat="server" Visible="false">
    <asp:ListItem>Yes</asp:ListItem>
    <asp:ListItem>No</asp:ListItem>
    </asp:DropDownList>
     <asp:TextBox ID="txtddlactive" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:RequiredFieldValidator ID="reqactive" runat="server" ErrorMessage="*Required" ControlToValidate="ddlactive"></asp:RequiredFieldValidator>
</td>

</tr>

<tr>
<td colspan="3">
<asp:ScriptManager ID="sm1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="up1" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pHeader" runat="server" CssClass="cpHeader">
        <asp:Label ID="lblText" runat="server"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="pBody" runat="server" CssClass="cpBody">
<table>
 <tr>
<td>Title</td>
<td>
<asp:TextBox ID="txttitle" runat="server" ReadOnly="true"></asp:TextBox>
</td>
</tr>
<tr>
<td>Keyword</td>
<td>
<asp:TextBox ID="txtkey" runat="server" ReadOnly="true"></asp:TextBox>
</td>
</tr>
<tr>
<td>Description</td>
<td>
<asp:TextBox ID="txtdesc" runat="server" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
</td> 
</tr>
<tr>
<td>Other Meta Lines</td>
<td>
<asp:TextBox ID="txtmline" runat="server" ReadOnly="true"></asp:TextBox>
</td>
</tr>


</table>
</asp:Panel>
<cc1:CollapsiblePanelExtender ID="cc2" runat="server" TargetControlID="pBody" CollapseControlID="pHeader" Collapsed="true" ExpandControlID="pHeader" TextLabelID="lblText" CollapsedText="+SEO Setting" ExpandedText="-SEO Setting" CollapsedSize="0">
    </cc1:CollapsiblePanelExtender>
    </ContentTemplate>
    </asp:UpdatePanel>
    
</td>
</tr>
   <tr>
   <td>
   <asp:Label ID="lblmsg" runat="server"></asp:Label>
   </td>
   <td align="right" colspan="2"><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/MstMenu_View.aspx">Back</asp:HyperLink></td>
   </tr>
</table>
    </div>

</asp:Content>

