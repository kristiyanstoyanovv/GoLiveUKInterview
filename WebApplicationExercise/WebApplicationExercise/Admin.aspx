<%@ Page Title="GLUKIT - Admin panel" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebApplicationExercise.Admin" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class = "text-center">

        <div class="d-flex flex-column align-items-center justify-content-center">
            <asp:Label ID="txtTest" runat="server"/>

            <!-- Repeater control to display a list of forms -->
            <asp:Repeater ID="rptForms" runat="server" >
                <ItemTemplate>
                    <li>
                        <!-- Hidden field to store the form ID -->
                        <asp:HiddenField ID="formId" runat="server" Value='<%# Eval("id") %>' />

                        <!-- Display form details using Eval() -->
                        <strong>Email:</strong> <%#Eval("email") %><br />
                        <strong>First name:</strong> <%#Eval("firstName") %><br />
                        <strong>Last name:</strong> <%#Eval("lastName") %><br />
                        <strong>Subject:</strong> <%#Eval("subject") %><br />
                        <strong>Message:</strong> <%#Eval("message") %><br />

                        <!-- LinkButton for editing -->
                        <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CommandName="Edit" CommandArgument='<%# Eval("Id") %>' OnCommand="lnkEdit_Command" /><br />
                        
                        <!-- LinkButton for deleting -->
                        <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("Id") %>' OnCommand="lnkDelete_Command" /><br />
                    </li>
                </ItemTemplate>
            </asp:Repeater>

        </div>
        <hr />
        <div class="navbar justify-content-center">
            <asp:Button ID="btnForm" runat="server" text = "Contact form" class="btn btn-secondary me-2" OnClick="btnForm_Click"/>
        </div>
    </div>
</asp:Content>
