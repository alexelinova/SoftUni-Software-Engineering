function solve(x1, y1, x2, y2) {

    function calculateDistancce(px1, py1, px2, py2) {
        return Math.sqrt((px2 - px1) ** 2 + (py2 - py1) ** 2)
    }

    Number.isInteger(calculateDistancce(x1, y1, 0, 0))
        ? console.log(`{${x1}, ${y1}} to {0, 0} is valid`)
        : console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);

    Number.isInteger(calculateDistancce(x2, y2, 0, 0))
        ? console.log(`{${x2}, ${y2}} to {0, 0} is valid`)
        : console.log(`{${x2}, ${y2}} to {0, 0} is invalid`);

        
    Number.isInteger(calculateDistancce(x1, y1, x2, y2))
    ? console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`)
    : console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
}

