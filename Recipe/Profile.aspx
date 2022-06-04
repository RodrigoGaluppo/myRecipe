<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Recipe.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%
        Recipe.Models.User user = SelectUserInfo();
        Recipe.Models.Recipe[] recipes = SelectRecipeByUserId();

        if(IsPostBack)
        {
            if (UpdateUserInfo(Name.Value, Email.Value))
            {
                Response.Redirect("Profile");
            }
            else
            {
                Recipe.Models.Message.DisplayMessage("danger", "não foi possivel atualizar usuario");
            }
        }
        else
        {
            Name.Value = user.name;
            Email.Value = user.email;
        }

    %>

    <main class="my-4 col-md-12 col-lg-8 aligncenter">
        <h2 class="mb-3">Seus Dados</h2>
    
        <section class="row g-3">

            <div class="col-12">
                <label for="username" class="form-label">Username</label>
                <div class="input-group has-validation">

                <input runat="server" id="Name" class="form-control"/>
                
                </div>
            </div>

            <div class="col-12">
                <label for="email" class="form-label">Email</label>
                <input type="email" runat="server" class="form-control" id="Email" placeholder="you@example.com">
                <div class="invalid-feedback">
                Please enter a valid email address for shipping updates.
                </div>
            </div>

            <button class="w-100 btn btn-sm btn-success p-2 fs-6" type="submit">Editar</button>  

            <hr class="my-4">

            <div class="d-flex my-4">
               <h4 class="card-title fs-2" >Suas Receitas</h4>
                <a href="/CreateRecipe.aspx" style="margin-left:40px;" class="btn btn-success text-white align-self-start ">Criar Receita</a>
            </div>

            <section class="col-md-12 aligncenter ">
                
            
                  <div class="row">
                        <% if (recipes.Length > 0)
                            {
                                foreach (Recipe.Models.Recipe recipe in recipes)
                                {%>
                                <div class='col-md-6'>
                                    <div class='card mb-4 box-shadow'>
                                    <img class='imgBackgroundRecipe card-img-top' src='<%=recipe.img_url %>' alt='Card image <%= recipe.name %>'>
                                    <div class='card-body'>
            
                                        <h3 class='card-title'><%= recipe.name %></h3>
                                        <p class='card-text'><%= recipe.number_of_people %> pessoas</p>
                                        <div class='d-flex justify-content-between align-items-center'>
                                        <div class='btn-group'>
                                            <a href = './Recipe?id=<%= recipe.recipe_id %>' class='btn btn-sm btn-success'>Ver Receita</a>
                                            <div class='btn btn-sm btn-dark' > <%= recipe.category %></div>
                                        </div>
                                        <small class='text-muted'><%= recipe.preparation_time %> mins</small>
                                        </div>
                                    </div>
                                    </div>
                                </div>
        
                                <%}
                            }
                            else
                            {%> 
                                   <div class="col-md-12">
                                       <h5 >não tens nenhuma Receita</h5>
                                   </div>
                             <%} %>
                    </div>
                
              </section>

            </section>
          
      
    </main>
</asp:Content>
