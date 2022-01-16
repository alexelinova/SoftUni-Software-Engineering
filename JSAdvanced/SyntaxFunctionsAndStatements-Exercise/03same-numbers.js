function sameNumbers (number) {
    let numberAsString = number.toString();
    let firstNum = numberAsString[0];
    let sum = 0;
    let isSame = true;

    for (let i = 0; i < numberAsString.length; i++) {
        if(numberAsString[i] != firstNum)
        {
            isSame = false;
        }

        sum += Number(numberAsString[i]);
    }

    console.log(isSame);
    console.log(sum);
}

