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
        jquery.ui.timepicker

*/
$(document).ready(function () {
	// focus on the first visible and enabled input field or textarea
	$(":input:visible:enabled").each(function () {
		if (($(this).attr('type') == 'text') && ($(this).is('input'))) {
			$(this).focus();
			return false;
		}
		if ($(this).is('textarea')) {
			$(this).focus();
			return false;
		}
	    return false;
	});
	
    // if the inputy type is text, then on click, select all text.
	$(":input:visible:enabled").each(function () {
		if (($(this).attr('type') == 'text') && ($(this).is('input'))) {
			$(this).click(function () {
				$(this).select();
			});
		}
	});
	
    // if the field is of type date or datetime, add the jquery.ui datepicker.
	$('[id*="Date"],[type="date"]').datepicker({
		changeMonth: true,
		changeYear: true
	});
	$('[id*="datetime"],[type="datetime"]').datepicker({
		changeMonth: true,
		changeYear: true
	});

    // if the field is of type time, add the jquery timepicker timepicker
	$('[id*="Time"],[type="Time"').timepicker({
		defaultTime: '08:00',
		minutes: {
			starts: 0,
			ends: 45,
			interval: 15
		},
		showPeriod: true,
		showLeadingZero: false
	});
});
