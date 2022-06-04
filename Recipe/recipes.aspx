<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="recipes.aspx.cs" Inherits="Recipe.Recipes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <% Recipe.Models.Recipe[] recipes;
        if (IsPostBack)
        {
            if(String.IsNullOrEmpty(RecipeValue.Value))
            {
                recipes = Recipe.Recipes.displayList(); 
            }
            else
                recipes = Recipe.Recipes.search(RecipeValue.Value);

        }
        else
        {
            recipes = Recipe.Recipes.displayList();
        }



    %>

    <section class="">
        <div class="aligncenter col-md-12">
            <div class="p-1 col-md-12">
                <div class="py-4">
                  <h1 class="display-5 fw-bold">Encontre o que deseja ;)</h1>
                  <p class="col-md-8 fs-4">temos as melhores receitas postadas por usuarios de todo o mundo ao seu alcance para fazer a toda hora em seu comforto de casa</p>

                  <div class="col-md-12" >
                    <div class="d-flex" style="display:flex; flex-wrap:nowrap;">
                      <input runat="server" class="form-control  py-3" type="search" placeholder="Buscar por Receitas" id="RecipeValue" aria-label="Search">
                      <button class="btn btn-success px-4 " type="submit">Buscar</button>
                    </div>
                  </div>
                </div>
            </div>
        </div>
    </section>

    <section class=" aligncenter py-2 ">
    <div class="container">
        <div  class="row" >



        <%   

            foreach ( Recipe.Models.Recipe recipe in recipes)
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
                        <small class='text-muted'><%= recipe.preparation_time %> min</small>
                      </div>
                    </div>
                  </div>
                </div>
        
        <%} %> 
       </div>
    </div>
        
  </section>

  <!-- FOOTER -->
  <footer class="container py-2">
    <p class="float-end "><a class=" btn btn-dark" href="#">Voltar ao Topo</a></p>

  </footer>
</asp:Content>
