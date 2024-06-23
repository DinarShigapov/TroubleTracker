// script.js
function showTaskDetails(taskId, taskTitle, taskDescription) {
    document.getElementById('taskTitle').value = taskTitle;
    document.getElementById('taskDescription').value = taskDescription;
    document.getElementById('taskAssignee').innerText = 'Без назначения'; // Placeholder
    document.getElementById('taskAuthor').innerText = 'Динар Шигапов'; // Placeholder
    document.getElementById('taskTags').innerText = 'Нет'; // Placeholder
    document.getElementById('taskPriority').innerText = 'Medium'; // Placeholder
    document.getElementById('taskSprint').innerText = 'None'; // Placeholder
}

function saveTaskDetails() {
    const taskTitle = document.getElementById('taskTitle').value;
    const taskDescription = document.getElementById('taskDescription').value;
    alert(`Task "${taskTitle}" saved with description: "${taskDescription}"`);
}

function showActivity(activity) {
    document.querySelectorAll('.activity-content').forEach(content => {
        content.classList.add('d-none');
    });
    if (activity === 'all') {
        document.getElementById('all-activities').classList.remove('d-none');
    } else {
        document.getElementById(activity).classList.remove('d-none');
    }
}

function addComment(event) {
    event.preventDefault();
    const commentText = document.getElementById('newComment').value;
    if (commentText.trim()) {
        const commentList = document.getElementById('commentList');
        const newComment = document.createElement('div');
        newComment.classList.add('comment');
        newComment.innerText = commentText;
        commentList.appendChild(newComment);
        document.getElementById('newComment').value = '';
    }
}

function changeStatus(status) {
    let statusText;
    switch (status) {
        case 'to-do':
            statusText = 'К работе';
            break;
        case 'in-progress':
            statusText = 'К выполнению';
            break;
        case 'done':
            statusText = 'Готово';
            break;
    }
    alert(`Status changed to: ${statusText}`);
}

