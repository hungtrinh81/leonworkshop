<%@ Page language="c#" Codebehind="top.aspx.cs" AutoEventWireup="false" Inherits="TransDoc.top" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>top</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"><LINK href="./Menu/anylink/anylink.css" type="text/css" rel="stylesheet">
		<script src="./Menu/anylink/anylink.js" type="text/javascript"></script>
		<script src="./common.js" type="text/javascript"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<input type="hidden" id="hdnTabIndex" value="2" runat="server">
			<span><input type="button" id="btnA" value="¤ÀÃþ" disabled onclick="ChangeTab('1');"></span>
			<span><input type="button" id="btnB" value="·j´M" onclick="ChangeTab('2');"></span>
			<asp:Label id="lblSearchMessage" runat="server"></asp:Label>
			<hr>
			<div id="panel_A">
				<asp:placeholder id="ph" runat="server"></asp:placeholder>
			</div>
			<div id="panel_B" style="DISPLAY:none">
				<asp:textbox id="txtSearch" runat="server"></asp:textbox><asp:Button id="btnSearch" runat="server" Text="GO!!"></asp:Button><hr>
				<asp:ListBox id="lstSearch" runat="server" Width="376px" Height="192px" onClick="SearchToLink(this);"></asp:ListBox>
				<asp:ListBox id="lstSearch2" runat="server" Width="376px" Height="192px" style="DISPLAY:none"></asp:ListBox>
				<hr>
			</div>
		</form>
		<script language="javascript">ChangeTab(document.getElementById('hdnTabIndex').value);</script>
	</body>
</HTML>
