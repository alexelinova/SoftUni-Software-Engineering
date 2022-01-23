function biggerHalf(arr) {
    arr.sort((a, b) => b - a);
    arr.length = Math.ceil(arr.length / 2);

    arr.sort((a, b) => a - b);

    return arr;
}

