

var apiInfo = document.getElementById("body");

async function getResponse() {
    let response = await fetch("https://localhost:44325/api/API")
    let content = await response.json()
    //apiInfo.innerHTML = await JSON.stringify(content)
    console.log(content)
    let list = await document.getElementById("table_ToDoList")

    content.forEach(item => {
        const { id, completedNotCompleted, dateOfCompletion, priority, task } = item;
        list.innerHTML +=
            `<tr>
                <th>${id}</th>
                <td>${completedNotCompleted}</td>
                <td>${dateOfCompletion}</td>
                <td>${priority}</td>
                <td>${task}</td>
             </tr>`
    });
}
getResponse()

