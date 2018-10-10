'use strict';

var CustomerForm = {};

(function CustomerFormControl() {
    var self = this;

    var customer = null;
    var inputIds = [
        'name',
        'email',
        'confirmEmail',
        'address',
        'postalCode',
        'contactNumber',
    ];
    var confirmEmailInput = document.querySelector('#confirmEmail');
    var emailInput = document.querySelector('#email');
    var onChangesCB = null;

    CustomerForm.initialize = function (customerBase, onChange) {
        customer = customerBase;
        onChangesCB = onChange;
        setInputEvents();
    }

    CustomerForm.validate = function (_customer_) {
        return customer.validate() && confirmEmailInput.value === customer.email;
    }

    // private methods
    function setInputEvents() {
        for (var index in inputIds) {
            (function (property) {
                var input = document.querySelector('#' + property);
                input.addEventListener('keyup', function (event) {
                    customer[property] = input.value;
                    validateOnEvent(event, '#errorRequired', !input.value);
                });
                input.addEventListener('blur', function (event) {
                    validateOnEvent(event, '#errorRequired', !input.value);
                });
            })(inputIds[index]);
        }
        emailInput.addEventListener('keyup', validateMatchEmails);
        confirmEmailInput.addEventListener('keyup', validateMatchEmails);
    }

    function validateMatchEmails(event) {
        var showError = confirmEmailInput.value && (customer.email != confirmEmailInput.value);
        validateOnEvent(event, '#emailMatch', showError, confirmEmailInput.parentElement);
    }

    function validateOnEvent(event, selector, showError, container) {
        var scope = container || event.srcElement.parentElement;
        var classList = scope.querySelector(selector).classList;
        if (showError) {
            classList.add('form__label__error--visible');
        } else {
            classList.remove('form__label__error--visible');
        }
        onChangesCB();
    }
})();