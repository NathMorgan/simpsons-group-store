//Controller

//Web Service User Events
$('button#getCategoryCars').click(function(){getCategoryCars();});
$('button#getAllCars').click(function(){getAllCars();});
$('button#getCategorys').click(function(){getCategorys();});





//get a simple list of categorys 
function getCategorys(){
	
	//Remove any existing data
	$('table').empty();
	
	$.get("https://u0018370.scm.tees.ac.uk/RIA_3/models/model.class.getMyCars.php?action=getCategorys",

	function(data) {
	
		//table row
		var tr;
		
        for (var i = 0; i < data.carData.length; i++) {
            tr = $('<tr/>');
            tr.append("<td>" + data.carData[i] + "</td>");
            $('table').append(tr);
        }

	//Refresh JQM
$( "div#car-page[data-role=page]" ).trigger("create");

		}, "json");
	

	return false;
};//Close Function




//get a simple list of actors for the association system
function getCategoryCars(){
	
	//Remove any exosting data
	$('table').empty();
	
	
	$.get("https://u0018370.scm.tees.ac.uk/RIA_3/models/model.class.getMyCars.php?action=getCategoryCars",

	function(data) {
	
		
		var k = 0;
		var tr;
		
        
		for (var i = 0; i < data.carData.length; i++) {
           
		    if(k==1){
			tr = $('<tr/>');
			tr.append("<td>"+ data.carData[i] + "</td>");
            $('table').append(tr);
			k=0;
			
			}else{
			tr = $('<tr/>');
			tr.append("<td class='tr_bg'>"+ data.carData[i] + "</td>");
            $('table').append(tr);
			k=1;	
				
			}
			
        }



	//Refresh JQM
$( "div#car-page[data-role=page]" ).trigger("create");

		}, "json");
	
	
	


	return false;
};//Close Function











//get a simple list of actors for the association system
function getAllCars(){
	
	//Remove any exosting data
	$('table').empty();
	
	
	$.get("https://u0018370.scm.tees.ac.uk/RIA_3/models/model.class.getMyCars.php?action=getAllCars",

	function(data) {
	
		

		var tr;
		
        for (var i = 0; i < data.carData.length; i++) {
            tr = $('<tr/>');
            tr.append("<td>" + data.carData[i] + "</td>");
            $('table').append(tr);
        }



	//Refresh JQM
$( "div#car-page[data-role=page]" ).trigger("create");

		}, "json");
	
	
	


	return false;
};//Close Function