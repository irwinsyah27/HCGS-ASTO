<%@ Page language="c#" Inherits="PopupCal.WebForm1" CodeFile="PopupCal.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Pilih Tanggal </title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
  </HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:Calendar id="CalVivek" nSelectionChanged="Change_Date" runat="server" backcolor="White" width="200px" forecolor="Black" height="180px" font-size="8pt" font-names="Verdana"
				bordercolor="#999999" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" onselectionchanged="CalVivek_SelectionChanged" CellPadding="4" DayNameFormat="Shortest">
<TodayDayStyle BackColor="#CCCCCC" ForeColor="Black">
</TodayDayStyle>

<NextPrevStyle VerticalAlign="Bottom">
</NextPrevStyle>

<DayHeaderStyle Font-Size="7pt" Font-Names="Verdana" Font-Bold="True" BackColor="#CCCCCC">
</DayHeaderStyle>

<SelectedDayStyle ForeColor="White" BackColor="#666666" Font-Bold="True">
</SelectedDayStyle>

<TitleStyle Font-Bold="True" BackColor="#999999" BorderColor="Black">
</TitleStyle>

<OtherMonthDayStyle ForeColor="Gray">
</OtherMonthDayStyle>
                <SelectorStyle BackColor="#CCCCCC" />
                <WeekendDayStyle BackColor="#FFFFCC" />
			</asp:Calendar></form>
	</body>
</HTML>
