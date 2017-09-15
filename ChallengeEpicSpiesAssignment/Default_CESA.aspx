<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default_CESA.aspx.cs" Inherits="ChallengeEpicSpiesAssignment.Default_CESA" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 242px;
            height: 300px;
        }
        .auto-style2 {
            font-family: Arial, Helvetica, sans-serif;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <img alt="" class="auto-style1" src="epic-spies-logo.jpg" /><br />
            <h1><span class="auto-style2"><strong>Spy New Assignment Form</strong></span></h1>
            <br />
            Spy Code Name:&nbsp;
            <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            New Assignment Name:
            <asp:TextBox ID="assignNameTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            End Date of Previous Assignment:
            <asp:Label ID="selectedPreviousDateLabel" runat="server"></asp:Label>
&nbsp;<asp:Calendar ID="previousAssignCalendar" runat="server" OnSelectionChanged="previousAssignCalendar_SelectionChanged"></asp:Calendar>
            <br />
            <br />
            Start Date of New Assignment:
            <asp:Label ID="selectedNewDateLabel" runat="server"></asp:Label>
            <asp:Calendar ID="newAssignCalendar" runat="server" OnSelectionChanged="newAssignCalendar_SelectionChanged"></asp:Calendar>
            <br />
            <br />
            Projected End Date of New Assignment:
            <asp:Label ID="selectedNewEndDateLabel" runat="server"></asp:Label>
            <asp:Calendar ID="newAssignEndCalendar" runat="server" OnSelectionChanged="newAssignEndCalendar_SelectionChanged"></asp:Calendar>
            <br />
            <br />
            <asp:Button ID="assignButton" runat="server" OnClick="assignButton_Click" Text="Assign Spy" />
            <br />
            <br />
            <asp:Label ID="outputLabel" runat="server"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
