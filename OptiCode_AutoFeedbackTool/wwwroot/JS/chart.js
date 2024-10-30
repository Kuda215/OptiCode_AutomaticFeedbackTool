function createChart() {
    var ctx = document.getElementById('myChart').getContext('2d');
    var myChart = new Chart(ctx, {
        type: 'bar', // Set the default chart type to bar
        data: {
            labels: ['January', 'February', 'March', 'April', 'May'],
            datasets: [
                {
                    label: 'Bar Data',
                    data: [12, 19, 3, 5, 2],
                    backgroundColor: 'rgba(75, 192, 192, 0.5)',
                    borderColor: 'rgba(75, 192, 192, 1)',
                    borderWidth: 1
                },
                {
                    label: 'Line Data',
                    type: 'line', // Specify the type for the line chart
                    data: [10, 15, 5, 8, 3],
                    borderColor: 'rgba(255, 99, 132, 1)',
                    borderWidth: 2,
                    fill: false // Disable fill for the line
                }
            ]
        },
        options: {
            responsive: false,
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
}

function getChartImage() {
    var canvas = document.getElementById('myChart');
    return canvas.toDataURL('image/png').split(',')[1]; // Return base64 image data without prefix
}
