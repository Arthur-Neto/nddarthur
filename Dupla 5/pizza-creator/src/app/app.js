/* 
 * 
 * Global JS
 * 
 */
'use strict';
function htmlToElement(html) {
    var template = document.createElement('div');
    html = html.trim();
    template.innerHTML = html;
    return template.firstChild;
}