
var apiInfo = document.getElementById("body");
var uri = "https://localhost:44325/api/API";



async function getResponse() {
    let response = await fetch("https://localhost:44325/api/API")
    let content = await response.json()
    console.log(content)
    let list = await document.getElementById("table_ToDoList")

    list.innerHTML = "";

    await content.forEach(item => {
        const { id, completedNotCompleted, dateOfCompletion, priority, task } = item;
        list.innerHTML +=
            `<tr>
                <th>${id}</th>
                <td>${completedNotCompleted}</td>
                <td>${dateOfCompletion}</td>
                <td>${priority}</td>
                <td>${task}</td>
                <td>
                <a class="btn btn-outline-success" id="apiEdit" href="/api/API/${id}">Edit</a> |
                <a class="btn btn-outline-info" id="apiDetails" onclick="Details_TodoLosiApi(${id});">Details</a> |
                <a class="btn btn-outline-danger" id="apiDelete"  onclick="Delite_TodoLosiApi(${id});">Delete</a>
                </td>
             </tr>`
    });
}
getResponse()


async function addItem() {
    const addNameTextbox = document.getElementById('edit-name');
    const addNameComplete = document.getElementById('edit-isComplete');
    const addNameDate = document.getElementById('edit-date');
    const addNamePriority = document.getElementById('edit-priority');

    const item = {
        completedNotCompleted: false,
        dateOfCompletion: addNameDate.value.trim(),
        priority: addNamePriority.value.trim(),
        task: addNameTextbox.value.trim()

    };

    await fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })

    await getResponse();
}

var buttonaEdit = document.getElementById("apiEdit");
var buttonaDetails = document.getElementById("apiDetails");
var buttonaDelete = window.document.getElementById('apiDelete');



async function Delite_TodoLosiApi(id) {
    await fetch(`${uri}/${id}`, {
        method: 'DELETE'
    });

    await getResponse();
};



async function Details_TodoLosiApi(item) {
    let response = await fetch("https://localhost:44325/api/API" + "/" + item)
    let content = await response.json()
    console.log(content)
    let list = await document.getElementById("table_ToDoList")
    list.innerHTML = "";


    
    list.innerHTML +=
        `
               <div class="alert alert-success" role="alert">
               <h4 class="alert-heading">Задача!</h4>
               <p>${content.task}</p>
               <hr>
               <p class="mb-0"><h5>Приоритет</h5>${content.priority}</p>
               <hr>
               <p class="mb-0"><h5>Запланировано на</h5> ${content.dateOfCompletion}</p>
               <hr>
               <p class="mb-0"><h5>Статус выполнения</h5> ${content.completedNotCompleted}</p>
               |<a class="btn btn-outline-danger" id="apiDelete"  onclick="Delite_TodoLosiApi(${content.id});">Delete</a>|
               <a class="btn btn-outline-success" id="apiEdit"  onclick="getResponse();">Back</a> |
               </div>`

    
}
