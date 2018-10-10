'use strict';

var PizzaSummary = {};

(function PizzaSummaryControl() {
    var templateDescription = document.querySelector('#itemSummaryDescriptionTemplate').innerHTML;
    var templateValue = document.querySelector('#itemSummaryValueTemplate').innerHTML;

    PizzaSummary.addItem = function(itemSummaryConfig) {
        var valueElement = generateElement('value', itemSummaryConfig);
        var descriptionElement = generateElement('description', itemSummaryConfig);
        if (itemSummaryConfig.sibling) {
            summary.insertBefore(descriptionElement, itemSummaryConfig.sibling);
            summary.insertBefore(valueElement, itemSummaryConfig.sibling);
        } else {
            summary.appendChild(descriptionElement);
            summary.appendChild(valueElement);
        }
    }
 
    PizzaSummary.removeItem = function (key) {
        var valueElement = document.querySelector("#value" + key);
        var descriptionElement = document.querySelector("#description" + key);
        if (descriptionElement)
            summary.removeChild(descriptionElement);
        if (valueElement)
            summary.removeChild(valueElement);
    }

    function generateElement(prefixKey, itemSummaryConfig) {
        var text = prefixKey === 'value' ? itemSummaryConfig.value : itemSummaryConfig.description;
        var template = prefixKey === 'value' ? templateValue : templateDescription;
        var element = htmlToElement(template);
        element.id = prefixKey + itemSummaryConfig.key;
        element.firstElementChild.textContent = text;
        if (itemSummaryConfig.class) {
            element.classList.add(itemSummaryConfig.class);
        }
        return element;
    }
})();