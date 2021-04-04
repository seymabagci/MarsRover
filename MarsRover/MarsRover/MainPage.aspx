<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="MarsRover.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div>
            <asp:TextBox ID="inputText" runat="server" Height="180px" Style="margin-top: 100px; margin-left: 80px" TextMode="MultiLine" Width="307px" Font-Bold="False" Font-Italic="True">Enter input here</asp:TextBox>
            <asp:Button ID="calculate" runat="server" Height="36px" OnClick="calculate_Click" Style="margin-left: 40px; margin-right: 40px; margin-top: 100px; margin-bottom: 50px" Text="Run" Width="120px" BackColor="#333399" Font-Bold="True" ForeColor="White" />
            <asp:TextBox ID="outputText" runat="server" Height="180px" TextMode="MultiLine" Width="307px" Font-Italic="True" ReadOnly="True">Output is..</asp:TextBox>
        </div>
    </form>
</body>
</html>
