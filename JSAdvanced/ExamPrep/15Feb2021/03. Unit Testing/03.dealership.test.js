let dealership = require('./03.dealership');
let {assert} = require('chai');

describe("Tests dealership", function() {
    describe("newCarCost", function() {

        it("should discount 15000 when the car model is Audi A4 B8", function() {
           assert.equal(dealership.newCarCost('Audi A4 B8', 50000), 35000);
        });

        it("should discount 20000 when the car model is Audi A6 4K", function() {
            assert.equal(dealership.newCarCost('Audi A6 4K', 50000), 30000);
         });

         it("should discount 25000 when the car model is Audi A8 D5", function() {
            assert.equal(dealership.newCarCost('Audi A8 D5', 50000), 25000);
         });

         it("should discount 14000 when the car model is Audi TT 8J", function() {
            assert.equal(dealership.newCarCost('Audi TT 8J', 50000), 36000);
         });
         
         it("should discount 14000 when the car model is Audi TT 8J", function() {
            assert.equal(dealership.newCarCost('Audi TT 8J', 50000), 36000);
         });

         it("should not discount when modelCar does not exist", function() {
            assert.equal(dealership.newCarCost('Test', 50000), 50000);
         });
     });

     describe("carEquipment", function() {

        it("should return an array with preferred extras", function() {
           assert.deepEqual(dealership.carEquipment(['heated seats', 'sliding roof', 'navigation'],[0]), ['heated seats']);
        });
       
     });

     describe("euroCategory", function() {

        it("shouldn't add discount if caterogy is less than 4", function() {
           assert.equal(dealership.euroCategory(3), 'Your euro category is low, so there is no discount from the final price!');
        });

        it("should add 5% discount when category is equal to 4 ", function() {
            assert.equal(dealership.euroCategory(4), 'We have added 5% discount to the final price: 14250.');
         });
         
         it("should add 5% discount when category is more than 4 ", function() {
            assert.equal(dealership.euroCategory(5), 'We have added 5% discount to the final price: 14250.');
         });
     });

  
});
