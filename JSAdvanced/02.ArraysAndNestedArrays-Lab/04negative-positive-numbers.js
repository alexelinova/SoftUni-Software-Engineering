function solve(arr) {
    const resultArray = [];

    for (const num of arr) {
        if (num >= 0) {
            resultArray.push(num);
        } else {
            resultArray.unshift(num);
        }
    }

    for (const num of resultArray) {
        console.log(num);
    }
}
