<%@ Page Title="" Language="C#" MasterPageFile="~/DashBoardMaster.Master" AutoEventWireup="true" CodeBehind="CreateCategoryDashBoard.aspx.cs" Inherits="Recipe.CreateCategoryDashBoard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        
    <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom" >
        <h1 class="h2">Criar Categoria</h1>
        
     </div>

    <%
        if(IsPostBack)
        {
            if(!String.IsNullOrEmpty(Name.Value) )
            {
                if (Recipe.DAL.Category.CreateCategory(Name.Value))
                {
                    Response.Redirect("DashBoard.aspx/categories");
                }
                else
                {
                    Response.Write(Recipe.Models.Message.DisplayMessage("warning", "não foi possivel criar registro"));
                }
            }
            else
            {
                Response.Write(Recipe.Models.Message.DisplayMessage("warning", "campo  nome vazios"));
            }

        }
    %>

    <main class="my-4 col-md-12 col-lg-12 aligncenter px-1">
        <h2 class="mb-3">Dados da Categoria</h2>
    
        <section class="row g-3">

            <div class="col-12">
                <label for="username" class="form-label">Nome</label>
                
                <input  runat="server"  id="Name" class="w-50 form-control"/>

            </div>

            <button class="col-md-12 col-lg-6  btn btn-success p-3 fs-6" type="submit">Criar</button>  
            </section>
            
       </main>

</asp:Content>
