<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Recipe._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%

        Recipe.Models.Recipe[] topRecipes = listTopRecipes();

    %>


   <main>

  <div id="myCarousel" class="carousel slide my-4 "  data-bs-ride="carousel">
    <div class="carousel-indicators">
      <button type="button" data-bs-target="#myCarousel" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
      <button type="button" data-bs-target="#myCarousel" data-bs-slide-to="1" aria-label="Slide 2"></button>
      <button type="button" data-bs-target="#myCarousel" data-bs-slide-to="2" aria-label="Slide 3"></button>
    </div>
    <div class="carousel-inner"  >
      <div class="carousel-item active">
        <img src="./Images/food2.jpg" class="bd-placeholder-img bd-placeholder-img-lg featurette-image img-fluid mx-auto imgBackground" width="100%"  alt="food">

        <div class="container">
          <div class="carousel-caption text-start" >

            <div class="col-md-12 bg-dark ">
              <div class=" py-4 px-5">
                <h6 class="display-6 fw-bold">Receitas Simples</h6>
                <p>pelo melhor preço</p>
                <a href="./Recipes.aspx" class="btn btn-success btn-group-sm">Veja as Receitas</a>
              </div>
            </div>

            
          </div>
        </div>
      </div>
      <div class="carousel-item ">
        <img src="./Images/food.jpg" class="bd-placeholder-img bd-placeholder-img-lg featurette-image img-fluid mx-auto imgBackground" width="100%"   alt="food 2">

        <div class="container">
          <div class="carousel-caption text-start">
            
            <div class="col-md-12 bg-dark ">
              <div class=" py-4 px-5">
                <h6 class="display-6 fw-bold">Comida Boa</h6>
                <p>pelo melhor preço</p>
                <a href="./Recipes.aspx" class="btn btn-success btn-group-sm">Veja as Receitas</a>
              </div>
            </div>

          </div>
        </div>
      </div>
      <div class="carousel-item">
        <img src="./Images/food.jpg" class="bd-placeholder-img bd-placeholder-img-lg featurette-image img-fluid mx-auto imgBackground" width="100%"  alt="food 3">

        <div class="container">
          <div class="carousel-caption text-start">
            
            <div class="col-md-12 bg-dark ">
              <div class=" py-4 px-5">
                <h6 class="display-6 fw-bold">Receitas Completas</h6>
                <p>pelo melhor preço</p>
                <a href="./Recipes.aspx" class="btn btn-success btn-group-sm">Veja as Receitas</a>
              </div>
            </div>

          </div>
        </div>
      </div>
    </div>
    <button class="carousel-control-prev" type="button" data-bs-target="#myCarousel" data-bs-slide="prev">
      <span class="carousel-control-prev-icon" aria-hidden="true"></span>
      <span class="visually-hidden">Previous</span>
    </button>
    <button class="carousel-control-next" type="button" data-bs-target="#myCarousel" data-bs-slide="next">
      <span class="carousel-control-next-icon" aria-hidden="true"></span>
      <span class="visually-hidden">Next</span>
    </button>
  </div>



  <div class="container marketing " style="margin-top: 50px;">

    <div class="row">
      <div class="col-md-12">
        <h2 class=" card-title"> Avaliações mais altas </h2>
      </div>
    </div>

    <div class="row py-3">
      <%
    if (topRecipes.Length > 0)
    {
        for (int i = 0; i < 3; i++)
        {
            Recipe.Models.Recipe recipe = topRecipes[i];
              %>
                <div class='col-md-4'>
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
    }%> 
     </div><!-- /.col-lg-4 -->

    
    <hr class="featurette-divider">

    <div class="row featurette">
      <div class="col-md-7">
        <h2 class="featurette-heading"> Melhores Receitas <span class="text-muted"> a seu alcance</span></h2>
        <p class="lead">Temos as melhores receitas, postadas por usuarios de forma gratuita e espontanea</p>
      </div>
      <div class="col-md-5">
        <img src="./Images/food.jpg" class="bd-placeholder-img bd-placeholder-img-lg featurette-image img-fluid mx-auto" width="500" height="500"  alt="food">

      </div>
    </div>
    
    <hr class="featurette-divider">

    <div class="row featurette">
      <div class="col-md-7 order-md-2">
        <h2 class="featurette-heading"> Melhores Receitas <span class="text-muted">de forma prática</span></h2>
        <p class="lead">Temos as melhores receitas, postadas por usuarios de forma gratuita e espontanea</p>
      </div>
      <div class="col-md-5 order-md-1">
        <img src="./Images/food2.jpg" class="bd-placeholder-img bd-placeholder-img-lg featurette-image img-fluid mx-auto" width="500" height="500"  alt="food">

      </div>
    </div>

    <hr class="featurette-divider">

    <div class="row featurette">
      <div class="col-md-7">
        <h2 class="featurette-heading"> Melhores Receitas <span class="text-muted">de graça</span></h2>
        <p class="lead">Temos as melhores receitas, postadas por usuarios de forma gratuita e espontanea</p>
      </div>
      <div class="col-md-5">
        <img src="./Images/food.jpg" class="bd-placeholder-img bd-placeholder-img-lg featurette-image img-fluid mx-auto" width="500" height="500"  alt="food">

      </div>
    </div>

    <hr class="featurette-divider">

    <!-- /END THE FEATURETTES -->

  </div><!-- /.container -->


</main>

</asp:Content>
