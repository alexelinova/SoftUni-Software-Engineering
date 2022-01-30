function sumTable() {
    let costElements = document.querySelectorAll('tr td:nth-of-type(2)');
    let sum = Array.from(costElements);
    let resultElement = sum.pop();

     sum = sum.reduce((a, x) => {
        return a + Number(x.textContent)
    }, 0);

    resultElement.textContent = sum;
}