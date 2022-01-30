function cityTaxes(name, population, treasury) {
    let record = {
        name,
        population,
        treasury,
        taxRate: 10,
        collectTaxes() {
            this.treasury += Math.floor(this.population * this.taxRate);
        },
        applyGrowth(percentage) {
            this.population += Math.floor(percentage/100 * this.population);
        },
        applyRecession(percentage) {
            this.treasury -= Math.floor(this.treasury * percentage/100);
        }
    };

    return record;
}

const city =
  cityTaxes('Tortuga',
  7000,
  15000);
city.collectTaxes();
console.log(city.treasury);
city.applyGrowth(5);
console.log(city.population);
