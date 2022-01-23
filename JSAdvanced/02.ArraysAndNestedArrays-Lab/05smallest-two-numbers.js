function smallestTwo(arr) {
    arr.sort((a, b) => a - b);
    arr.length = 2;

    console.log(arr.join(' '));
}

