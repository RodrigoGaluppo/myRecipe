<%@ Page Title="" Language="C#" MasterPageFile="~/DashBoardMaster.Master" AutoEventWireup="true" CodeBehind="ViewUser.aspx.cs" Inherits="Recipe.ViewUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%

        string Baseurl = new UriBuilder(Request.Url.AbsoluteUri) { Path = Request.ApplicationPath, Query = null, Fragment = null }.ToString();

        Recipe.Models.User user = loadUserInfo();

       

        %>

    <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom" >
        <h1 class="h2">ID  <%= user.id %></h1>
        
     </div>
    <%
        
         if(IsPostBack)
        {

            if(!String.IsNullOrEmpty(UserEmail.Value) && !String.IsNullOrEmpty(UserName.Value) )
            {
                    
                if (Recipe.DAL.User.UpdateUserInfo(user.id, Convert.ToString(UserName.Value), Convert.ToString(UserEmail.Value), Convert.ToInt32(UserType.Value)))
                {
                    Response.Redirect("DashBoard/users");
                }
                else
                {
                    Response.Write(Recipe.Models.Message.DisplayMessage("danger", "não foi possível criar usuario"));
                }    
            }
            else
            {
                Response.Write(Recipe.Models.Message.DisplayMessage("warning", "campo email ou nome vazios"));
            }

            

        }
        else
        {
            UserName.Value = user.name;
            UserEmail.Value = user.email;

            switch(user.user_type)
            {
                case "restricted":
                    UserType.Value = "2";
                    break;

                case "user":
                    UserType.Value = "1";
                    break;

                case "admin":
                    UserType.Value = "3";
                    break;
            }
        }    
        
    %>
    <main class="my-4 col-md-12 col-lg-12 aligncenter px-1">
            <h2 class="mb-3">Dados do Usuario</h2>
    
            <section class="row g-3">

                <div class="col-6">
                    <label for="username" class="form-label">Username</label>
                    <div class="input-group has-validation">
                    
                    <input  runat="server"  id="UserName" class="w-100 form-control"/>
                    <div class="invalid-feedback">
                        Your username is required.
                    </div>
                    </div>
                </div>

                <div class="col-6">
                    <label for="email" class="form-label">Email </label>
                    <input  runat="server"  type="email"  id="UserEmail" class="w-100 form-control"/>
                    <div class="invalid-feedback">
                    Please enter a valid email address for shipping updates.
                    </div>
                </div>

                <div class="col-6">
                    <label for="" class="form-label">Email </label>
                    <select class="form-select" runat="server" id="UserType">
                     
                            <option value="1" > user  </option>
                             <option value="2" > restricted  </option>
                             <option  value="3" > admin</option>
                      
                    </select>
                    <div class="invalid-feedback">
                    Please enter a valid email address for shipping updates.
                    </div>
                </div>
                
                <button class="col-md-12 col-lg-6 btn btn-sm btn-success p-2 fs-6" type="submit">Editar</button>  
             </section>

            <section class="row g-3">

            </section>
            
       </main>

</asp:Content>
