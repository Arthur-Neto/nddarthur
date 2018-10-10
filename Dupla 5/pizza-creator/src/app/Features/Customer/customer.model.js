'use strict';

function Customer() {
    var self = this;

    initialize();
    
    function initialize() {
        self.name = '';
        self.email = '';
        self.address = '';
        self.postalCode = '';
        self.contactNumber = '';
    }

    self.validate = function () {
        return self.name &&
            self.email &&
            self.address &&
            self.postalCode &&
            self.contactNumber
    }
}