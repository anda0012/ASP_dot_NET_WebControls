<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CourseRegistration.aspx.cs" Inherits="CourseRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Course Registration</title>
    <link rel="stylesheet" href="App_Themes/SiteStyles.css" />
</head>
<body>
    <h1>Algonquin College Course Registration</h1>

    <form id="optionsPage" runat="server" Visible="True">
        <div>
            <asp:Label ID="lblName" runat="server" Text="Student Name: "></asp:Label>
            <asp:TextBox ID="txtName" CssClass="input" runat="server"></asp:TextBox>

            <asp:RadioButton ID="RadioButton1" runat="server" GroupName="status" Text="Full-Time" />

            <asp:RadioButton ID="RadioButton2" runat="server" GroupName="status" Text="Part-Time"/>

            <asp:RadioButton ID="RadioButton3" runat="server" GroupName="status" Text="Co-op"/>

            <p>Following courses are currently available for registration</p>

            <asp:Label ID="lblError" CssCLASS="emphsis error" runat="server"></asp:Label>
            
            <asp:CheckBoxList ID="CheckBoxList" runat="server"></asp:CheckBoxList>
            
            <br />
            <asp:Button ID="btnSubmit" CssClass="button" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            <br /><br />

            <asp:Label ID="lblResult" runat="server"></asp:Label>

        </div>
    </form>

    <asp:Panel ID="confirmationPage" runat="server" Visible="False">
        <p>Thank you <asp:Label ID="studentName" runat="server" CssClass="emphsis"></asp:Label>, for using our online registration system.</p>
        <p>You have been registered as a <asp:Label ID="studentStatus" runat="server" CssClass="distinct"></asp:Label> for the following courses</p>
            
        <asp:Table ID="courseTable" CssClass="table" runat="server"></asp:Table>
       
    </asp:Panel>

</body>
</html>
