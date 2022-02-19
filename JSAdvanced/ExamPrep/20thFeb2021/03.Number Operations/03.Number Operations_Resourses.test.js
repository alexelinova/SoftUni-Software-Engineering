let numberOperations = require('./03. Number Operations_Resources');
let {assert} = require('chai');

describe("Tests number operations", function() {
    describe("Tests powNumber", function() {
        it("should return power of the given number when valid parameter is passed", function() {
            assert.equal(numberOperations.powNumber(2), 4)
        });
     });
     
     describe("Tests numberChecker", function() {
        it("should return an error when the parameter is not a number", function() {
           assert.throws(() => {numberOperations.numberChecker('test')}, 'The input is not a number!');
        });

        it("should return 'The number is greater or equal to 100!' when number is above 100", function() {
            assert.equal(numberOperations.numberChecker(101), 'The number is greater or equal to 100!');
         });

         
        it("should return 'The number is greater or equal to 100!' when number is equal to 100", function() {
            assert.equal(numberOperations.numberChecker(100), 'The number is greater or equal to 100!');
         });

         it("should return 'The number is lower than 100!' when number is less than 100", function() {
            assert.equal(numberOperations.numberChecker(1), 'The number is lower than 100!');
         });

         it("should validate number", function() {
            assert.equal(numberOperations.numberChecker('1'), 'The number is lower than 100!');
         });
     });

     describe("Tests summArrays", function() {
        it("should return the summ of the elements in a new array", function() {
           assert.deepEqual([2, 4, 3], numberOperations.sumArrays([1, 2, 3], [1, 2]));
        });
     });
});
