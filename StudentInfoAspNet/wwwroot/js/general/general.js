"use strict";

let connection = new signalR.HubConnectionBuilder().withUrl("/studentsInfoHub").build();
let topStudentsList = document.getElementById("topStudents");
let topGroupsList = document.getElementById("topGroups");
let groupsList = document.getElementById('groups');
let studentsList = document.getElementById('students');
let addGroupButton = document.getElementById('addGroupButton');
let addStudentsButton = document.getElementById('addStudentButton');
let groupSelect = document.getElementById("groupId");

if (addGroupButton)
    addGroupButton.disabled = true;

if (addStudentsButton)
    addStudentsButton.disabled = true;

connection.start().then(function () {
    connection.invoke("ReceiveTopGroups").catch(function (err) {
        return console.error(err.toString());
    });
    connection.invoke("ReceiveTopStudents").catch(function (err) {
        return console.error(err.toString());
    });
    if (addGroupButton) {
        addGroupButton.disabled = false;
        
    }
    if (addStudentsButton) {
        addStudentsButton.disabled = false;
        connection.invoke("ReceiveStudents").catch(function (err) {
            return console.error(err.toString());
        });
    }
    connection.invoke("ReceiveGroups").catch(function (err) {
        return console.error(err.toString());
    });

}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("ReceiveTopGroups", function (topGroups) {
    if (topGroups) {
        topGroupsList.innerHTML = "";
        for (let i in topGroups) {
            let group = topGroups[i];
            let p = document.createElement("p");
            p.innerText = group.title + " " + group.averageScore;
            topGroupsList.appendChild(p);
        }
    }
});

connection.on("ReceiveTopStudents", function (topStudents) {
    if (topStudents) {
        topStudentsList.innerHTML = "";
        for (let i in topStudents) {
            let student = topStudents[i];
            let p = document.createElement("p");
            p.innerText = student.name + " " + student.averageScore;
            topStudentsList.appendChild(p);
        }
    }
});
if (studentsList) {
    connection.on("ReceiveStudents", function (students) {
        studentsList.innerHTML = "";
        students.forEach((student) => {
            let tr = document.createElement('tr');
            let name = document.createElement('td');
            let secondName = document.createElement('td');
            let lastName = document.createElement('td');
            let averageScore = document.createElement('td');
            let groupName = document.createElement('td');
            name.textContent = student.name;
            secondName.textContent = student.secondName;
            lastName.textContent = student.lastName;
            averageScore.textContent = student.averageScore;
            groupName.textContent = student.group.title;
            tr.appendChild(name);
            tr.appendChild(secondName);
            tr.appendChild(lastName);
            tr.appendChild(averageScore);
            tr.appendChild(groupName);
            studentsList.appendChild(tr);
        })
        
    });
    connection.on("ReceiveGroups", function (groups) {
        groupSelect.innerHTML = "";
        groups.forEach((group) =>
        {
            let option = document.createElement('option');
            option.value = group['id'];
            option.innerText = group['title'];
            groupSelect.appendChild(option);
        })
    });
}

if (groupsList) {
    connection.on("ReceiveGroups", function (groups) {
        groupsList.innerHTML = "";
        groups.forEach((group) => {
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
        })
    });
}


if (addGroupButton) {
    addGroupButton.addEventListener("click", function (event) {
        let title = document.getElementById("title").value;
        let curatorFamily = document.getElementById("curatorFamily").value;
        let titleDirection = document.getElementById("titleDirection").value;
        let averageScore = document.getElementById("averageScore").value;
        let groupProperties = {
            Title: title,
            CuratorFamily: curatorFamily,
            TitleDirection: titleDirection,
            AverageScore: averageScore
        }
        connection.invoke("SendGroup", groupProperties).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();
    });
}

if (addStudentsButton) {
    addStudentsButton.addEventListener("click", function (event) {
        let name = document.getElementById("name").value;
        let secondName = document.getElementById("secondName").value;
        let lastName = document.getElementById("lastName").value;
        let averageScore = document.getElementById("averageScore").value;
        let groupId = document.getElementById("groupId").value;
        
        let studentProperties = {
            Name: name,
            SecondName: secondName,
            LastName: lastName,
            AverageScore: averageScore,
            GroupId: groupId
        }
        connection.invoke("SendStudent", studentProperties).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();
    });
}



