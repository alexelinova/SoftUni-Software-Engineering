const library = require('./library');
const {assert, expect} = require('chai');

describe("Library object", function() {
    describe("Calculate price of book", function() {
        it("should return price is 20 when input is valid and year after 1980", function() {
            assert.equal(library.calcPriceOfBook('Test', 1999), `Price of Test is 20.00`);
        });

        it("should return 50% dicsount of price when input is valid and year 1980", function() {
            assert.equal(library.calcPriceOfBook('Test', 1980), `Price of Test is 10.00`);
        });

        it("should return 50% dicsount of price when input is valid and year before 1980", function() {
            assert.equal(library.calcPriceOfBook('Test', 1970), `Price of Test is 10.00`);
        });

        it("should return error when name of book is a number", function() {
            assert.throws(() => library.calcPriceOfBook (5, 1980), 'Invalid input');
        });

        it("should return error when name of book is an object", function() {
            assert.throws(() => library.calcPriceOfBook ({}, 1980), 'Invalid input');
        });

        it("should return error when name of book is an array", function() {
            assert.throws(() => library.calcPriceOfBook ([], 1980), 'Invalid input');
        });

        it("should return error when year of book is a string", function() {
            assert.throws(() => library.calcPriceOfBook ('Test', 'string'), 'Invalid input');
        });

        it("should return error when year of book is an object", function() {
            assert.throws(() => library.calcPriceOfBook ('Test', {}), 'Invalid input');
        });

        it("should return error when year of book is an array", function() {
            assert.throws(() => library.calcPriceOfBook ('Test', []), 'Invalid input');
        });
     });

     describe("Find book", function() {
        it("should throw an error when the array is empty", function() {
            assert.throws(() => library.findBook([], 'Test'), `No books currently available`);
        });

        it("should find the book when it is in the collection and return a message", function() {
            assert.equal(library.findBook(['Test', 'Test1', 'Test2'], 'Test'), `We found the book you want.`);
        });

        it("should find the book when it is in the collection and return a message", function() {
            assert.equal(library.findBook(['Test'], 'Test'), `We found the book you want.`);
        });

        it("should return a message when the book is not found ", function() {
            assert.equal(library.findBook(['Test1', 'Test2'], 'Test'), `The book you are looking for is not here!`);
        });
     });

     describe("Arrange the books", function() {
        it("should throw an error when the number is not integer", function() {
            assert.throws(() => library.arrangeTheBooks(2.5), `Invalid input`);
        });

        it("should throw an error when the number is negative", function() {
            assert.throws(() => library.arrangeTheBooks(-10), `Invalid input`);
        });

        it("should throw an error when the input is string", function() {
            assert.throws(() => library.arrangeTheBooks('test'), `Invalid input`);
        });

        it("should throw an error when the input is object", function() {
            assert.throws(() => library.arrangeTheBooks({}), `Invalid input`);
        });

        it("should throw an error when the input is array", function() {
            assert.throws(() => library.arrangeTheBooks([]), `Invalid input`);
        });

        it("should return a message when the space is insufficient", function() {
            assert.equal(library.arrangeTheBooks(45), `Insufficient space, more shelves need to be purchased.`);
        });

        it("should return a message when the space is sufficient", function() {
            assert.equal(library.arrangeTheBooks(35), `Great job, the books are arranged.`);
        });

        it("should return a message when the space is sufficient", function() {
            assert.equal(library.arrangeTheBooks(40), `Great job, the books are arranged.`);
        });

     });
    
});