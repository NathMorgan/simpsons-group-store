/** MVC jQuery Mobile Page Control - developed by Dr Andrew Bingham 2013
 * Called From index.html (Single Page Application) or SPA 
 * Custom function to enable function calls and changePage jquery mobile default linking
 * This Script replaces the default AJAX naviagtion of jQuery Mobile 
 * Usage - changeAppPage('recoverPassword') within an onlick event
 * 'Views' inserted in to the DOM via AJAX 'Controllers' - 'Models' Control Data Events and sent to the app using JSON. aka MVC.
 */
 
 
//Important!!! This function disables the routing and navigation capabilities of the standard JQM #  
//data-ajax="false"



function changeAppPage(functionCall){

	
		console.log("called changeAppPage");
		//Navigate to new page and build pages dynamically from the view
		
		if(functionCall!="null"){
		
		//Start Switch Statement - this controls how the next page displays
		switch(functionCall)
		{
		
		//PageView_ReflowTables
		case 'PageView_ReflowTables':
		
		console.log("called CASE PageView_ReflowTables");
		//NProgress.start();
		//Show Page Loading
		$.mobile.loadingMessageTextVisible = true;
		$.mobile.showPageLoadingMsg('a','Page Loading - Please Wait');
		
		$.get('/views/PageView_ReflowTables.html',
		
		function(data) {
							
		console.log("called VIEW PageView_ReflowTables");
		
		var myPage = data;
		
		//Handle Page Creation
		if($('div#PageView_ReflowTables[data-role=page]').length == 0) {		
		
		//inject HTML view into the app
		$('<div data-role="page" id="PageView_ReflowTables" data-dom-cache="false">').html(myPage).appendTo('body');		
		
		
		console.log("DOM INSERT PageView_ReflowTables");
		//get();		
		
		//Close Page Loading
		$.mobile.hidePageLoadingMsg();	
		
		//Move to new page	
		$.mobile.changePage('#PageView_ReflowTables');		
		//If it not exists do NOT fire the changePage function
		//Programatically remove elements from DOM and refire the JSON get data function			
		}else{
		//Page View Already In The DOM
		console.log("VIEW ALREADY In DOM");
		//$('div#popupDialog').popup("close");
		
		//Move to new page	
		$.mobile.changePage('#PageView_ReflowTables');
		//Empty any existing data
		//$('textarea#StatementOfPurpose').empty();
		
		//Close Page Loading
		$.mobile.hidePageLoadingMsg();	
		//get new updated data
		//get();
		$("body").trigger("create");
		}//End Page Creation
		
								
		});
		
		//NProgress.done(); 
		break;
		
		
		//Car Page
		case 'car-page':
		
		console.log("called CASE car-page");
		//NProgress.start();
		//Show Page Loading
		$.mobile.loadingMessageTextVisible = true;
		$.mobile.showPageLoadingMsg('a','Page Loading - Please Wait');
		
		$.get('views/PageView_Cars.html',
		
		function(data) {
							
		console.log("called VIEW car-page");
		
		var myPage = data;
		
		//Handle Page Creation
		if($('div#car-page[data-role=page]').length == 0) {		
		
		//inject HTML view into the app
		$('<div data-role="page" id="car-page" data-dom-cache="false" data-url="car-page">').html(myPage).appendTo('body');		
		
		
		console.log("DOM INSERT car-page");
		
		
		//Close Page Loading
		$.mobile.hidePageLoadingMsg();	
		
		//Move to new page	
		$.mobile.changePage('#car-page');		
		//If it not exists do NOT fire the changePage function
		//Programatically remove elements from DOM and refire the JSON get data function			
		}else{
		//Page View Already In The DOM
		console.log("VIEW ALREADY In DOM");
		//$('div#popupDialog').popup("close");
		
		//Move to new page	
		$.mobile.changePage('#car-page');
		//Empty any existing data
		//$('textarea#StatementOfPurpose').empty();
		
		//Close Page Loading
		$.mobile.hidePageLoadingMsg();	
		//get new updated data
		//get();
		$("body").trigger("create");
		}//End Page Creation
		
								
		});
		
		//NProgress.done(); 
		break;
		
		
		
		
		
		
		//Your Next case here
		
		
		}//Close Switch
		
		
		
		}else{
		
		alert("error calling changeAppPage function");
			
		}
		
		
	
}//End Page Control