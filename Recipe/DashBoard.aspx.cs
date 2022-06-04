using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recipe
{
    public partial class DashBoardList : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DisableRecipe(object sender, EventArgs e)
        {
            Models.Message.DisplayMessage("success", "disabled");
        }

        public string[] loadUsers()
        {
            Models.User[] users = DAL.User.ListUsers();

            string[] result = new string[users.Length + 1];

            result[0] =
                $@"<tr>
    
                <th scope = 'col'> Nome </th>
 
                <th scope = 'col'> Email </th>
  

                <th scope = 'col'> Ativo </th>
   
                <th scope = 'col'> Ver </th>
    
                </ tr > ";

            for (int i = 0; i < users.Length; i++)
            {
                if (users[i].user_type == "restricted")
                {
                    result[i + 1] =
                    $@"

                <tr>

                    <td>{users[i].name}</td>
                    <td>{users[i].email}</td>

                    <td><button type='button' class='btn btn-danger text-white'>
                        <svg xmlns='http://www.w3.org/2000/svg' width='16' height='16' fill='currentColor' class='bi bi-x-lg' viewBox='0 0 16 16'>
                          <path d='M1.293 1.293a1 1 0 0 1 1.414 0L8 6.586l5.293-5.293a1 1 0 1 1 1.414 1.414L9.414 8l5.293 5.293a1 1 0 0 1-1.414 1.414L8 9.414l-5.293 5.293a1 1 0 0 1-1.414-1.414L6.586 8 1.293 2.707a1 1 0 0 1 0-1.414z' />
                         </svg >
 
                     </button></td>

                    <td><a href='{String.Concat("/ViewUser?user_id=", users[i].id)}' class='btn btn-warning text-dark'>

                        <svg xmlns='http://www.w3.org/2000/svg' width='16' height='16' fill='currentColor' class='bi bi-pencil-fill' viewBox='0 0 16 16'>
                            <path d='M12.854.146a.5.5 0 0 0-.707 0L10.5 1.793 14.207 5.5l1.647-1.646a.5.5 0 0 0 0-.708l-3-3zm.646 6.061L9.793 2.5 3.293 9H3.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.207l6.5-6.5zm-7.468 7.468A.5.5 0 0 1 6 13.5V13h-.5a.5.5 0 0 1-.5-.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.5-.5V10h-.5a.499.499 0 0 1-.175-.032l-.179.178a.5.5 0 0 0-.11.168l-2 5a.5.5 0 0 0 .65.65l5-2a.5.5 0 0 0 .168-.11l.178-.178z' />
                        </svg>

                        </a></td>
                    </tr>


                    ";
                }
                else
                {
                    result[i + 1] =
                    $@"

                    <tr>
                     
                        <td>{users[i].name}</td>
                        <td>{users[i].email}</td>

                        <td><button type='button' class='btn btn-success text-white'>
                            <svg xmlns='http://www.w3.org/2000/svg' width='16' height='16' fill='currentColor' class='bi bi-check-lg' viewBox='0 0 16 16'>
                              <path d='M13.485 1.431a1.473 1.473 0 0 1 2.104 2.062l-7.84 9.801a1.473 1.473 0 0 1-2.12.04L.431 8.138a1.473 1.473 0 0 1 2.084-2.083l4.111 4.112 6.82-8.69a.486.486 0 0 1 .04-.045z' />
                             </svg>
 

                           </button></td>

                        <td><a href='{String.Concat("/ViewUser?user_id=", users[i].id)}' class='btn btn-warning text-dark'>

                            <svg xmlns='http://www.w3.org/2000/svg' width='16' height='16' fill='currentColor' class='bi bi-pencil-fill' viewBox='0 0 16 16'>
                                <path d='M12.854.146a.5.5 0 0 0-.707 0L10.5 1.793 14.207 5.5l1.647-1.646a.5.5 0 0 0 0-.708l-3-3zm.646 6.061L9.793 2.5 3.293 9H3.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.207l6.5-6.5zm-7.468 7.468A.5.5 0 0 1 6 13.5V13h-.5a.5.5 0 0 1-.5-.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.5-.5V10h-.5a.499.499 0 0 1-.175-.032l-.179.178a.5.5 0 0 0-.11.168l-2 5a.5.5 0 0 0 .65.65l5-2a.5.5 0 0 0 .168-.11l.178-.178z' />
                            </svg>

                            </a></td>
                    </tr>


                    ";
                }
            }

            return result;
        }

        public static string[] loadRecipes()
        {

            Models.Recipe[] recipes = DAL.Recipe.ListForDashBoard();

            string[] result = new string[recipes.Length + 1];

            result[0] =
                $@"<tr>
                <th scope='col'>Id</th>
                <th scope = 'col'> Nome </th>
 
                <th scope = 'col'> Categoria </th>
  

                <th scope = 'col'> Ativa </th>
   
                <th scope = 'col'> Ver </th>
    
                </ tr > ";

            for (int i = 0; i < recipes.Length; i++)
            {
                if (!recipes[i].active)
                {
                    result[i + 1] =
                    $@"

                <tr>
                    <td>{recipes[i].recipe_id}</td>
                    <td>{recipes[i].name}</td>
                    <td>{recipes[i].category}</td>

                    <td><button type='button' class='btn btn-danger text-white'>
                        <svg xmlns='http://www.w3.org/2000/svg' width='16' height='16' fill='currentColor' class='bi bi-x-lg' viewBox='0 0 16 16'>
                          <path d='M1.293 1.293a1 1 0 0 1 1.414 0L8 6.586l5.293-5.293a1 1 0 1 1 1.414 1.414L9.414 8l5.293 5.293a1 1 0 0 1-1.414 1.414L8 9.414l-5.293 5.293a1 1 0 0 1-1.414-1.414L6.586 8 1.293 2.707a1 1 0 0 1 0-1.414z' />
                         </svg >
 
                     </button></td>

                    <td><a href='{String.Concat("/ViewRecipe?recipe_id=", Convert.ToString(recipes[i].recipe_id))}' class='btn btn-warning text-dark'>

                        <svg xmlns='http://www.w3.org/2000/svg' width='16' height='16' fill='currentColor' class='bi bi-pencil-fill' viewBox='0 0 16 16'>
                            <path d='M12.854.146a.5.5 0 0 0-.707 0L10.5 1.793 14.207 5.5l1.647-1.646a.5.5 0 0 0 0-.708l-3-3zm.646 6.061L9.793 2.5 3.293 9H3.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.207l6.5-6.5zm-7.468 7.468A.5.5 0 0 1 6 13.5V13h-.5a.5.5 0 0 1-.5-.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.5-.5V10h-.5a.499.499 0 0 1-.175-.032l-.179.178a.5.5 0 0 0-.11.168l-2 5a.5.5 0 0 0 .65.65l5-2a.5.5 0 0 0 .168-.11l.178-.178z' />
                        </svg>

                        </a></td>
                </tr>


                    ";
                }
                else
                {
                    result[i + 1] =
                    $@"

                    <tr>
                        <td>{recipes[i].recipe_id}</td>
                        <td>{recipes[i].name}</td>
                        <td>{recipes[i].category}</td>

                        <td><button type='button' class='btn btn-success text-white'>
                            <svg xmlns='http://www.w3.org/2000/svg' width='16' height='16' fill='currentColor' class='bi bi-check-lg' viewBox='0 0 16 16'>
                              <path d='M13.485 1.431a1.473 1.473 0 0 1 2.104 2.062l-7.84 9.801a1.473 1.473 0 0 1-2.12.04L.431 8.138a1.473 1.473 0 0 1 2.084-2.083l4.111 4.112 6.82-8.69a.486.486 0 0 1 .04-.045z' />
                             </svg>
 

                           </button></td>

                        <td><a href='{String.Concat("/ViewRecipe?recipe_id=", Convert.ToString(recipes[i].recipe_id))}' class='btn btn-warning text-dark'>

                            <svg xmlns='http://www.w3.org/2000/svg' width='16' height='16' fill='currentColor' class='bi bi-pencil-fill' viewBox='0 0 16 16'>
                                <path d='M12.854.146a.5.5 0 0 0-.707 0L10.5 1.793 14.207 5.5l1.647-1.646a.5.5 0 0 0 0-.708l-3-3zm.646 6.061L9.793 2.5 3.293 9H3.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.207l6.5-6.5zm-7.468 7.468A.5.5 0 0 1 6 13.5V13h-.5a.5.5 0 0 1-.5-.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.5-.5V10h-.5a.499.499 0 0 1-.175-.032l-.179.178a.5.5 0 0 0-.11.168l-2 5a.5.5 0 0 0 .65.65l5-2a.5.5 0 0 0 .168-.11l.178-.178z' />
                            </svg>

                            </a></td>
                    </tr>


                    ";
                }
            }

            return result;

        }

        public static string[] loadCategories()
        {

            Models.Category[] categories = DAL.Category.ListAll();

            string[] result = new string[categories.Length + 1];

            result[0] =
                $@"<tr>
                <th scope='col'>Id</th>
                <th scope = 'col'> Nome </th>
 
                </ tr > ";

            for (int i = 0; i < categories.Length; i++)
            {
                
                    result[i + 1] =
                    $@"

                    <tr>
                        <td>{categories[i].id}</td>
                        <td>{categories[i].name}</td>
                    </tr>


                    ";
                
            }

            return result;

        }

        public static string[] loadMeasures()
        {

            Models.Measure[] measures = DAL.Measure.ListAll();

            string[] result = new string[measures.Length + 1];

            result[0] =
                $@"<tr>
                <th scope='col'>Id</th>
                <th scope = 'col'> Nome </th>
 
                </ tr > ";

            for (int i = 0; i < measures.Length; i++)
            {

                result[i + 1] =
                $@"

                    <tr>
                        <td>{measures[i].id}</td>
                        <td>{measures[i].name}</td>
                    </tr>


                    ";

            }

            return result;

        }

        public static string[] loadIngredients()
        {

            Models.Ingredient[] ingredients = DAL.Ingredient.ListAll();

            string[] result = new string[ingredients.Length + 1];

            result[0] =
                $@"<tr>
                <th scope='col'>Id</th>
                <th scope = 'col'> Nome </th>
 
                </ tr > ";

            for (int i = 0; i < ingredients.Length; i++)
            {

                result[i + 1] =
                $@"

                    <tr>
                        <td>{ingredients[i].id}</td>
                        <td>{ingredients[i].name}</td>
                    </tr>


                    ";

            }

            return result;

        }


        protected void SetRecipeDisabled(object sender, EventArgs e, int id)
        {
            Models.Message.DisplayMessage("success", "disabled");
        }
    }
}