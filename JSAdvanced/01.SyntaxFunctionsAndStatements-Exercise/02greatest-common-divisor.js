function greatestCommonDivisor(x, y) {
    let gcd = 1;
    let smallerNum = Math.min(x, y);

    for (let index = 1; index <= smallerNum; index++) {
        if(x % index == 0 && y % index == 0)
        {
            gcd = index;
        }   
    }

    console.log(gcd);
}

