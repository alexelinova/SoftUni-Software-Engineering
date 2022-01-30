function calc() {
    let firstNumElement = document.getElementById('num1');
    let secondNumElement = document.getElementById('num2');

    let firstNum = Number(firstNumElement.value);
    let secondNum = Number(secondNumElement.value);

    let resultElement = document.getElementById('sum');
    resultElement.value = firstNum + secondNum;
}
