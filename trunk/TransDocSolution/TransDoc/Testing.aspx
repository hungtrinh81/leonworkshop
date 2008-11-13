<%@ Page language="c#" Codebehind="Testing.aspx.cs" AutoEventWireup="false" Inherits="TransDoc.Testing" Trace="true"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Testing</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">

		<form id="Form1" method="post" runat="server">
			<asp:Label id="lblSingleFileFrom" runat="server">來源檔案：</asp:Label><INPUT id="fSingleFileFrom" type="file" runat="server" size="71"><br>
			<asp:Button id="btnSingleFileConvert" runat="server" Text="單一檔案轉換" Width="152px" Height="56px"></asp:Button>
		</form>

	</body>
</HTML>
