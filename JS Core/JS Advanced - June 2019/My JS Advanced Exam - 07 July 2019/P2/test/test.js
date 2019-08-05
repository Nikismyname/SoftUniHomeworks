var expect = require("chai").expect; 

class PizzUni {
    constructor() {
        this.registeredUsers = [];
        this.availableProducts = {
            pizzas: ['Italian Style', 'Barbeque Classic', 'Classic Margherita'],
            drinks: ['Coca-Cola', 'Fanta', 'Water']
        };
        this.orders = [];
    }

    registerUser(email) {

        const user = this.doesTheUserExist(email);

        if (user) {
            throw new Error(`This email address (${email}) is already being used!`)
        }

        const currentUser = {
            email,
            orderHistory: []
        };

        this.registeredUsers.push(currentUser);

        return currentUser;
    }

    makeAnOrder(email, orderedPizza, orderedDrink) {

        const user = this.doesTheUserExist(email);

        if (!user) {
            throw new Error(`You must be registered to make orders!`);
        }

        const isThereAPizzaOrdered = this.availableProducts.pizzas.includes(orderedPizza);

        if (!isThereAPizzaOrdered) {
            throw new Error('You must order at least 1 Pizza to finish the order.');
        }

        let userOrder = {
            orderedPizza
        };

        const isThereADrinkOrdered = this.availableProducts.drinks.includes(orderedDrink);

        if (isThereADrinkOrdered) {
            userOrder.orderedDrink = orderedDrink;
        }

        user.orderHistory.push(userOrder);

        const currentOrder = {
            ...userOrder,
            email,
            status: 'pending'
        };
        this.orders.push(currentOrder);

        return this.orders.length - 1;
    }

    detailsAboutMyOrder(id) {
        if (this.orders[id]) {
            return `Status of your order: ${this.orders[id].status}`;
        }
    }

    doesTheUserExist(email) {
        return this.registeredUsers.filter((user) => user.email === email)[0];
    }

    completeOrder() {
        if (this.orders.length > 0) {
            const index = this.orders.findIndex((o) => o.status === "pending");
            this.orders[index].status = 'completed';

            return this.orders[index];
        }
    }
}

describe("main", function() {
    it("constructor", function () {
        var pizzaUni = new PizzUni(); 
        expect(pizzaUni.registeredUsers ).to.deep.equal([]);
        expect(pizzaUni.orders).to.deep.equal([]);
        expect(pizzaUni.availableProducts).to.deep.equal({
            pizzas: ["Italian Style", "Barbeque Classic", "Classic Margherita"],
            drinks: ["Coca-Cola", "Fanta", "Water"] 
        });
    });

    it("registerUser throws", function () { 
        var pizzaUni = new PizzUni(); 
        pizzaUni.registerUser("asdf");
        expect(() => pizzaUni.registerUser("asdf")).to.throw("This email address (asdf) is already being used!"); 
    });

    it("registerUser works normally", function () {
        var pizzaUni = new PizzUni();
        var result = pizzaUni.registerUser("someEmail");
        expect(result).to.deep.equal({
            email: "someEmail",
            orderHistory: []
        })

        var inMemoryResult = pizzaUni.registeredUsers[0]; 
        expect(inMemoryResult).to.deep.equal({
            email: "someEmail",
            orderHistory: []
        })
    })

    it("MakeAnOrder throws", function () { 
        var pizzaUni = new PizzUni();
        expect(() => pizzaUni.makeAnOrder("some main", "some pizza", "some drink"))
            .to.throw("You must be registered to make orders!");
    
        pizzaUni.registerUser("aser"); 
        expect(() => pizzaUni.makeAnOrder("aser", "some pizza", "some drink"))
            .to.throw("You must order at least 1 Pizza to finish the order.");
    });

    it("MakeAnOrder works", function () { 
        var pizzaUni = new PizzUni();
        pizzaUni.registerUser("aser"); 
        var result = pizzaUni.makeAnOrder("aser", "Italian Style", "Coca-Cola"); 

        var user = pizzaUni.registeredUsers.filter(x => x.email == "aser")[0];
        var orderHistory = user.orderHistory; 
        expect(orderHistory[0]).to.deep.equal({
            orderedDrink: "Coca-Cola",
            orderedPizza: "Italian Style"
        }); 

        var order = pizzaUni.orders[result];
        expect(order).to.deep.equal({
            orderedDrink: "Coca-Cola",
            orderedPizza: "Italian Style",
            email: "aser",
            status: 'pending'
        }); 
    });

    it("completeOrderWorks", function () {
        var pizzaUni = new PizzUni();
        pizzaUni.registerUser("aser"); 
        pizzaUni.registerUser("aser2"); 
        pizzaUni.makeAnOrder("aser", "Italian Style", "Coca-Cola"); 
        pizzaUni.makeAnOrder("aser2", "Italian Style", "Coca-Cola"); 

        var result = pizzaUni.completeOrder(); 
        var result2 = pizzaUni.completeOrder(); 

        expect(result.status).to.equal("completed");
        expect(result2.status).to.equal("completed"); ///MORE HERE
    }); 

    it("datails about my order works", function () { 
        var pizzaUni = new PizzUni();
        pizzaUni.registerUser("aser"); 
        pizzaUni.registerUser("aser2"); 
        pizzaUni.makeAnOrder("aser", "Italian Style", "Coca-Cola"); 
        pizzaUni.makeAnOrder("aser2", "Italian Style", "Coca-Cola"); 
        pizzaUni.completeOrder(); 
        var result1 = pizzaUni.detailsAboutMyOrder(2);
        expect(result1).to.equal(undefined);

        expect(pizzaUni.detailsAboutMyOrder(0)).to.equal("Status of your order: completed");
        expect(pizzaUni.detailsAboutMyOrder(1)).to.equal("Status of your order: pending");
    }); 

    it("does the user exists", function () { 
        var pizzaUni = new PizzUni();
        pizzaUni.registerUser("aser"); 
        pizzaUni.registerUser("aser2"); 

        var result = pizzaUni.doesTheUserExist("preditor");
        expect(result).to.equal(undefined); 

        var res2 = pizzaUni.doesTheUserExist("aser2");
        expect(res2).to.not.equal(undefined);

    });
})
