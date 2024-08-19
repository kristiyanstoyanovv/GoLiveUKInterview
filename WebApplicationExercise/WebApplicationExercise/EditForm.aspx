<%@ Page Title="GLUKIT - Edit form" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditForm.aspx.cs" Inherits="WebApplicationExercise.EditForm" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class = "text-center">

    <div class="d-flex flex-column align-items-center justify-content-center">

        <!-- Label for displaying result message -->
        <asp:Label ID="txtResult" runat="server" Visible="false" />

        <!-- Email TextBox with validation -->
        <asp:RegularExpressionValidator
            ID="revEmail"
            runat="server"
            ControlToValidate="txtEmail"
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
            errorMessage="Please enter a valid email address!"
            ValidationGroup="vForm"
            cssClass="fst-italic text-danger"/>
        <asp:RequiredFieldValidator 
            ID="rqEmail" 
            runat="server" 
            ControlToValidate="txtEmail"
            ValidationGroup="vForm"
            cssClass="fst-italic text-danger"
            errorMessage="This field is required."/>
        <asp:TextBox placeholder="Email" CssClass="form-control" ID="txtEmail" runat="server" />

        <!-- First Name TextBox with validation -->
        <asp:RequiredFieldValidator 
            ID="rqFirstName" 
            runat="server" 
            ControlToValidate="txtFirstName"
            ValidationGroup="vForm"
            cssClass="fst-italic text-danger"
            errorMessage="This field is required."/>
        <asp:TextBox placeholder="First name" CssClass="form-control mb-4" ID="txtFirstName" runat="server"/>

        <!-- Last Name TextBox -->
        <asp:TextBox placeholder="Last name" CssClass="form-control" ID="txtLastName" runat="server"/>

        <!-- Subject TextBox with validation -->
        <asp:RequiredFieldValidator 
            ID="rqSubject" 
            runat="server" 
            ControlToValidate="txtSubject"
            ValidationGroup="vForm"
            cssClass="fst-italic text-danger"
            errorMessage="This field is required."/>
        <asp:TextBox placeholder="Subject" CssClass="form-control" ID="txtSubject" runat="server"/>

        <!-- Message TextBox with validation -->
        <asp:RequiredFieldValidator 
            ID="rqMessage" 
            runat="server" 
            ControlToValidate="txtMessage"
            ValidationGroup="vForm"
            cssClass="fst-italic text-danger"
            errorMessage="This field is required."/>
        <asp:TextBox placeholder="Message" TextMode="MultiLine" Rows="4" Columns="40" CssClass="form-control" ID="txtMessage" runat="server"/>
        
         <!-- Button for editing -->
        <asp:Button ID="btnEdit" runat="server" CssClass="btn btn-success me-2 mt-3" Text = "Edit" OnClick="btnEdit_Click" ValidationGroup="vForm"/>

    </div>

    <hr />

    <!-- Buttons for navigation -->
    <div class="navbar justify-content-center">
        <asp:Button ID="btnForm" runat="server" text = "Contact form" class="btn btn-secondary me-2" OnClick="btnForm_Click"/>
        <asp:Button ID="btnAdmin" runat="server" text = "Admin panel" class="btn btn-secondary me-2" OnClick="btnAdmin_Click"/>
    </div>
</div>
</asp:Content>
