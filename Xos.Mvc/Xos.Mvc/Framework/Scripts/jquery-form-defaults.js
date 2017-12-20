/*
    * JQuery Form Defaults
    * Using jquery and jqueryui, this module when referenced in your web page will add default attributes
    * and/or behavior to form fields.

    * Copyright 2013 Bacardi Bryant
    * Released under the MIT license
    * The MIT License (http://www.opensource.org/licenses/mit-license.php)
    *
    * Permission is hereby granted, free of charge, to any person
    * obtaining a copy of this software and associated documentation
    * files (the "Software"), to deal in the Software without
    * restriction, including without limitation the rights to use,
    * copy, modify, merge, publish, distribute, sublicense, and/or sell
    * copies of the Software, and to permit persons to whom the
    * Software is furnished to do so, subject to the following
    * conditions:
    *
    * The above copyright notice and this permission notice shall be
    * included in all copies or substantial portions of the Software.
    *
    * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
    * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
    * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
    * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
    * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
    * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
    * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
    * OTHER DEALINGS IN THE SOFTWARE.
     

    Dependencies:
        jquery
        jquery.ui

    Optional - Obtain and reference this plugin in your project if you wish to implement the timepicker code below.
        jquery.ui.timepicker (http://fgelinas.com/code/timepicker)

*/

var isValid = window.jQuery && typeof (jQuery) !== 'undefined';
var hasConsole = typeof (console) !== 'undefined' && console !== null;

if (isValid) {
    $(document).ready(function () {

        // focus on the first visible and enabled input element or textarea
        try {
            $(":input:visible:enabled").each(function () {

                if (($(this).attr('type') === 'text') && ($(this).is('input'))) {
                    $(this).focus();
                    return false;
                }

                if ($(this).is('textarea')) {
                    $(this).focus();
                    return false;
                }
                return false;
            });
        } catch (err) {
            if (hasConsole) {
                console.log("Unable to bind focus to textboxes and text areas.");
            }
            throw new ElementBindingException("Unable to bind to element. Additional information: " + err.message);
        }

        // if the input type is text, then on click, select all text.
        try {
            $(":input:visible:enabled").each(function () {
                if (($(this).attr('type') === 'text') && ($(this).is('input'))) {
                    $(this).click(function () {
                        $(this).select();
                    });
                }
            });
        } catch (err) {
            if (hasConsole) {
                console.log("Unable to bind select to text input.");
            }
            throw new ElementBindingException("Unable to bind to element.");
        }

        // if the element type is specified as date or datetime, or the element id contains the word(s) date/datetime, then try to attach the jquery.ui datepicker.
        // NOTE: THE SELECTORS ARE CASE SENSITIVE. THUS, EITHER THE ELEMENT ID AND TYPE VALUES MUST BE LOWERCASE OR MODIFY THIS SCRIPT TO THE PREFERRED CASE.
        if ($.fn.datepicker) {
            try {
                $('[id*="date"],[type="date"]').datepicker({
                    changeMonth: true,
                    changeYear: true
                });
            } catch (err) {
                if (hasConsole) {
                    console.log("Unable to bind datepicker to text input.");
                }
                throw new ElementBindingException("Unable to bind to element. Additional information: " + err.message);
            }
        } else {
            if (hasConsole) {
                console.log("jQuery datepicker is not loaded.");
            }
        }

        if ($.fn.datepicker) {
            try {
                $('[id*="datetime"],[type="datetime"]').datepicker({
                    changeMonth: true,
                    changeYear: true
                });
            } catch (err) {
                if (hasConsole) {
                    console.log("Unable to bind jquery datepicker to text input.");
                }
                throw new ElementBindingException("Unable to bind to element. Additional information: " + err.message);
            }
        } else {
            if (hasConsole) {
                console.log("jQuery datepicker is not loaded.");
            }
        }

        // if the element type is specified as time, or the element id contains the word time, try to attach the jquery.ui timepicker
        if ($.fn.timepicker) {
            try {
                $('[id*="Time"],[type="Time"]').timepicker({
                    defaultTime: '08:00',
                    minutes: {
                        starts: 0,
                        ends: 45,
                        interval: 15
                    },
                    showPeriod: true,
                    showLeadingZero: false
                });
            } catch (err) {
                if (hasConsole) {
                    console.log("Unable to bind jquery timepicker to text input.");
                }
                throw new ElementBindingException("Unable to bind to element. Additional information: " + err.message);
            }
        } else {
            if (hasConsole) {
                console.log("jQuery timepicker plugin is not loaded");
            }
        }
    });

} else {
    if (hasConsole) {
        console.log("Unable to load jQuery");
    }
}
