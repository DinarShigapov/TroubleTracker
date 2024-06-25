function filterTable() {
    const input = document.getElementById('searchInput');
    const filter = input.value.toLowerCase();
    const tableBody = document.getElementById('tableBody');
    const rows = tableBody.getElementsByTagName('tr');

    for (let i = 0; i < rows.length; i++) {
        const titleCell = rows[i].getElementsByTagName('td')[0];
        if (titleCell) {
            const title = titleCell.textContent || titleCell.innerText;
            rows[i].style.display = title.toLowerCase().indexOf(filter) > -1 ? '' : 'none';
        }

    }
}

function removeUser(projectId, userId) {
    $.post('/Project/RemoveUser', { projectId: projectId, userId: userId }, function (response) {
        if (response.success) {
            location.reload();
        }
    });
}


function addUser(projectId, userId, button) {
    $.post('/Project/AddUser', { projectId: projectId, userId: userId }, function (response) {
        if (response.success) {
            location.reload();
        }
    });
}
function filterUsers() {
    const input = document.getElementById('searchUser');
    const filter = input.value.toLowerCase();
    const tableBody = document.getElementById('userList');
    const rows = tableBody.getElementsByTagName('tr');

    for (let i = 0; i < rows.length; i++) {
        const titleCell = rows[i].getElementsByTagName('td')[0];
        if (titleCell) {
            const title = titleCell.textContent || titleCell.innerText;
            rows[i].style.display = title.toLowerCase().indexOf(filter) > -1 ? '' : 'none';
        }

    }
}