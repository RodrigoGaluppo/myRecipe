<%@ Page Title="" Language="C#" MasterPageFile="~/DashBoardMaster.Master" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="Recipe.DashBoardList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <%
            string Baseurl = new UriBuilder(Request.Url.AbsoluteUri) { Path = Request.ApplicationPath, Query = null, Fragment = null }.ToString();
            var url = new Uri(HttpContext.Current.Request.Url.AbsoluteUri);
            string[] Queries = url.ToString().Split('/');

            string CreationPage = "CreateRecipeDashBoard";
            string Query = "";
            try
            {
                Query = Queries[4];

            }
            catch (Exception)
            {
                Query = "recipes";

            }

            string[] results = new string[2];
            results[0] = "";

            switch(Query)
            {

                case "recipes":
                    results = loadRecipes();
                    CreationPage = "";
                    break;

                case "users":
                    results = loadUsers();
                    CreationPage = "CreateUserDashBoard";
                    break;

                case "categories":
                    results = loadCategories();
                    CreationPage = "CreateCategoryDashBoard";
                    break;

                case "measures":
                    results = loadMeasures();
                    CreationPage = "CreateMeasureDashBoard";
                    break;

                case "ingredients":
                    results = loadIngredients();
                    CreationPage = "CreateIngredientDashBoard";
                    break;

                default:
                    results = loadRecipes();
                    CreationPage = "";
                    break;

                case null:

                    break;
            }


        %>

        <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom" >
        <h1 class="h2"><%= Query != null ? Query : "DashBoard" %></h1>
        <div class="btn-toolbar mb-2 mb-md-0">
            <div class="btn-group me-2">
            <a href="<%= String.Concat(Baseurl,CreationPage) %>" class="btn btn-success text-white">Inserir Novo Registro</a>
            <button type="button" class="btn btn-sm btn-outline-secondary">Export</button>
            </div>
            <button type="button" class="btn btn-sm btn-outline-secondary dropdown-toggle">
            <span data-feather="calendar"></span>
            This week
            </button>
        </div>
        </div>

 
      <div class="table-responsive">
        <table class="table table-striped table-sm">
          <thead>
            <%= results[0] %>
          </thead>
          <tbody>
            
              <% for (int i = 1; i < results.Length; i++)
                  {
                      %>

                        <%= results[i] %>

                      <%
                  }%>
            
          </tbody>
        </table>
      </div>

</asp:Content>
