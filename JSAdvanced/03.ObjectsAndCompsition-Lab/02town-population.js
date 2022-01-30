function townPopulation(array) {
    const towns = {};

    for (const townData of array) {
        let [name, population] = townData.split(' <-> ');
        population = Number(population);

        if (towns[name] == undefined) {
            towns[name] = 0;
        }

        towns[name] += population;
    }

    for (const town in towns) {
        console.log(`${town} : ${towns[town]}`);
    }

}
