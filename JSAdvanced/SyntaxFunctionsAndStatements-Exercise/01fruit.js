function solve(fruit, weight, price) {
    let weightInKilos = weight/1000;
    let totalPrice = weightInKilos * price;

    console.log(`I need $${totalPrice.toFixed(2)} to buy ${weightInKilos.toFixed(2)} kilograms ${fruit}.`);
}

