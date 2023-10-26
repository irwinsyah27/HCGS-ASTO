<%@ Page Language="VB" AutoEventWireup="false" CodeFile="absensiPeriodeDept.aspx.vb" Inherits="HRGA_Report_Absensi" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    
    <div>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" BorderStyle="Solid" BorderWidth="1px"
            Font-Names="Verdana" Font-Size="8pt" Height="800px" ProcessingMode="Remote" Width="100%">
            <ServerReport ReportServerUrl="http://pabbsqco401/ReportServer" ReportPath="/hrga/Absensi_Periode_Dept_In_Out2" />
			
        </rsweb:ReportViewer>
    
    </div>
    </form>
</body>
</html>


Dim rootWebConfig1 As System.Configuration.Configuration
rootWebConfig1 = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(Nothing)
If (rootWebConfig1.AppSettings.Settings.Count > 0) Then 
    Dim customSetting As System.Configuration.KeyValueConfigurationElement
    customSetting = rootWebConfig1.AppSettings.Settings("customsetting1")
    If Not (customSetting.Value = Nothing) Then
        Console.WriteLine("customsetting1 application string = {0}", customSetting.Value)
    Else
        Console.WriteLine("No customsetting1 application string")
    End If 
End If
