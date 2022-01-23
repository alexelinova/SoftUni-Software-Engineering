function evenPosition(array) {
    let output = '';
    for (let i = 0; i < array.length; i++) {
        if (i % 2 == 0) {
            output += array[i] + ' ';
        }
    }
    console.log(output);
}

