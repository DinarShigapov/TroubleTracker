var cards = document.querySelectorAll('.kanban-card');

// Перебрать все карточки и добавить слушатели событий для перемещения
cards.forEach(function (card) {
  card.addEventListener('dragstart', dragStart);
  card.addEventListener('dragend', dragEnd);
});

// Функция, которая срабатывает при начале перетаскивания
function dragStart() {
  this.classList.add('dragging');
}

// Функция, которая срабатывает при окончании перетаскивания
function dragEnd() {
  this.classList.remove('dragging');
}

// Найти все столбцы Kanban
var columns = document.querySelectorAll('.kanban-column');

// Добавить слушатели событий для перетаскивания на столбцы
columns.forEach(function (column) {
  column.addEventListener('dragover', dragOver);
  column.addEventListener('dragenter', dragEnter);
  column.addEventListener('dragleave', dragLeave);
  column.addEventListener('drop', dragDrop);
});

// Функция, которая срабатывает при наведении на столбец
function dragOver(e) {
  e.preventDefault();
}

// Функция, которая срабатывает при входе в столбец
function dragEnter(e) {
  e.preventDefault();
  this.classList.add('hovered');
}

// Функция, которая срабатывает при выходе из столбца
function dragLeave() {
  this.classList.remove('hovered');
}

// Функция, которая срабатывает при отпускании карточки в столбце
function dragDrop() {
  var draggedCard = document.querySelector('.dragging');
  this.appendChild(draggedCard);
    this.classList.remove('hovered');

    var cardId = draggedCard.dataset.cardId;
    var newStatusId = this.dataset.statusId;
    $.ajax({
        url: '/ActiveSprint/UpdateCardStatus',
        type: 'POST',
        data: { cardId: cardId, newStatusId: newStatusId },
        success: function (response) {
            if (response.success) {
                alert('Data received: ' + response.receivedValue);
            }
        },
        error: function () {
            alert('Error sending data');
        }
    });

}

document.addEventListener('DOMContentLoaded', function () {
  // Находим общего родителя для всех колонок
    var kanbanContainer = document.querySelector('#kanbanContainer.row');

  // Добавляем обработчик событий для контейнера
  kanbanContainer.addEventListener('click', function (event) {
    var target = event.target;

    // Проверяем, была ли нажата стрелка
    if (target.classList.contains('arrow-left') || target.classList.contains('arrow-right')) {
      // Получаем родительскую колонку
      var column = target.closest('.col-md-3');

      // Получаем индекс текущей и целевой колонок
      var currentIndex = Array.from(column.parentNode.children).indexOf(column);
      var targetIndex;

      // Определяем направление перемещения в зависимости от нажатой стрелки
      if (target.classList.contains('arrow-left')) {
        targetIndex = currentIndex - 1;
      } else if (target.classList.contains('arrow-right')) {
        targetIndex = currentIndex + 1;
      }

      // Проверяем, можно ли переместить колонку в указанном направлении
      if (targetIndex >= 0 && targetIndex < column.parentNode.children.length) {
        // Получаем целевую колонку
        var targetColumn = column.parentNode.children[targetIndex];
 
        // Перемещаем текущую колонку перед или после целевой колонки в зависимости от направления
        if (targetIndex < currentIndex) {
          column.parentNode.insertBefore(column, targetColumn);
        } else {
          column.parentNode.insertBefore(column, targetColumn.nextSibling);
        }
      }
    }
  });
});
