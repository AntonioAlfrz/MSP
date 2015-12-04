using System;
using System.Collections.Generic;

namespace MSPForm
{
    public partial class JustifyForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Justify_Text(object sender, EventArgs e)
        {
            int columnas = cols.Value=="" ? 10 : int.Parse(cols.Value);
            List<string> temp = new Justify().justifica(input.Value, columnas);
            resultado.Value = "";
            foreach (string p in temp)
            {
                resultado.Value += p+"\n";
            }
        }
    }
}