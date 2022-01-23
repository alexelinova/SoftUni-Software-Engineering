function solve(flavours, startFlavour, endFlavour) {
    const start = flavours.indexOf(startFlavour, 0);
    const end = flavours.indexOf(endFlavour, 0);

    const result = flavours.slice(start, end + 1);

    return result;
}

