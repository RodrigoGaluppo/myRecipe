<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Recipe.aspx.cs" Inherits="Recipe.Recipe" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%
        Recipe.Models.Recipe recipe = loadRecipe();

        Recipe.Models.Rate[] rates = loadRates();

        Recipe.Models.IngredientList[] ingredients = loadIngredientsList();

        if (recipe.name == null)
            Response.Redirect("Recipes.aspx");
     %>

    <div class="row g-4 aligncenter" style="max-width:1024px" >
      
       <img class="card-img-top imgBackground" src="<%= recipe.img_url %>" alt="Card image cap">

      <div class="col-md-5 col-lg-4 order-md-last ">
        
          
          <div class="px-lg-4  text-black ">
             

              <div class=" px-1">
                   
                <h2 class="card-title fs-1">Informações</h2>
                  <ul class="icon-list px-1">
                      
                    <li class="fs-5  text-muted info" > 
                      <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-people-fill" viewBox="0 0 16 16">
                      <path d="M7 14s-1 0-1-1 1-4 5-4 5 3 5 4-1 1-1 1H7zm4-6a3 3 0 1 0 0-6 3 3 0 0 0 0 6z"/>
                      <path fill-rule="evenodd" d="M5.216 14A2.238 2.238 0 0 1 5 13c0-1.355.68-2.75 1.936-3.72A6.325 6.325 0 0 0 5 9c-4 0-5 3-5 4s1 1 1 1h4.216z"/>
                      <path d="M4.5 8a2.5 2.5 0 1 0 0-5 2.5 2.5 0 0 0 0 5z"/>
                        </svg> <%= recipe.number_of_people %> pessoas</li>

                      <li class="fs-5  text-muted info"  > 
                      <svg  xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-clipboard-check" viewBox="0 0 16 16">
                          <path fill-rule="evenodd" d="M10.854 7.146a.5.5 0 0 1 0 .708l-3 3a.5.5 0 0 1-.708 0l-1.5-1.5a.5.5 0 1 1 .708-.708L7.5 9.793l2.646-2.647a.5.5 0 0 1 .708 0z"/>
                          <path d="M4 1.5H3a2 2 0 0 0-2 2V14a2 2 0 0 0 2 2h10a2 2 0 0 0 2-2V3.5a2 2 0 0 0-2-2h-1v1h1a1 1 0 0 1 1 1V14a1 1 0 0 1-1 1H3a1 1 0 0 1-1-1V3.5a1 1 0 0 1 1-1h1v-1z"/>
                          <path d="M9.5 1a.5.5 0 0 1 .5.5v1a.5.5 0 0 1-.5.5h-3a.5.5 0 0 1-.5-.5v-1a.5.5 0 0 1 .5-.5h3zm-3-1A1.5 1.5 0 0 0 5 1.5v1A1.5 1.5 0 0 0 6.5 4h3A1.5 1.5 0 0 0 11 2.5v-1A1.5 1.5 0 0 0 9.5 0h-3z"/>
                        </svg> <%= calculateAverage() %></li>

                      <li class="fs-5  text-muted info"  > 
                      <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-clock" viewBox="0 0 16 16">
                        <path d="M8 3.5a.5.5 0 0 0-1 0V9a.5.5 0 0 0 .252.434l3.5 2a.5.5 0 0 0 .496-.868L8 8.71V3.5z"/>
                        <path d="M8 16A8 8 0 1 0 8 0a8 8 0 0 0 0 16zm7-8A7 7 0 1 1 1 8a7 7 0 0 1 14 0z"/>
                      </svg> <%= recipe.preparation_time %> min</li>

                      <li class="fs-5  text-muted info"  > 
                      <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-lightbulb" viewBox="0 0 16 16">
                          <path d="M2 6a6 6 0 1 1 10.174 4.31c-.203.196-.359.4-.453.619l-.762 1.769A.5.5 0 0 1 10.5 13a.5.5 0 0 1 0 1 .5.5 0 0 1 0 1l-.224.447a1 1 0 0 1-.894.553H6.618a1 1 0 0 1-.894-.553L5.5 15a.5.5 0 0 1 0-1 .5.5 0 0 1 0-1 .5.5 0 0 1-.46-.302l-.761-1.77a1.964 1.964 0 0 0-.453-.618A5.984 5.984 0 0 1 2 6zm6-5a5 5 0 0 0-3.479 8.592c.263.254.514.564.676.941L5.83 12h4.342l.632-1.467c.162-.377.413-.687.676-.941A5 5 0 0 0 8 1z"/>
                        </svg> <%= recipe.difficulty %></li>
                     
                  </ul>

                  <asp:Button runat="server" OnClick="AddLike"  Text="Adicionar aos Favoritos" class="btn btn-success text-white align-self-end "></asp:Button>
                    
              </div>
            </div>
      
        
      </div>

      <div class="col-md-7 col-lg-8" >
        

          <h2 class="card-title fs-1"><%= recipe.name %></h2>

          <p class="card-text fs-6">
            <%= recipe.description %>
          </p>

          <h2 class="card-title fs-4">Lista de Ingredientes</h2>

          <table class="table table-striped " >
              <%
            if (ingredients.Length > 0)
            { %>
                           <thead>
                               <tr>

                                <th scope = 'col'> Nome </th>
 
                                <th scope = 'col'> Quant. </th>
   
                                <th scope = 'col'> Medida </th>

                
    
                                </ tr >
                           </thead>
                    
                           <tbody id="Tbody" >
                               
                               <% foreach (Recipe.Models.IngredientList ingredient in ingredients)
                                {
                                %>

                                    <tr>
                                    <td><%= ingredient.ingredient %></td>
                                    <td><%= ingredient.quantity  %></td>
                                    <td><%= ingredient.measure %></td>
                                    </tr>

                                <%}%>

                           </tbody>
                       </table>

           

               
           <% }
            else
            { %>

              <p>Não há ingredientes associados</p>

              <%} %>
  
          <h2 class="card-title fs-4">Modo de Preparo</h2>

          <p class="card-text fs-6">
            <%= recipe.preparation_method %>
          </p>


      
         <div class="d-flex">
               <h2 class="card-title fs-2" >Reviews</h2>
                <a href="/CreateReview.aspx?id=<%= recipe.recipe_id %>" style="margin-left:40px;" class="btn btn-success text-white align-self-end ">Avaliar</a>
         </div>
          <div class="col-md-12 py-3">

            <div class="row">
                <%
                if (rates.Length > 0)
                {
                    foreach (Recipe.Models.Rate rate in rates)
                    {%>
                      <div class="col-md-12">
            
                        <h5><%= rate.user_name %></h5>
                        <p><%= rate.comment %></p>
                      </div>
                <%}
                }
                else
                {%>

                    <h6>Não há nenhuma review</h6>

                <%} %>
            </div>
          </div>
      </div>

    </div>

    <div class="col-md-12 py-2">
      <div class="col-md-12 aligncenter">
        <div class="card-body">

         

        </div>
      </div>
    </div>


</asp:Content>
