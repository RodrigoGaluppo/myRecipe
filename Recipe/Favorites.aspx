<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Favorites.aspx.cs" Inherits="Recipe.Favorites" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <%

        Recipe.Models.Recipe[] recipes = SelectFavoriteRecipesByUserId();
            %>

        <main class="my-4 col-md-12 col-lg-8 aligncenter">
            <h2 class="mb-3">Receitas Favoritas</h2>
        
            <section class="row g-3">
                <div class="col-md-12 aligncenter my-4 ">
                
            
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

                                            
                                            <a href='./RemoveFavorite?id=<%= recipe.recipe_id %>' class='btn btn-sm btn-danger mx-1'>Remover</a>
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
                                       <h5 >não tens nenhuma receita favorita</h5>
                                   </div>
                             <%} %>
                    </div>
                
              </div>


            </section>
        </main>

</asp:Content>
