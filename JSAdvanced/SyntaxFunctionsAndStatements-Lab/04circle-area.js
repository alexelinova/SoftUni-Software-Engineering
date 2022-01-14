function circleArea(num) {
    let typeOfNum = typeof num;

    if (typeOfNum === 'number') {
        let result = num ** 2 * Math.PI;
        console.log(result.toFixed(2));
    } else {
        console.log(`We can not calculate the circle area, because we receive a ${typeof num}.`);
    }
}