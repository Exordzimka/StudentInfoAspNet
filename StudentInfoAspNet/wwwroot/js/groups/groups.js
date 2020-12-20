"use strict";

// Disable send button until connection is established
document.getElementById("AddButton").disabled = true;

connection.on("RecieveGroups", function (groups) {
    let groupsList = document.getElementById('groups');
    groupsList.innerHTML = "";
    groups.forEach((group) =>
    {
        let tr = document.createElement('tr');
        let title = document.createElement('td');
        let curatorFamily = document.createElement('td');
        let titleDirection = document.createElement('td');
        let averageScore = document.createElement('td');
        title.textContent = group['title'];
        curatorFamily.textContent = group['curatorFamily'];
        titleDirection.textContent = group['titleDirection'];
        averageScore.textContent = group['averageScore'];
        tr.appendChild(title);
        tr.appendChild(curatorFamily);
        tr.appendChild(titleDirection);
        tr.appendChild(averageScore);
        groupsList.appendChild(tr);
    } )
});

connection.start().then(function () {
    //document.getElementById("AddButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("AddButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});