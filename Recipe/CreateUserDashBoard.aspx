<%@ Page Title="" Language="C#" MasterPageFile="~/DashBoardMaster.Master" AutoEventWireup="true" CodeBehind="CreateUserDashBoard.aspx.cs" Inherits="Recipe.CreateUserDashBoard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    
    <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom" >
        <h1 class="h2">Criar Usuario</h1>
        
     </div>

    <%
         if(IsPostBack)
         {
             if(!String.IsNullOrEmpty(EmailCreate.Value) && !String.IsNullOrEmpty(UserNameCreate.Value) )
             {
                 if(!String.IsNullOrEmpty(PasswordCreate.Value))
                 {

                    
                    if (Create(UserNameCreate.Value,EmailCreate.Value,PasswordCreate.Value,Convert.ToInt32(UserTypeCreate.Value)))
                    {
                        Response.Redirect("DashBoard");
                    }
                    else
                    {
                        Response.Write(Recipe.Models.Message.DisplayMessage("danger", "não foi possível criar usuario"));
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

    <main class="my-4 col-md-12 col-lg-12 aligncenter px-1">
        <h2 class="mb-3">Dados do Usuario</h2>
    
        <section class="row g-3">

            <div class="col-6">
                <label for="username" class="form-label">Nome</label>
                
                <input  runat="server"  id="UserNameCreate" class="w-100 form-control"/>

            </div>

            <div class="col-6">
                <label for="email" class="form-label">Email </label>
                <input  runat="server"  type="email"  id="EmailCreate" class="w-100 form-control"/>
                
            </div>

            <div class="col-6">
                <label for="email" class="form-label">Pssword </label>
                <input  runat="server"  type="password"  id="PasswordCreate" class="w-100 form-control"/>
                
            </div>

            <div class="col-6">
                <label for="" class="form-label">Tipo </label>
                <select class="form-select" runat="server" id="UserTypeCreate">
                     
                    <option value="1" > user  </option>
                    <option value="2" > restricted  </option>
                    <option  value="3" > admin</option>
                      
                </select>
                
            </div>
                
            <button class="col-md-12 col-lg-6  btn btn-success p-3 fs-6" type="submit">Criar</button>  
            </section>

        <section class="row g-3">

        </section>
            
       </main>

</asp:Content>
