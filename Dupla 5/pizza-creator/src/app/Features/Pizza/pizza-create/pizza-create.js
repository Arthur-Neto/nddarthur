(function PizzaCreate() {
    'use strict';

    var self = this;
    var summary = document.querySelector('#summary');
    var button = document.querySelector('#btnPlaceOrder');
    var pizza = new Pizza();
    var customer = new Customer();

    initialize();

    function initialize() {
        pizza.customer = customer;
        CustomerForm.initialize(customer, validateForm);
        button.addEventListener('click', onSubmit);
        validateForm();
        setPizzaSize();
        setPizzaTotal();
        setToppingsCheckboxEvents();
        setSizeRadioEvents();
    }

    function validateForm() {
        var state = CustomerForm.validate();
        if (state) {
            button.classList.remove('form__button--disabled');
        } else {
            button.classList.add('form__button--disabled');
        }
        button.disabled = !state;
    }

    /* Events */

    function onSubmit() {
        alert('Pizza !!');
        console.log(pizza);
    }

    function setSizeRadioEvents() {
        for (var type in pizzaTypes) {
            var radio = document.querySelector('#' + type);
            radio.addEventListener('click', function (event) {
                pizza.type = pizzaTypes[event.srcElement.value];
                setPizzaSize();
                setPizzaTotal();
                setPizzaToppings();
            });
        }
    }

    function setToppingsCheckboxEvents() {
        for (var topping in pizzaToppings) {
            (function (property) {
                var checkbox = document.querySelector('#' + property);
                checkbox.addEventListener('click', function () {
                    if (checkbox.checked) {
                        pizza.toppings.push(property);
                        setPizzaToppings();
                    } else {
                        var index = pizza.toppings.indexOf(property);
                        pizza.toppings.splice(index, 1);
                        PizzaSummary.removeItem(property);
                    }
                    setPizzaTotal();
                });
            })(topping);
        }
    }

    /* Update Summary */
    function setPizzaToppings() {
        var unitPrice = "$" + pizza.getToppingsUnitPrice();
        for (var index in pizza.toppings) {
            var topping = pizza.toppings[index];
            var itemSummaryConfig = {
                description: topping,
                value: unitPrice,
                key: topping,
                class: 'form__group--left-space',
                sibling: summary.lastElementChild.previousElementSibling
            }
            PizzaSummary.removeItem(topping);
            PizzaSummary.addItem(itemSummaryConfig);
        }
    }

    function setPizzaSize() {
        PizzaSummary.removeItem('size');
        var description = pizza.type.toUpperCase() + ' Pizza';
        var sizeValue = "$" + pizzaPrices[pizza.type];
        var itemSummaryConfig = {
            description: description,
            value: sizeValue,
            key: 'size',
            sibling: summary.firstElementChild
        }
        PizzaSummary.addItem(itemSummaryConfig);
    }

    function setPizzaTotal() {
        PizzaSummary.removeItem('total');
        var description = 'TOTAL';
        var total = "$" + pizza.calculateTotal();
        var itemSummaryConfig = {
            description: description,
            value: total,
            key: 'total',
            class: 'form__group--text-big',
        }
        PizzaSummary.addItem(itemSummaryConfig);
    }
})()