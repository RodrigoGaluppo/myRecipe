<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Recipe.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <section> 
    
    <div class="col-md-8 text-center" style="margin:50px auto;">
      <main class="form-control" >
          
            <h1 class="h3 mb-3 my-3 fw-normal">Login</h1>
        
            <%
        if(IsPostBack)
        {



            if(!String.IsNullOrEmpty(EmailLogin.Text))
            {
                if(!String.IsNullOrEmpty(PasswordLogin.Text))
                {
                    if (Log(EmailLogin.Text, PasswordLogin.Text))
                    {
                        Response.Redirect("/");
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
                <span>Não tens conta ? <a class="text-success" href="CreateUser.aspx">Crie já sua conta</a></span>
              </label>
            </div>
            <asp:Button runat="server" cssClass="w-100 btn btn-lg btn-success my-1 mb-3" Text="Entrar" ID="LoginBtn" type="submit"></asp:Button>
            
          
      </main>
    </div>

   
</section>
    
   
</asp:Content>
