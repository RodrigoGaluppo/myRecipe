
let indexIngredient = 0;
const Ingredients = []

let base64String = "";


const addSubmition = async (e) => {
    e.preventDefault()


    // verifying category
    const CategoriesList = document.querySelector("#MainContent_Category")

    const category_id = CategoriesList.options[CategoriesList.selectedIndex].value

    // verifying category
    const DifficultiesList = document.querySelector("#MainContent_Difficulty")

    const difficulty_id = DifficultiesList.options[DifficultiesList.selectedIndex].value

    const name = document.querySelector("#MainContent_RecipeName").value

    const preparation_time = document.querySelector("#MainContent_PreparationTime").value

    const preparation_method = document.querySelector("#MainContent_PreparationMethod").value

    const description = document.querySelector("#MainContent_Description").value

    const number_of_people = document.querySelector("#MainContent_NumberOfPeople").value

    const userid = document.querySelector("#userId").value

    const file = document.querySelector("#MainContent_Img").files[0]

    if (!(!!category_id && !!name && !!preparation_method && !!preparation_time && !!description && !!number_of_people && !!userid)) {
        alert("campos não preenchidos");
        return
    }

    if (Ingredients.length == 0) {
        alert("adicione ingredientes para prosseguir");
        return
    }

    let filename = ""

    if (file === undefined) {
        alert("arquivo não encontrado");
        return
    }

    if (file.type === "image/png")
        filename = `${Date.now()}.png`
    else if (file.type === "image/jpg")
        filename = `${Date.now()}.jpg`
    else {
        if (file.type === "image/jpeg")
            filename = `${Date.now()}.jpeg`
        else {
            alert("erro");
            return
        }

    }

    var data = new FormData()

    data.append("profile_img", file, filename)

    $("#loader").removeClass("d-none")
    $("#content").addClass("d-none")
    $("#loader").addClass("d-flex")

    try {
        await axios.post("https://myrecipeimages.herokuapp.com/", data)

    }
    catch (e) {
        alert("erro");
        return;
    }

    $.ajax({
        url: "CreateRecipe.aspx/Test",
        method: "POST",
        datatype: "json",
        contentType: "application/json",
        data: JSON.stringify(
            {
                name,
                description,
                ingredients: Ingredients,
                preparation_method,
                number_of_people,
                preparation_time,
                difficulty_id,
                category_id,
                filename: filename,
                user_id: userid
            }
        ),
        success: function (e) {
            window.location.replace("https://localhost:44344/Profile");
        },
        error: function (e) {
            alert("erro")

            $("#content").removeClass("d-none")
            $("#loader").removeClass("d-flex")
            $("#loader").addClass("d-none")

        }
    })

}

document.querySelector("#SubmitButton").addEventListener("click", addSubmition)

// adding ingredients

const addIngredient = (e) => {

    e.preventDefault()

    const ingredientsList = document.querySelector("#MainContent_IngredientsList")

    const ingredientName = ingredientsList.options[ingredientsList.selectedIndex].text

    const ingredientId = ingredientsList.options[ingredientsList.selectedIndex].value

    const measuresList = document.querySelector("#MainContent_MeasuresList")

    const measureName = measuresList.options[measuresList.selectedIndex].text

    const measureId = measuresList.options[measuresList.selectedIndex].value

    const quantity = document.querySelector("#MainContent_Quantity").value

    const TableRow = `
                    
                 <tr>
                        <td>${ingredientName}</td>
                        <td>${quantity}</td>
                        <td>${measureName}</td>

                        <td><button type='button' class='btn btn-danger text-white removeIngredient ' onclick=removeIngredient(${indexIngredient}); >
                        <svg xmlns='http://www.w3.org/2000/svg' width='16' height='16' fill='currentColor' class='bi bi-x-lg' viewBox='0 0 16 16'>
                            <path d='M1.293 1.293a1 1 0 0 1 1.414 0L8 6.586l5.293-5.293a1 1 0 1 1 1.414 1.414L9.414 8l5.293 5.293a1 1 0 0 1-1.414 1.414L8 9.414l-5.293 5.293a1 1 0 0 1-1.414-1.414L6.586 8 1.293 2.707a1 1 0 0 1 0-1.414z' />
                            </svg >
                        </button></td>
                 </tr>

                `

    document.querySelector("#Tbody").innerHTML += TableRow
    indexIngredient++


    Ingredients.push({ ingredient_id: Number(ingredientId), measure_id: Number(measureId), quantity, ingredientName, measureName })

}

const removeIngredient = (index) => {

    indexIngredient = 0;

    switch (index) {
        case 0:
            Ingredients.shift()
            break;

        case Ingredients.length - 1:
            Ingredients.pop()
            break;

        default:
            Ingredients.splice(index, 1)
            break;
    }



    document.querySelector("#Tbody").innerHTML = ""

    for (i = 0; i < Ingredients.length; i++) {
        let TableRow = `
                    
                     <tr>
                            <td>${Ingredients[i].ingredientName}</td>
                            <td>${Ingredients[i].quantity}</td>
                            <td>${Ingredients[i].measureName}</td>

                            <td><button type='button' class='btn btn-danger text-white removeIngredient ' onclick=removeIngredient(${i}); >
                            <svg xmlns='http://www.w3.org/2000/svg' width='16' height='16' fill='currentColor' class='bi bi-x-lg' viewBox='0 0 16 16'>
                                <path d='M1.293 1.293a1 1 0 0 1 1.414 0L8 6.586l5.293-5.293a1 1 0 1 1 1.414 1.414L9.414 8l5.293 5.293a1 1 0 0 1-1.414 1.414L8 9.414l-5.293 5.293a1 1 0 0 1-1.414-1.414L6.586 8 1.293 2.707a1 1 0 0 1 0-1.414z' />
                                </svg >
                            </button></td>
                     </tr>

                    `

        document.querySelector("#Tbody").innerHTML += TableRow

        indexIngredient++
    }

}

document.querySelector("#IngredientsButton").addEventListener("click", addIngredient)
