class ChristmasDinner {

    constructor(budget) {

        if (budget < 0) {
            throw new Error('The budget cannot be a negative number');
        }

        this.budget = budget;
        this.dishes = [];
        this.products = [];
        this.guests = {};
    }

    shopping(product) {
        let [productName, price] = product;

        if (this.budget < price) {
            throw new Error('Not enough money to buy this product');
        }

        this.products.push(productName);
        this.budget -= price;

        return `You have successfully bought ${productName}!`;
    }

    recipes(recipe) {
        recipe.productsList.forEach(element => {
            if (!this.products.some(x => x == element)) {
                throw new Error('We do not have this product');
            }
        });

        this.dishes.push(recipe);
        return `${recipe.recipeName} has been successfully cooked!`;
    }

    inviteGuests(name, dish) {
        let findDish = this.dishes.find(x => x.recipeName == dish);

        if (findDish == undefined) {
            throw new Error('We do not have this dish');
        }

        if (this.guests[name] != undefined) {
            throw new Error('This guest has already been invited');
        }

        this.guests[name] = dish;

        return `You have successfully invited ${name}!`;
    }

    showAttendance(){
        let result = [];
        
        for (const guest in this.guests) {
            let products = this.dishes.find(x => x.recipeName == this.guests[guest]);
            result.push(`${guest} will eat ${this.guests[guest]}, which consists of ${products.productsList.join(', ')}`);
        }

        return result.join('\n');
    }
}

let dinner = new ChristmasDinner(300);

dinner.shopping(['Salt', 1]);
dinner.shopping(['Beans', 3]);
dinner.shopping(['Cabbage', 4]);
dinner.shopping(['Rice', 2]);
dinner.shopping(['Savory', 1]);
dinner.shopping(['Peppers', 1]);
dinner.shopping(['Fruits', 40]);
dinner.shopping(['Honey', 10]);

dinner.recipes({
    recipeName: 'Oshav',
    productsList: ['Fruits', 'Honey']
});
dinner.recipes({
    recipeName: 'Folded cabbage leaves filled with rice',
    productsList: ['Cabbage', 'Rice', 'Salt', 'Savory']
});
dinner.recipes({
    recipeName: 'Peppers filled with beans',
    productsList: ['Beans', 'Peppers', 'Salt']
});

dinner.inviteGuests('Ivan', 'Oshav');
dinner.inviteGuests('Petar', 'Folded cabbage leaves filled with rice');
dinner.inviteGuests('Georgi', 'Peppers filled with beans');

console.log(dinner.showAttendance());
