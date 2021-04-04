using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MarsRover
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void calculate_Click(object sender, EventArgs e)
        {
            if (inputText != null && !string.IsNullOrEmpty(inputText.Text))
            {
                string[] linesArr = inputText.Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                outputText.Text = new GetRoversPosition().GetPosition(linesArr);
            }
        }
    }
}