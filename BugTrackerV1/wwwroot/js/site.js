var sprintData = @Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(Model.IssuesBySprint));
var userData = @Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(Model.IssuesByUser));
var projectData = @Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(Model.IssuesByProject));

function renderChart(ctx, data, label) {
    new Chart(ctx, {
        type: 'bar',
        data: {
            labels: Object.keys(data),
            datasets: [{
                label: label,
                data: Object.values(data),
                backgroundColor: 'rgba(75, 192, 192, 0.2)',
                borderColor: 'rgba(75, 192, 192, 1)',
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
}

renderChart(document.getElementById('sprintChart').getContext('2d'), sprintData, 'Issues by Sprint');
renderChart(document.getElementById('userChart').getContext('2d'), userData, 'Issues by User');
renderChart(document.getElementById('projectChart').getContext('2d'), projectData, 'Issues by Project');

