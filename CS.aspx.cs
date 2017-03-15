using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPSnippets.FaceBookAPI;//import namespaces
using System.Web.Script.Serialization;//import namespaces

public partial class CS : System.Web.UI.Page
{
//    On the click of the ASP.Net Button btnLogin  we redirect the User to FaceBook and
    //ask him to authenticate himself as wells as provide permission to access to his FaceBook profile details like FaceBook UserId, Username, Name, Email and Profile picture
    protected void Login(object sender, EventArgs e)
    {
        FaceBookConnect.Authorize("user_photos,email", Request.Url.AbsoluteUri.Split('?')[0]);
    }
    //The below code checks for access code (access token) in Query string and 
    //then based on the access code it fetches the user’s  FaceBook profile 
    //details like FaceBook UserId, Username, Name, Email and Profile picture
    protected void Page_Load(object sender, EventArgs e)
    {
        FaceBookConnect.API_Key = "<Your API Key>";
        FaceBookConnect.API_Secret = "<Your API Secret>";
        if (!IsPostBack)
        {
            if (Request.QueryString["error"] == "access_denied")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('User has denied access.')", true);
                return;
            }

            string code = Request.QueryString["code"];
            if (!string.IsNullOrEmpty(code))
            {
                string data = FaceBookConnect.Fetch(code, "me");
                FaceBookUser faceBookUser = new JavaScriptSerializer().Deserialize<FaceBookUser>(data);
                faceBookUser.PictureUrl = string.Format("https://graph.facebook.com/{0}/picture", faceBookUser.Id);
                pnlFaceBookUser.Visible = true;
                lblId.Text = faceBookUser.Id;
                lblUserName.Text = faceBookUser.UserName;
                lblName.Text = faceBookUser.Name;
                lblEmail.Text = faceBookUser.Email;
                ProfileImage.ImageUrl = faceBookUser.PictureUrl;
                btnLogin.Enabled = false;
            }
        }
    }
}

  //You will need to create the following class which will be used to hold the 
  // User Profile details returned from FaceBook after authentication.
public class FaceBookUser
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string UserName { get; set; }
    public string PictureUrl { get; set; }
    public string Email { get; set; }
}
