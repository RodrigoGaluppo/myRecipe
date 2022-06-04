<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateRecipe.aspx.cs" Inherits="Recipe.CreateRecipe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%
        /* load dropdown items */
        Recipe.Models.Category[] categories = Recipe.DAL.Category.ListAll();

        foreach(Recipe.Models.Category category in categories)
        {
            Category.Items.Add(category.name);
            Category.Items.FindByText(category.name).Value = Convert.ToString(category.id);
        }

        Recipe.Models.Ingredient[] ingredients = Recipe.DAL.Ingredient.ListAll();

        foreach(Recipe.Models.Ingredient ingredient in ingredients)
        {
            IngredientsList.Items.Add(ingredient.name);
            IngredientsList.Items.FindByText(ingredient.name).Value = Convert.ToString(ingredient.id);
        }

        Recipe.Models.Measure[] measures = Recipe.DAL.Measure.ListAll();

        foreach(Recipe.Models.Measure measure in measures)
        {
            MeasuresList.Items.Add(measure.name);
            MeasuresList.Items.FindByText(measure.name).Value = Convert.ToString(measure.id);
        }

        Recipe.Models.Difficulty[] difficulties = Recipe.DAL.Difficulty.ListAll();

        foreach(Recipe.Models.Difficulty difficulty in difficulties)
        {
            Difficulty.Items.Add(difficulty.name);
            Difficulty.Items.FindByText(difficulty.name).Value = Convert.ToString(difficulty.id);
        }

        string user_id = getuserId();

     %>

    <main id="loader" class="d-none col-md-12 col-lg-12 aligncenter px-1 py-4  align-items-center justify-content-center " >
        
            <img class="aligncenter " style="height:100px" src="/Images/ajax-loader.gif" />
        
    </main>
    
     <main id="content" class="  col-md-12 col-lg-12 aligncenter px-1 py-4">
            <h2 class="mb-3  ">Dados da Receita</h2>
    

            <section class="row py-1 g-3">

                <div class="col-6">
                    <label for="username" class="form-label">Nome</label>
                    <div class="input-group has-validation">
                    
                    <input runat="server"  id="RecipeName" class="w-100 form-control"/>
                    
                    </div>
                </div>


                <div class="col-6">
                    <label for="category" class="form-label">Categoria</label>
                    
                    <select class="form-select" runat="server" id="Category">
                     
                           

                    </select>
                </div>

                <div class="col-6">
                    <label for="email" class="form-label">Tempo (Em Minutos)</label>
                    <input  runat="server" min="1" max="1440" value="1"  type="number"  id="PreparationTime" class="w-100 form-control"/>
                    
                </div>

                <div class="col-6">
                    <label for="email" class="form-label">Numero de Pessoas</label>
                    <input  runat="server" min="1" max="100" value="1"  type="number"  id="NumberOfPeople" class="w-100 form-control"/>
                    
                </div>
                

                <div class="col-6">
                    <label for="difficulty" class="form-label">Dificuldade </label>

                    <select class="form-select" runat="server" id="Difficulty">
                     
                           

                    </select>
                    
                </div>

                <div class="col-12">
                    <label for="upload" class="form-label">Imagem de Capa </label>
                    <input onchange=""  runat="server"  type="file"  id="Img" class="w-100 form-control"/>
 
                </div>
                
                

                <div class="col-md-12">
                    <label for="" class="form-label">Metodo de Preparação </label>
                    
                    <div >
                        <asp:TextBox TextMode="MultiLine" runat="server" style="min-height:300px" CssClass="form-text form-control" id="PreparationMethod"></asp:TextBox>
                    </div>

                </div>


                <div class="col-md-12">
                    <label for="" class="form-label">Descrição </label>
                    
                    <div >
                        <asp:TextBox  TextMode="MultiLine" runat="server" style="min-height:300px" CssClass="form-text form-control" id="Description"></asp:TextBox>
                    </div>

                </div>

                <div class="col-md-12 d-flex" style="flex-wrap:wrap; margin-top:40px; ">
                    
  
                        <label for="" class="form-label w-50">Quantidade </label>

                        <label for="" class="form-label w-50"  >Lista de Medidas </label>
                    
                        <input value="1" runat="server"  type="number"  id="Quantity" class="w-50  form-control"/>


                        <select class="form-select w-50 px-2" runat="server" id="MeasuresList">

                        </select>

                        <label for="" class="form-label w-100 my-2"  >Lista de Ingredientes </label>
              
                         <select class="form-select w-50 px-2" runat="server" id="IngredientsList">
                     
                        </select>
                    
                        <button class="w-50 px-4 btn btn-sm btn-success p-2 fs-6" id="IngredientsButton" >Adicionar</button>

                </div>

                <div class="col-md-12">

                    <label for="" class="form-label w-50">Ingredientes </label>

                    <div class="" style="border: 1px solid #ccc;min-height:200px" >
                       <table class="table table-striped " >
                           <thead>
                               <tr>

                                <th scope = 'col'> Nome </th>
 
                                <th scope = 'col'> Quant. </th>
   
                                <th scope = 'col'> Medida </th>

                                 <th scope = 'col'> # </th>
    
                                </ tr >
                           </thead>

                           <tbody id="Tbody" >
                               
                           </tbody>
                       </table>
                    </div>

                </div>
                
                <input value="<%= user_id %>" style="opacity:0" disabled id="userId" />
                
                <button class="col-md-12  col-lg-6 btn btn-sm btn-success  fs-6" id="SubmitButton" type="submit">Editar</button>  
            </section>
            
       </main>

        <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

        <script src="https://cdn.jsdelivr.net/npm/axios/dist/axios.min.js"></script>

        <script src="./Scripts/createRecipe.js" >

        </script>

</asp:Content>
