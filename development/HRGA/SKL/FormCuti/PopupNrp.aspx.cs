using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class PopupNrp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session.Add("dept", "HRGA");
    }
    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        //if (Request.QueryString["textbox"] != "")
        //{
        string strScript = "<script>window.opener.document.forms(0)." + Request.QueryString["textbox"].ToString() + ".value = '";
        //strScript += CalVivek.SelectedDate.ToString("dd MMM yyyy");
        strScript += GridView1.SelectedRow.Cells[0].Text;
        //strScript += "';window.opener.document.forms(0)." + "ctl00$ContentPlaceHolder1$DetailsView1$TextBox4" + ".value = '";
        //strScript += GridView1.SelectedRow.Cells[2].Text;
        strScript += "';self.close();window.opener.__doPostBack(true)";
        strScript += "</" + "script>";
        RegisterClientScriptBlock("GridView1_SelectedIndexChanged", strScript);
        //}
    }

}
