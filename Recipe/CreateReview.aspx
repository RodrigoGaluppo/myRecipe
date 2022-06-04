<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateReview.aspx.cs" Inherits="Recipe.CreateReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        if(IsPostBack)
        {
            if(!(String.IsNullOrEmpty(Comment.Value)) && !(String.IsNullOrEmpty(Rate.Value)))
            {
                double rate = Convert.ToDouble(Rate.Value);
                if(rate >= 0 && rate <= 10)
                {
                    MakeReview(Comment.Value,rate);
                }
                else
                {
                     Response.Write(Recipe.Models.Message.DisplayMessage("danger","A nota da receita deve estar entre 0 e 10"));
                }

            }
            else
            {
                Response.Write(Recipe.Models.Message.DisplayMessage("danger","Campos não podem estar vazios"));
            }


        }
     %>
    
    <main class="col-md-12 col-lg-8 my-4 aligncenter">
        <h2 class="mb-3">Fazer uma Avaliação</h2>
    
        <section class="row g-3">

            <div class="col-12">
                <label for="username" class="form-label">Nota</label>

                <input runat="server" type="number" id="Rate" class="form-control"/>
                
            </div>

            <div class="col-12">
                <label for="comment" class="form-label">Comentario</label>
                <textarea type="text" style="height:200px;" runat="server" class="form-control form-text" id="Comment">

                </textarea>
             
            </div>

            <button class="w-100 btn btn-sm btn-success p-2 fs-6" type="submit">Editar</button>  
    </section>
  </main>
</asp:Content>
