/*****************************************************************************************
File:        ux-tools.js
Description: Library of useful client-side scripts
Created By:  Bacardi Bryant
Created On:  10 August 2007

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
 *
------------------------------------------------------------------------------------------
                   				Modification Log
------------------------------------------------------------------------------------------
Change No.		Date		Description			  	Developer
------------------------------------------------------------------------------------------
     1.			8/10/07		File created.				Bacardi Bryant
	 2.			8/15/07		kp()						Bacardi Bryant
	 3.			8/20/07		reloc()						Bacardi Bryant
	 4.			8/20/07		highlight()					Bacardi Bryant
	 5.			8/28/07		moved to utils object	    Bacardi Bryant
	 6.			9/30/07     toggleDiv()					Bacardi Bryant
	 7.			9/30/07     setHeight()					Bacardi Bryant
	 8.			9/30/07     setFocus()					Bacardi Bryant
	 9.			9/30/07     shrink()					Bacardi Bryant
	 10.		9/30/07     trim()						Bacardi Bryant
	 11.		9/30/07     trimLeft()					Bacardi Bryant
	 12.		9/30/07     trimRight()					Bacardi Bryant
	 13.		9/30/07     maximize()					Bacardi Bryant
	 14.		5/07/08     popUpCentered()			    Bacardi Bryant
	 15.		5/07/08     popUpCenteredTop()	        Bacardi Bryant
	 16.		7/31/08		clearField()				Bacardi Bryant
     17.        12/02/11    dictionaryToHtmlTable()     Bacardi Bryant
     18.        12/02/11    trapEnterWithFunc()         Bacardi Bryant
     19.        12/02/11    postBack()		            Bacardi Bryant
     20.        12/02/11    showMessage()               Bacardi Bryant
     21.        12/02/11    displayError()              Bacardi Bryant
     22.        12/02/11    clearDisplayElement()       Bacardi Bryant
     23.        12/02/11    limitText()                 Bacardi Bryant
	 24.		05/11/13	test()						Bacardi Bryant
	 25.		05/11/13	mask()						Bacardi Bryant
	 26.		05/11/13	Impl. as anon. function.	Bacardi Bryant
	 27.		05/11/13	Renamed to ux-tools			Bacardi Bryant
	 28.		05/11/13	redirect()					Bacardi Bryant
	 29.		05/11/13	numericOnly()				Bacardi Bryant
	 30.		05/11/13	keyPress()					Bacardi Bryant
*****************************************************************************************/

var ux = new (function() {

	/************************************************************************
		Function:		kp
		Description:	DEPRECATED: Use keyPress(). Tests if the enter key was pressed.
		Returns:		Boolean based key code.
		Parameters:		e - event that triggered the function call.
	*************************************************************************/
	this.kp = function(e) {
		var code = 0;
		if (document.layers) {
		    code = e.which;
		}
		if (document.all) {
		    code = event.keyCode;
		}
		if (code == 13) {
			//submitForm();
			document.forms[0].submit();
		}
	};

	/************************************************************************
		Function:		reloc
		Description:	DEPRECATED: use redirect(). Global window.location function.
		Returns:		Void.
		Parameters:		url - url that the window should be redirected.
	*************************************************************************/
    this.reloc = function(url) {
        window.location = url;
    };

	/************************************************************************
		Function:		highlight
		Description:	Changes the background color of object that is passed.
		Returns:		Void.
		Parameters:		obj		-	the object being modified.
						task	-	set/remove Either sets are removes the highlight.
						color	-	The current color to use.
	*************************************************************************/
	this.highlight = function(obj, task, color, border) {
		var _obj = obj;
		switch (task) {
		case 'set':
			_obj.style.backgroundColor = '#' + color;
			if (border) _obj.style.border = '2px solid #AAAAAA';
		    break;
		case 'remove':
			_obj.style.backgroundColor = '#' + color;
			_obj.style.border = '2px solid #FFFFFF';
		    break;
		}
	};

	/************************************************************************
		Function:		toggleDiv
		Description:	Changes visibility of DOM object.
		Returns:		Void.
		Parameters:		divObj - ID for the div object being modified.
						h - Height value to use when making visible.
	*************************************************************************/
	this.toggleDiv = function(divObj, h) {

		var _obj = document.getElementById(divObj);
		var _curState = _obj.style.visibility;
		var _newState = (_curState == 'hidden') ? 'visible' : 'hidden';
		_obj.style.visibility = _newState;
		if (_newState == 'visible') {
			_obj.style.height = h;
		} else {
			_obj.style.height = '0px';
		}
	};

	/************************************************************************
		Function:		setHeight
		Description:	Sets the height of a DOM object.
		Returns:		Void.
		Parameters:		Obj - ID of the object being modified.
						h - Height value to apply.
	*************************************************************************/
	this.setHeight = function(Obj, h) {

		var _obj = document.getElementById(Obj);
		var _curState = _obj.style.visibility;
		var _newState = (_curState == 'hidden') ? 'visible' : 'hidden';

		if (_newState == 'visible') {
			_obj.style.height = h;
		} else {
			_obj.style.height = '0px';
		}

		_obj.height = h;
	};

	/************************************************************************
		Function:		setFocus
		Description:	gives element focus.
		Returns:		void.
		Parameters:		oElement - element to recieve focus.
	*************************************************************************/
	this.setFocus = function(oElement) {
		var obj = document.getElementById(oElement);
		obj.focus();
	};

	/************************************************************************
		Function:		shrink
		Description:	Removes whitespaces from string.
		Returns:		String without spaces.
		Parameters:		s - string to be trimmed.
	*************************************************************************/
	this.shrink = function(s) {
		var l = 0;
		var r = s.length - 1;
		while (l < s.length && s[l] == ' ') {
			l++;
		}
		while (r > l && s[r] == ' ') {
			r -= 1;
		}
		return s.substring(l, r + 1);
	};

	/************************************************************************
		Function:		trim
		Description:	removes whitespaces from the ends of a string.
		Returns:		String without spaces.
		Parameters:		s - string to be trimmed.
		Calls:			rtrim()
						ltrim()
	*************************************************************************/
	this.trim = function(s) {
		return this.trimRight(this.trimLeft(s));
	};

	/************************************************************************
		Function:		trimLeft
		Description:	removes whitespaces from left of string.
		Returns:		String without spaces.
		Parameters:		s - string to be trimmed.
	*************************************************************************/
	this.trimLeft = function(s) {
		var l = 0;
		while (l < s.length && s[l] == ' ') {
			l++;
		}
		return s.substring(l, s.length);
	};

	/************************************************************************
		Function:		trimRight
		Description:	removes whitespace from right of string.
		Returns:		String without spaces.
		Parameters:		s - string to be trimmed.
	*************************************************************************/
	this.trimRight = function(s) {
		var r = s.length - 1;
		while (r > 0 && s[r] == ' ') {
			r -= 1;
		}
		return s.substring(0, r + 1);
	};

	/************************************************************************
		Function:		maximize
		Description:	Maximizes browser window to full screen.
		Returns:		Void.
		Parameters:		None.
	*************************************************************************/
	this.maximize = function() {

		if (screen.availWidth && screen.availHeight) {
			window.moveTo(0, 0);
			window.resizeTo(screen.availWidth, screen.availHeight);
		}
	};

	/************************************************************************
		Function:		popUpCentered
		Description:	Opens a pop-up window and attempts to center in the middle of screen
		Returns:		Void.
		Parameters:		url = url of page desired.
						querystring = querystring in name=value format and comma delimited.
						w = width of window.
						h = height of window.
	*************************************************************************/
	this.popUpCentered = function(url, querystring, w, h) {

		if (url.length > 0) {
			var posX = (screen.availWidth) ? (screen.availWidth - w) / 2 : 100;
			var posY = (screen.availHeight) ? (screen.availHeight - h) / 2 : 100;
			h = (h > screen.availHeight) ? (screen.availHeight - 10) : h;
			w = (w > screen.availWidth) ? (screen.availWidth - 10) : w;
			url = url + '?' + querystring;
			window.open(url, '', 'width=' + w + ', height=' + h + ', resizable=yes, scrollbars=yes, left=' + posX + ', top=' + posY);
		}
	};

	/************************************************************************
		Function:		popUpCenteredTop
		Description:	Opens a pop-up window and attempts to center horizontally and at the top of screen.
		Returns:		Void.
		Parameters:		url = url of page desired.
						querystring = querystring in name=value format and comma delimited.
						w = width of window.
						h = height of window.
	*************************************************************************/
	this.popUpCenteredTop = function(url, querystring, w, h) {

		if (url.length > 0) {
			var posX = (screen.availWidth) ? (screen.availWidth - w) / 2 : 100;
			var posY = (screen.availHeight) ? (screen.availHeight - h) / 2 : 100;
			h = (h > screen.availHeight) ? (screen.availHeight - 10) : h;
			w = (w > screen.availWidth) ? (screen.availWidth - 10) : w;
			url = url + '?' + querystring;
			window.open(url, '', 'width=' + w + ', height=' + h + ', resizable=yes, scrollbars=yes, left=' + posX + ',top=0');
		}
	};

	/************************************************************************
		Function:		clearField
		Description:	Clears the value property of an html textbox
		Returns:		Void.
		Parameters:		id = the id of the field to be cleared.
	*************************************************************************/
	this.clearField = function(oElement) {
		if (this.trim(oElement).length > 0) {
			document.getElementById(oElement).value = '';
		}
	};

	/************************************************************************
	Function:		dictionaryToHtmlTable
	Description:	Generates an html table from a json array
	Returns:	    String form of html table element populated with data.
	Parameters:		dictionary = the json array to be converted.
	*************************************************************************/
	this.dictionaryToHtmlTable = function(dictionary) {
		var headers = [];
		var rows = [];

		headers.push("<tr>");
		for (var name in dictionary[0])
			headers.push("<td><b>" + name + "</b></td>");
		headers.push("</tr>");

		for (var row in dictionary) {
			rows.push("<tr>");
			for (var name in dictionary[row]) {
				rows.push("<td>");
				rows.push(dictionary[row][name]);
				rows.push("</td>");
			}
			rows.push("</tr>");
		}

		var top = "<table class='listTable'>";
		var bottom = "</table>";

		return top + headers.join("") + rows.join("") + bottom;
	};

	/************************************************************************
	Function:		trapEnterWithFunc
	Description:	Tests if the enter key was pressed and calls function
	Returns:		Void.
	Parameters:		e - event that triggered the function call.
					method - javascript method name.
	*************************************************************************/
	this.trapEnterWithFunc = function(e, method) {
		var code = 0;
		if (document.layers) {
		    try{
		        code = e.which;
		    } catch (ex) {}
		}
		if (document.all) {
		    try{
		        code = event.keyCode;
		    }catch(ex){}
		}
		if (code == 13) {
		    try {
		        method();
		    } catch (ex) { }

		    try {
		        event.keyCode = 0;
		    } catch (ex) { }

		    try {
		        e.keyCode = 0;
		    } catch (ex) { }
		}
	};

	/************************************************************************
	Function:		postBack
	Description:	global ASP.NET postback function.
	Returns:		Void.
	Parameters:		func - function to be executed.
					scope - form scope.
					eventArg - the event argument to catch on postback
	*************************************************************************/
	this.postBack = function(scope, eventArg) {
		__doPostBack(scope, eventArg);
	};

	/************************************************************************
	Function:		showMessage
	Description:	Displays a message.
	Returns:	    Void.
	Parameters:		displayElementId = string:the id of the element that will display message.
					messageText = string:the message text to be displayed.
					isContentPlaceHolderControl = bool:indicates if the control is within an asp.net content placeholder.
	*************************************************************************/
	this.showMessage = function(displayElementId, messageText, isContentPlaceHolderControl) {
		var elid = displayElementId;
		if (isContentPlaceHolderControl.match('true')) {
			elid = 'ctl00_ContentPlaceHolder1_' + displayElementId;
		}

		var oElement = document.getElementById(elid);
		if (oElement != null) {
			oElement.innerHTML = messageText;
		}
	};

	/************************************************************************
	Function:		displayError
	Description:	Displays a message.
	Returns:	    Void.
	Parameters:		displayElementId = string:the id of the element that will display message.
					messageText = string:the message text to be displayed.
					isContentPlaceHolderControl = bool:indicates if the control is within an asp.net content placeholder.
	*************************************************************************/
	this.displayError = function(message, displayElementId, isContentPlaceHolderControl) {
		var msg = this.trim(message);
		var elid = displayElementId;
		if (isContentPlaceHolderControl.match('true')) {
			elid = 'ctl00_ContentPlaceHolder1_' + displayElementId;
		}

		var oElement = document.getElementById(elid);
		if (oElement != null) {
			if (msg.length == 0) {
				oElement.innerHTML = 'No Error Details Found.';
			} else {
				oElement.innerHTML = msg;
			}
		}
	};

	/************************************************************************
	Function:		clearDisplayElement
	Description:	Clears the text/html within an element.
	Returns:	    Void.
	Parameters:		displayElementId = string:the id of the element that will display message.
					isContentPlaceHolderControl = bool:indicates if the control is within an asp.net content placeholder.
	*************************************************************************/
	this.clearDisplayElement = function(displayElementId, isContentPlaceHolderControl) {
		var elid = displayElementId;
		if (isContentPlaceHolderControl.match('true')) {
			elid = 'ctl00_ContentPlaceHolder1_' + displayElementId;
		}

		var oElement = document.getElementById(elid);
		if (oElement != null) {
			var sData = oElement.innerHTML;

			if (sData.length > 0) {
				oElement.innerHTML = "";
			}
		}
	};

	/************************************************************************
	Function:		limitText
	Description:	Only allows text input to the specified number of characters.
	Returns:	    Void.
	Parameters:		field = string:the id of the field that will capture input.
					display = string:the id of the field that will display the current number of characters.
					limit = int: the number of characters allowed. Must be greater than zero, the default is 250.
	*************************************************************************/
	this.limitText = function(field, display, limit) {
		/// <signature>
		///   <summary>Only allows text input to the specified number of characters.</summary>
		///   <param name="field" type="String">The id of the field that will capture input.</param>
		///   <param name="display" type="String">The id of the field that will display the current number of characters entered.</param>
		///   <param name="limit" type="Number">The number of characters allowed. Must be greater than zero, the default is 250.</param>
		/// </signature>
		var _obj1 = document.getElementById(field);
		var _obj2 = document.getElementById(display);
		var _intLim = (limit <= 0) ? 250 : limit;

		var _msg = _obj1.value;
		if (_obj1.value.length > _intLim) {
			// if too long...trim it!
			_obj1.value = _obj1.value.substring(0, _intLim);
			//alert("Maximum Characters Reached.");
		} else {
			_obj2.innerHTML = _intLim - _obj1.value.length;
		}
	};

	/************************************************************************
	Function:		test
	Description:	Simple test mechanism which test object access.
					Alerts back the input parameter.
	Returns:	    Void.
	Parameters:		input = string:the input to be alerted back.
	*************************************************************************/
	this.test = function(input) {
		alert(input);
	};

	/************************************************************************
	Function:		mask
	Description:	Adds input mask to an html text input.
	Returns:	    Void.
	Parameters:		element = string:the id of the element that will capture input.
					type = string:the type of input mask to be applied.
	*************************************************************************/
	this.mask = function(element, type) {

	    try {
	        switch (type) {
	        case 'money':
	            $("#" + element).mask('000,000,000,000,000', { reverse: true });
	            break;
	        }
	    } catch(exception) {
	        return "ERROR: Method not supported, ensure that jquery and the jquery mask plugin are available.";
	    }
	    return "";
	};

	/************************************************************************
		Function:		redirect
		Description:	Global window.location function.
		Returns:		Void.
		Parameters:		url - url that the window should be redirected.
	*************************************************************************/
	this.redirect = function(url) {
		window.location = url;
	};

	/************************************************************************
		Function:		numericOnly
		Description:	Tests if the key pressed was a number/character,
						or a control key. Allows numeric characters.
		Returns:		Boolean based results from regular expression test.
		Parameters:		e - event that triggered the function call.
	*************************************************************************/
	this.numericOnly = function(e) {
		e = (e) ? e : window.event;
		var charCode = (e.which) ? e.which : e.keyCode;
	    return (charCode <= 31 || (charCode >= 48 && charCode <= 57));
	};

	/************************************************************************
		Function:		keyPress
		Description:	Tests if the enter key was pressed.
		Returns:		Boolean based key code.
		Parameters:		e - event that triggered the function call.
	*************************************************************************/
	this.keyPress = function(e) {
		var code = 0;
		if (document.layers) {
		    code = e.which;
		}
		if (document.all) {
		    code = event.keyCode;
		}
		if (code == 13) {
			//submitForm();
			document.forms[0].submit();
		}
	};
});