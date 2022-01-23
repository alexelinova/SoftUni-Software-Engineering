function solve(n, k) {
    let array = [1];

    for (let i = 1; i < n; i++) {
        array[i] = calculateNum();
    }

    function calculateNum() {
        let len = array.length <= k ? array.length : k;
        let result = 0;
        for (let i = 0; i < len; i++) {
            result += array[array.length - 1 - i];
        }
        return result;
    }

    return array;
}

