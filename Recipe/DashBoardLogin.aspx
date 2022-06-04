<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashBoardLogin.aspx.cs" Inherits="Recipe.DashBoardLogin" %>

<!doctype html>
<html lang="pt">
  <head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
   
    <title>Dashboard MyRecipe</title>

   
    <!-- Favicons -->
      <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet">

       

<meta name="theme-color" content="#7952b3">

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/dashboard.css" rel="stylesheet">
      <link rel="stylesheet" href="~/Content/style.css">
</head>
<body>
    <form id="form1" runat="server">

        <section> 
        
        <div class="col-md-12 col-lg-6"
            
        style="position: relative;
        left: 50%;
        top:-50%;
        transform: translate(-50%,50%);
        ">

          <main class="form-control" >

                <h1 class="h3 mb-3 my-3 fw-normal">DashBoard Login</h1>
        
                <%
                    if(IsPostBack)
                    {
                        if(!String.IsNullOrEmpty(EmailLogin.Text))
                        {
                            if(!String.IsNullOrEmpty(PasswordLogin.Text))
                            {
                                if (Login(EmailLogin.Text, PasswordLogin.Text))
                                {
                                    Response.Redirect("/DashBoard");
                                }
                                else
                                {
                                    Response.Write(Recipe.Models.Message.DisplayMessage("danger", "credenciais invalidas"));
                                }
                            }
                            else
                            {
                                Response.Write(Recipe.Models.Message.DisplayMessage("warning", "campos password vazio"));

                            }
                        }
                        else
                        {
                            Response.Write(Recipe.Models.Message.DisplayMessage("warning", "campo email e password vazios"));
                        }

                    }
                %>

                <div class="form-floating">
                  <asp:TextBox runat="server" type="email" class="form-control" ID="EmailLogin" placeholder="name@example.com"></asp:TextBox>
                  <label for="floatingInput">Email</label>
                </div>

                <div class="form-floating my-3">
                  <asp:TextBox runat="server" type="password" class="form-control" id="PasswordLogin" placeholder="Password"></asp:TextBox>
                  <label for="floatingPassword">Password</label>
                </div>
            
                <div class="checkbox mb-2 my-3">
                  <label>
                      <span>* Somente pessoas autorizadas</span>
                  </label>
                </div>
                <asp:Button runat="server" cssClass="w-100 btn btn-lg btn-success my-1 mb-3" Text="Entrar" ID="LoginBtn" type="submit"></asp:Button>
            
          
          </main>
        </div>

   
    </section>
   
    </form>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js" ></script>


  </body>
</html>
