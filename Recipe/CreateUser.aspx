<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="Recipe.CreateUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <%
         if(IsPostBack)
         {



             if(!String.IsNullOrEmpty(EmailCreate.Text) && !String.IsNullOrEmpty(UserNameCreate.Text) )
             {
                 if(!String.IsNullOrEmpty(PasswordCreate.Text))
                 {
                     if (!String.IsNullOrEmpty(ConfirmPasswordCreate.Text))
                     {
                         if(PasswordCreate.Text == ConfirmPasswordCreate.Text)
                         {
                             if (Create(UserNameCreate.Text,EmailCreate.Text,PasswordCreate.Text))
                             {
                                Response.Redirect("Login.aspx");
                             }
                             else
                             {
                                 Response.Write(Recipe.Models.Message.DisplayMessage("danger", "não foi possível criar usuario"));
                             }
                         }
                         else
                         {
                              Response.Write(Recipe.Models.Message.DisplayMessage("danger", "password e confirmação de password estão divergentes"));
                         }
                     }
                     else
                     {
                         Response.Write(Recipe.Models.Message.DisplayMessage("warning", "campo confirmação de password vazio"));
                     }
                 }
                 else
                 {
                     Response.Write(Recipe.Models.Message.DisplayMessage("warning", "campo password vazio"));

                 }
             }
             else
             {
                 Response.Write(Recipe.Models.Message.DisplayMessage("warning", "campo email ou nome vazios"));
             }

         }
    %>
     <div class="col-md-8 text-center" style="margin:50px auto;">
      <section class="form-control" >
        
            
            <h1 class="h3 mb-3 my-3 fw-normal">Criar conta</h1>
        
            <div class="form-floating">
              <asp:TextBox runat="server" type="text" class="form-control" ID="UserNameCreate" placeholder="seu nome " ></asp:TextBox>
              <label for="floatingInput">Nome</label>
            </div>

            <div class="form-floating">
              <asp:TextBox runat="server" type="email" class="form-control" id="EmailCreate" placeholder="name@example.com"></asp:TextBox>
              <label for="floatingPassword">Email</label>
            </div>

            <div class="form-floating">
              <asp:TextBox runat="server" type="password" class="form-control" id="PasswordCreate" placeholder="Password"></asp:TextBox>
              <label for="floatingPassword">Password</label>
            </div>
        
           <div class="form-floating">
              <asp:TextBox runat="server" type="password" class="form-control" id="ConfirmPasswordCreate" placeholder="Confirmação da Password"></asp:TextBox>
              <label for="floatingPassword">Confimação da Password</label>
            </div>
            
            <asp:Button runat="server"  cssClass="w-100 btn btn-lg btn-success my-4 " ID="CreateBtn" type="submit" Text="Criar"></asp:Button>
       
         
      </section>
    </div>

</asp:Content>
