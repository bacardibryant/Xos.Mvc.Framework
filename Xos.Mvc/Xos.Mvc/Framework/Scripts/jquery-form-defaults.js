/*
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
