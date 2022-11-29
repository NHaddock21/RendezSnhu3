using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RendezSnhu3.Services
{
    internal class CreateAccountEmail : SendEmail
    {
        public void CreateEmailAcc(string recips)
        {
            subject = "Account Creation Successful";
            string htmlString = "<head>  \r\n    <title>RendezSnhu</title>  \r\n</head>  \r\n  \r\n<body>  \r\n  \r\n    <table>  \r\n  \r\n        <tr>  \r\n  \r\n            <td>  \r\n  \r\n                <img src=\"http://www.c-sharpcorner.com/App_themes/csharp/images/sitelogo.png\" width=\"150px\" height=\"60px\" />  \r\n                <br />  \r\n                <br />  \r\n  \r\n                <div style=\"border-top:3px solid #22BCE5\"> </div>  \r\n  \r\n                <span style=\"font-family:Arial;font-size:10pt\">  \r\n  \r\nHello <b>{UserName}</b>,<br /><br />  \r\n  \r\n<a style = \"color:#22BCE5\" href = \"{Url}\">{Title}</a><br />  \r\n  \r\n{message}  \r\n  \r\n<br /><br />  \r\n  \r\nThanks<br />  \r\n  \r\nDebendra dash  \r\n  \r\n</span>  \r\n  \r\n            </td>  \r\n  \r\n        </tr>  \r\n  \r\n    </table>  \r\n  \r\n</body>  \r\n  \r\n</html> \r\nThe Yellow mark text should be replaced at run time.\r\n\r\nHere I have attached the screenshot.\r\n\r\ncode\r\n \r\n Now in the \"default.aspx\", I have the following design view to send an email.\r\n<body>  \r\n    <form id=\"form1\" runat=\"server\">  \r\n        <div>  \r\n            <table>  \r\n                <tr>  \r\n                    <td>  \r\n                        Name  \r\n                    </td>  \r\n                    <td>  \r\n                        <asp:TextBox ID=\"txt_name\" Width=\"200px\" runat=\"server\"></asp:TextBox>  \r\n                    </td>  \r\n                </tr>  \r\n                <tr>  \r\n                    <td>  \r\n                        Email Id  \r\n                    </td>  \r\n                    <td>  \r\n                        <asp:TextBox ID=\"txt_email\" Width=\"200px\" runat=\"server\"></asp:TextBox>  \r\n                    </td>  \r\n                </tr>  \r\n                <tr>  \r\n                    <td>  \r\n                        Message  \r\n                    </td>  \r\n                    <td>  \r\n                        <asp:TextBox ID=\"txt_message\" Width=\"200px\" runat=\"server\" TextMode=\"MultiLine\" Height=\"60px\"></asp:TextBox>  \r\n                    </td>  \r\n                </tr>  \r\n            </table>  \r\n            <asp:Button ID=\"btnSend\" runat=\"server\" Text=\"Send Email\" OnClick=\"SendEmail\" />  \r\n        </div>  \r\n    </form>  \r\n</body> ";
            body = "Im testing with the bestin around";
        }

    }
}
