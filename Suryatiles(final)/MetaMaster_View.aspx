<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MetaMaster_View.aspx.cs" Inherits="MetaMaster_View" EnableEventValidation="false" MasterPageFile="~/MasterPage.master" Title="MetaMaster_Edit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
    <link rel="stylesheet" href="style/StyleSheet.css" type="text/css" />
    <link rel="Stylesheet" href="style/Master.css" type="text/css" />
</asp:Content>
<asp:Content ID="c4" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
      <br /><br />
      <div>
       <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                </asp:SiteMapPath>
    <asp:ScriptManager ID="scm1" runat="server"></asp:ScriptManager>
    
       <asp:Panel ID="Panel1" runat="server" BorderWidth="2px" BorderColor="#996633" 
          Width="482px"  Height="59px" >
          <div dir="rtl">
           <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/add3.jpg" 
               CssClass="add" PostBackUrl="~/MetaMaster_Add.aspx" ToolTip="Add" 
                />&nbsp;&nbsp;        
            <asp:ImageButton ID="imgexport" runat="server" ImageUrl="~/images/pdf.jpg" 
                  ToolTip="Export To PDF" CssClass="add" onclick="imgexport_Click" />&nbsp;&nbsp;
              <br />
            </div>
            <div class="dir">
            <asp:TextBox ID="txtname" runat="server"></asp:TextBox>&nbsp;&nbsp;
              <asp:DropDownList ID="ddlsearch" runat="server" 
                    onselectedindexchanged="ddlsearch_SelectedIndexChanged" 
                    AutoPostBack="True">
             <asp:ListItem Value="Meta Name">Meta Name</asp:ListItem>
             <asp:ListItem Value="All Records">All Records</asp:ListItem>
             <asp:ListItem Value="Meta Tags">Meta Tags</asp:ListItem>
             </asp:DropDownList>&nbsp;
             
                <asp:Button ID="btnsearch" runat="server"  Text="Search" 
                    onclick="btnsearch_Click" />
             
             </div>
             
    </asp:Panel>
    <asp:UpdatePanel ID="gdupdate" runat="server" >
    <ContentTemplate>
   
    <br />
    <div>
    <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" 
            BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
            CellPadding="2" ForeColor="Black" GridLines="None" ShowFooter="True" 
            Height="200px"  Width="488px" onrowediting="gvList_RowEditing" >
       <FooterStyle BackColor="Tan" />
       <AlternatingRowStyle BackColor="PaleGoldenrod" />
       <Columns>
         <%--  <asp:TemplateField HeaderText="MetaSno" SortExpression="MetaSno">
               <EditItemTemplate>
                  <asp:Label ID="Label1" runat="server" Text='<%# Eval("MetaSno") %>'></asp:Label>
               </EditItemTemplate>
               <ItemTemplate>
                   <asp:Label ID="Label1" runat="server" Text='<%#Eval("MetaSno") %>'></asp:Label>
               </ItemTemplate>
           </asp:TemplateField>--%>
           <asp:TemplateField HeaderText="Title" SortExpression="Title">
               <EditItemTemplate>
                   <asp:TextBox ID="TextBox2" runat="server" Text='<%#Bind("Title") %>'></asp:TextBox>
               </EditItemTemplate>
               <ItemTemplate>
                   <asp:Label ID="Label2" runat="server" Text='<%#Bind("Title") %>'></asp:Label>
               </ItemTemplate>
           </asp:TemplateField>
           <asp:TemplateField HeaderText="Keyword" SortExpression="Keyword">
               <EditItemTemplate>
                   <asp:TextBox ID="TextBox3" runat="server" Text='<%#Bind("Keyword") %>'></asp:TextBox>
               </EditItemTemplate>
               <ItemTemplate>
                   <asp:Label ID="Label3" runat="server" Text='<%#Bind("Keyword") %>'></asp:Label>
               </ItemTemplate>
           </asp:TemplateField>
           <asp:TemplateField HeaderText="Description" SortExpression="Description">
               <EditItemTemplate>
                   <asp:TextBox ID="TextBox3" runat="server" Text='<%#Bind("Description") %>'></asp:TextBox>
               </EditItemTemplate>
               <ItemTemplate>
                   <asp:Label ID="Label3" runat="server" Text='<%#Bind("Description") %>'></asp:Label>
               </ItemTemplate>
           </asp:TemplateField>

           <asp:TemplateField HeaderText="Delete" SortExpression="Delete">
              
               <ItemTemplate>
                    <asp:ImageButton ID="imgRemove" runat="server" CommandArgument='<%#Eval("MetaSno") %>' 
                     OnClientClick = "return confirm('Do you want to delete?')"
                     CssClass="delete" ImageUrl="~/images/Delete.jpeg" OnCommand="imgRemove_Command" />
                    
               </ItemTemplate>
         </asp:TemplateField>
           <asp:TemplateField HeaderText="Edit" SortExpression="Edit">
             <ItemTemplate>
                <asp:ImageButton ID ="imgEdit" runat="server" ImageUrl="~/images/edit1.jpeg" CssClass="edit"
                PostBackUrl= '<%#"~/MetaMaster_Edit.aspx?id=" + Eval("MetaSno") + "&Title=" + Eval("Title")+ "&Keyword=" + Eval("Keyword") +"&Description="+ Eval("Description")%>' ></asp:ImageButton>
                
              </ItemTemplate>
           </asp:TemplateField>
           <asp:TemplateField HeaderText="View">
            <ItemTemplate>
                <asp:ImageButton ID="imgView" runat="server" ImageUrl="~/images/List2.jpeg" CssClass="view" PostBackUrl= '<%#"~/MetaMaster_Display.aspx?id=" + Eval("MetaSno")%>'>
                </asp:ImageButton>
                
                      
            </ItemTemplate>
               <FooterTemplate>
                   
                   <asp:HyperLink ID="Hyperlink" runat="server" NavigateUrl="~/Home.aspx">Back</asp:HyperLink>
               </FooterTemplate>
           </asp:TemplateField>
             
       </Columns>
       <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
       <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
       <HeaderStyle BackColor="Tan" Font-Bold="True" />
       <SortedAscendingCellStyle BackColor="#FAFAE7" />
       <SortedAscendingHeaderStyle BackColor="#DAC09E" />
       <SortedDescendingCellStyle BackColor="#E1DB9C" />
       <SortedDescendingHeaderStyle BackColor="#C2A47B" />
   
   </asp:GridView>
   </ContentTemplate>
   <Triggers>
   <asp:AsyncPostBackTrigger ControlID="ddlsearch" EventName="SelectedIndexChanged" />
   </Triggers>
   </asp:UpdatePanel>
        &nbsp;&nbsp;
        <asp:Label ID="lblmsg" runat="server"></asp:Label>
 </div>
 </asp:Content>