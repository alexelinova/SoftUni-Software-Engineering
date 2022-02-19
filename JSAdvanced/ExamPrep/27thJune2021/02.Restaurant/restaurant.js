class Restaurant {
    constructor(budgetMoney) {
        this.budgetMoney = budgetMoney;
        this.menu = {};
        this.stockProducts = {};
        this.history = [];
    }

    loadProducts(products) {
        for (const product of products) {
            let [productName, productQuantity, productTotalPrice] = product.split(' ');

            if (productTotalPrice <= this.budgetMoney) {
                if (!this.stockProducts[productName]) {
                    this.stockProducts[productName] = 0;
                }
                this.stockProducts[productName] += Number(productQuantity);
                this.budgetMoney -= productTotalPrice;

                this.history.push(`Successfully loaded ${productQuantity} ${productName}`);
            } else {
                this.history.push(`There was not enough money to load ${productQuantity} ${productName}`)
            }
        }

        return this.history.join('\n');
    }

    addToMenu(meal, neededProducts, price) {
        if (!this.menu[meal]) {
            this.menu[meal] = {
                products: neededProducts,
                price
            }

            let totalMeals = Object.keys(this.menu);
        
            if (totalMeals.length == 1) {
                return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`
            } else {
                return `Great idea! Now with the ${meal} we have ${totalMeals.length} meals in the menu, other ideas?`
            }
        } else {
            return `The ${meal} is already in the our menu, try something different.`
        }
    }

    showTheMenu() {
        let currentMeals = [];

        if (Object.keys(this.menu) == 0) {
            return 'Our menu is not ready yet, please come later...';
        }

        for (const mealName in this.menu) {
            currentMeals.push(`${mealName} - $ ${this.menu[mealName].price}`);
        }

       return currentMeals.join('\n');
    }

    makeTheOrder(meal) {
        if (!this.menu[meal]) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        }

        for (const product of this.menu[meal].products) {
           let [productName, productQuantity] = product.split(' ');

           if (!this.stockProducts[productName] || this.stockProducts[productName] < Number(productQuantity)) {
               return  `For the time being, we cannot complete your order (${meal}), we are very sorry...`
           } 
           
        }

        for (const product of this.menu[meal].products) {
            let [productName, productQuantity] = product.split(' ');
            this.stockProducts[productName] -= Number(productQuantity);
         }

         this.budgetMoney += this.menu[meal].price;

        return  `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${this.menu[meal].price}.`

    }
}


let kitchen = new Restaurant(1000);
console.log(kitchen.showTheMenu());

