const w = 500;
const h = 500;
const barSpace = 1;
const textPaddingRight = 5;

function updateData() {
    const inputStr = document.getElementById("inputData").value;
    document.getElementById("err-msg").classList.toggle("no-error", true);

    if (validate(inputStr) === true) {
        const container = document.getElementById("svg-container");
        removeChildren(container);

        const dataset = inputStr.split(",").map(Number);
        refreshChart(dataset);
    } else {
        document.getElementById("err-msg").classList.toggle("no-error", false);
    }
}

function validate(str) {
    const regex = /^\d+(,\s*\d+)*$/;
    return regex.test(str);
}

function removeChildren(node) {
    let last;
    while (last = node.lastChild) node.removeChild(last);
};

function getRandomColor() {
    const letters = '0123456789ABCDEF';
    let color = '#';
    for (let i = 0; i < 6; i++) {
        color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
}

function refreshChart(dataset) {

    let svg = d3.select("#svg-container")
        .append("svg")
        .attr("width", w)
        .attr("height", h);

    createBars(svg, dataset);
    createTexts(svg, dataset);
}

function createBars(svg, dataset) {
    svg.selectAll("rect")
        .data(dataset)
        .enter()
        .append("rect")
        .attr("x", 0)
        .attr("y", function (d, i) {
            return i * (20 + barSpace);  //Ancho de barras de 20 más 1 espacio
        })
        .attr("width", function (d, i) {
            return (d + 1) * 20;  //Ancho de barras de 20 más 1 espacio
        })
        .attr("height", 20)
        .attr("fill", function () {
            return getRandomColor();
        });
}

function createTexts(svg, dataset) {
    svg.selectAll("text")
        .data(dataset)
        .enter()
        .append("text").text(function (d) {
            return d;
        })
        .attr("x", function (d, i) {
            return (d + 1) * 20 - textPaddingRight;
        })
        .attr("y", function (d, i) {
            return i * (20 + barSpace) + 15;
        })
        .attr("font-family", "sans-serif")
        .attr("font-size", "11px")
        .attr("fill", "white")
        .attr("text-anchor", "end");
}