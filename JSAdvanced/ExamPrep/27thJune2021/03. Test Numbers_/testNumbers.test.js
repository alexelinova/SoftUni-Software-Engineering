const testNumbers = require('./testNumbers');
const {assert} = require('chai');

describe("Test Numbers", function() {
    describe("Sum number tests", function() {
        it("should return undefined when the first parameter is not a number", function() {
        
            assert.equal(testNumbers.sumNumbers('string', 5), undefined);
            assert.equal(testNumbers.sumNumbers({}, 5), undefined);
            assert.equal(testNumbers.sumNumbers([], 5), undefined);
        });

        it("should return undefined when the second parameter is not a number", function() {
            assert.equal(testNumbers.sumNumbers(5, 'string'), undefined);
            assert.equal(testNumbers.sumNumbers(5, {}), undefined);
            assert.equal(testNumbers.sumNumbers(5, []), undefined);
        });

        it("should return sum of the numbers for positive and negative rounded two the second decimal", function() {
            assert.equal(testNumbers.sumNumbers(5, 5), 10.00);
            assert.equal(testNumbers.sumNumbers(-5, -5), -10.00);
            assert.equal(testNumbers.sumNumbers(-5.5, 5.5), 0.00)
           
        });
     });
     
     describe("Number checker", function() {
        it("should return error when the input is not a number", function() {
        
           assert.throws(() => {testNumbers.numberChecker('string')}, 'The input is not a number!')
        });

        it("should return even when the input is an even number", function() {
        
            assert.equal(testNumbers.numberChecker('6'), 'The number is even!');
            
         });

         it("should return odd when the input is an odd number", function() {
        
            assert.equal(testNumbers.numberChecker(5), 'The number is odd!');
            
         });

     });

     describe("Average sum", function() {
        it("should return 0 when array is empty", function() {
        
           assert.equal(testNumbers.averageSumArray([0]), 0);
        });

        it("should return average number of the array sum", function() {
        
            assert.equal(testNumbers.averageSumArray([2, 4, 6]), 4);
         });

     });
});
