<%@ Page Title="" Language="C#" MasterPageFile="~/DashBoardMaster.Master" AutoEventWireup="true" CodeBehind="ViewRecipe.aspx.cs" Inherits="Recipe.ViewRecipe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
        <%

            string Baseurl = new UriBuilder(Request.Url.AbsoluteUri) { Path = Request.ApplicationPath, Query = null, Fragment = null }.ToString();

            Recipe.Models.Recipe recipe = SelectRecipeById();
            Recipe.Models.IngredientList[] ingredients = loadIngredientsList();


 

        %>

    <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom" >
        <h1 class="h2">ID  <%= recipe.recipe_id %></h1>
        
     </div>

    <%


        if(IsPostBack)
        {
            bool active = Active.Value == "1" ? true : false;

            if (UpdateRecipe(active))
                Response.Redirect("DashBoard");
            else
                Response.Write(Recipe.Models.Message.DisplayMessage("danger", "não foi possivel fazer o update"));
        }

        RecipeName.Value = recipe.name;
        PreparationTime.Value = Convert.ToString(recipe.preparation_time);
        Description.Text = recipe.description;
        PreparationMethod.Text = recipe.preparation_method;
        
        Category.Value = recipe.category;
        Difficulty.Value = recipe.difficulty;
        UserEmail.Value = GetEmailByUserId(recipe.user_id);
        Active.Value = recipe.active ? "1" : "0";

    %>

   
    <main class="my-4 col-md-12 col-lg-12 aligncenter px-1">
            <h2 class="mb-3">Dados da Receita</h2>
    
            <section class="col-md-12 col-lg-4">

                <div class="col-lg-12 aligncenter" >
                    <img class="card-img-top imgBackground aligncenter " style="max-height:500px;  " src="<%= recipe.img_url %>" alt="Card image cap">
                </div>

            </section>

            <section class="row g-3">

                <div class="col-6">
                    <label for="username" class="form-label">Nome</label>
                    <div class="input-group has-validation">
                    
                    <input readonly runat="server"  id="RecipeName" class="w-100 form-control"/>
                    
                    </div>
                </div>

                <div class="col-6">
                    <label for="email" class="form-label">Email de usuario</label>
                    <input disabled runat="server"  type="text"  id="UserEmail" class="w-100 form-control"/>
                    
                </div>

                <div class="col-6">
                    <label for="email" class="form-label">Categoria</label>
                    <input disabled  runat="server"  type="text"  id="Category" class="w-100 form-control"/>
                    
                </div>

                <div class="col-6">
                    <label for="email" class="form-label">Tempo</label>
                    <input disabled runat="server"  type="number"  id="PreparationTime" class="w-100 form-control"/>
                    
                </div>

                

                <div class="col-6">
                    <label for="" class="form-label">Ativa </label>
                    <select class="form-select" runat="server" id="Active">
                     
                            <option value="1" > Sim  </option>
                             <option value="0" > Não  </option>

                    </select>
                    
                </div>

                <div class="col-6">
                    <label for="" class="form-label">Dificuldade </label>
                    <input disabled runat="server"  type="text"  id="Difficulty" class="w-100 form-control"/>
                    
                </div>

                <div class="col-md-12">
                    <label for="" class="form-label">Metodo de Preparação </label>
                    
                    <div >
                        <asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" style="min-height:300px" CssClass="form-text form-control" id="PreparationMethod"></asp:TextBox>
                    </div>

                </div>


                <div class="col-md-12">
                    <label for="" class="form-label">Descrição </label>
                    
                    <div >
                        <asp:TextBox  ReadOnly="true" TextMode="MultiLine" runat="server" style="min-height:300px" CssClass="form-text form-control" id="Description"></asp:TextBox>
                    </div>

                </div>

                <div class="col-md-12">
                    <label for="" class="form-label">Lista de Ingredientes </label>
                    
                    <div >
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
  
                        </div>

                </div>

                
                
                <button class="col-md-12 col-lg-6 btn btn-sm btn-success p-2 fs-6" type="submit">Editar</button>  
            </section>
            
       </main>
   
        

		<script>
            const SelectArrays = document.querySelectorAll("select");

            

            const RecipeCategory = document.getElementById("ContentPlaceHolder1_RecipeCategoryId");

            const RecipeCategories = document.getElementById("ContentPlaceHolder1_CategoryId")

            RecipeCategories.addEventListener("change", (option) => {
                RecipeCategory.value = option.target.value
                console.log(RecipeCategory.value)
            })

            


        </script>			
    

</asp:Content>
