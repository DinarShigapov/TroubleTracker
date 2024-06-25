let selectedFiles = [];
let isRemoving = false;

document.getElementById('fileInput').addEventListener('change', function () {
    const fileList = document.getElementById('fileList');
    const files = Array.from(this.files);

    selectedFiles.push(...files);
    fileList.innerHTML = '';

    selectedFiles.forEach((file, index) => {
        const li = document.createElement('div');
        li.classList.add('attachment-box', 'm-2');

        if (file.type.startsWith('image/')) {
            const img = document.createElement('img');
            img.src = URL.createObjectURL(file);
            img.style.width = '100%';
            img.style.height = '100%';
            img.style.objectFit = 'cover';
            li.appendChild(img);
        } else {
            const placeholder = document.createElement('div');
            placeholder.style.width = '100%';
            placeholder.style.height = '100%';
            placeholder.style.background = 'gray';
            placeholder.style.display = 'flex';
            placeholder.style.justifyContent = 'center';
            placeholder.style.alignItems = 'center';
            placeholder.style.color = 'white';
            placeholder.innerText = 'Файл';
            li.appendChild(placeholder);
        }

        function updateIndexes() {
            const fileItems = document.querySelectorAll('#fileList .attachment-box');
            fileItems.forEach((item, index) => {
                item.dataset.index = index;
            });
        }

        const removeButton = document.createElement('button');
        removeButton.textContent = '×';
        removeButton.classList.add('remove-button');
        removeButton.type = 'button'; 
        removeButton.onclick = () => {
            if (isRemoving) return;

            isRemoving = true; 

            const index = parseInt(li.dataset.index, 10);

            selectedFiles.splice(index, 1);
            li.remove();
            updateIndexes();

            setTimeout(() => {
                isRemoving = false;
            }, 100); 
        };
        li.appendChild(removeButton);

        fileList.appendChild(li);
    });

    this.value = '';
});

document.getElementById('issueForm').onsubmit = async function (event) {
    event.preventDefault();
    const formData = new FormData(this);

    selectedFiles.forEach(file => {
        formData.append('Attachments', file);
    });

    const response = await fetch(this.action, {
        method: 'POST',
        body: formData
    });

    if (response.ok) {
        alert('Issue saved successfully');
        window.location.href = '/Issue/Index'; 
    } else {
        alert('Failed to save issue');
    }
};

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
