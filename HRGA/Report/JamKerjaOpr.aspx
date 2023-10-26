<%@ Page Language="VB" AutoEventWireup="false" CodeFile="JamKerjaOpr.aspx.vb" Inherits="HRGA_Report_JamKerjaOpr" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Jam Kerja Produksi</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <rsweb:reportviewer id="ReportViewer1" runat="server" borderstyle="Solid" borderwidth="1px"
            font-names="Verdana" font-size="8pt" height="500px" processingmode="Remote" width="100%">
<ServerReport ReportPath="/hrga/Weekly_Man_Power_Report"></ServerReport>
</rsweb:reportviewer>
    
    </div>
    </form>
</body>
</html>
