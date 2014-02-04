<?php
session_start();
/**
 * model.class.getMyCars.php
 *
 * The purpose of the file is to provide a number web services. This file uses JSON to encode data back to the controller in an object named 'carData'. 
 *
 * PHP version 5.3
 *
 
 * @author  Original Author <you@live.tees.ac.uk>
 
 * @version SVN:1.0
 
 */



include "model.class.DBConnect.php";

DBConnect();
//loggedInCheck();
$Link = mysqli_connect($Host, $User, $DBPassword, $DBName);


$action = $_GET['action'];

if($action=="getCategorys"){

getCategorys($Host, $User, $DBPassword, $DBName, $table_1, $table_2, $table_3);	

}elseif($action=="getCategoryCars"){
	
getCategoryCars($Host, $User, $DBPassword, $DBName, $table_1, $table_2, $table_3);

}elseif($action=="getAllCars"){
	
getAllCars($Host, $User, $DBPassword, $DBName, $table_1, $table_2, $table_3);

}




//1. Return all Categorys
function getCategorys($Host, $User, $DBPassword, $DBName, $table_1, $table_2, $table_3 ){

$Link = mysqli_connect($Host, $User, $DBPassword, $DBName);

 
$Query = "SELECT * FROM $table_1 ORDER BY category_id";
		
	if($Result = mysqli_query($Link, $Query)){
		
	//For each category	
	$array_catagory = array();	
	

	while($row = mysqli_fetch_array($Result)){
		
	//Get the data for the category
	$category_id = $row['category_id'];
	$category_name = $row['name'];
		
	//Create an array object 
	$array_catagory[] = $category_name;
		
					
		
	}//close while loop
		
			//Send data to the Controller
			
			echo json_encode(array('action'=>'success','carData'=>$array_catagory, 'console.log'=>$Query));
			exit();
		
		}else{
		
		//Send Error for the first query
		echo json_encode(array('action'=>'mysql error', 'console.log'=>$Query));
		exit();
		
		}//close condition
		
}//Close getCategorys Function











//2. Return all cars in each category - has catagory detail//
function getCategoryCars($Host, $User, $DBPassword, $DBName, $table_1, $table_2, $table_3 ){

$Link = mysqli_connect($Host, $User, $DBPassword, $DBName);

 
$Query = "SELECT * FROM $table_1 ORDER BY category_id";
		
	if($Result = mysqli_query($Link, $Query)){
		
	//For each category	
	$array_catagory = array();	
	$array_cars = array();

	while($row = mysqli_fetch_array($Result)){
		
	//Get the data for the category
	$category_id = $row['category_id'];
	$category_name = $row['name'];
		
	//Create an array object 
	$array_catagory[] = $category_name;
		
					
					
								$Query2 = "SELECT * FROM $table_2 WHERE category_id = '$category_id' ORDER BY cars_id ";
								
								if($Result2 = mysqli_query($Link, $Query2)){
										
								while($row2 = mysqli_fetch_array($Result2)){
							
								//Build a list of cars for this category
								$cars_id = $row2['cars_id'];
								$cars_name = $row2['name'];
										
								//Return an array of cars with its category
								$array_cars[] = $category_name.': '.$cars_name;
								
								}//close while loop
		
		
								}else{
		
								//Send Error for the second query
								echo json_encode(array('action'=>'mysql error', 'console.log'=>$Query2));
								exit();
		
								}//close condition
		
		
	}//close while loop
		
			//Send data to the Controller
			
			echo json_encode(array('action'=>'success','carData'=>$array_cars, 'console.log'=>$Query2));
			exit();
		
		}else{
		
		//Send Error for the first query
		echo json_encode(array('action'=>'mysql error', 'console.log'=>$Query));
		exit();
		
		}//close condition
		
}//Close getCategoryCars Function		
		
		
		
		
		
		
		
		
		
		
		
//3. Return all cars 
function getAllCars($Host, $User, $DBPassword, $DBName, $table_1, $table_2, $table_3 ){

$Link = mysqli_connect($Host, $User, $DBPassword, $DBName);

 
$Query = "SELECT * FROM $table_2 ORDER BY cars_id";
		
	if($Result = mysqli_query($Link, $Query)){
		
	//For each car	
	$array_cars = array();	
	

	while($row = mysqli_fetch_array($Result)){
		
	//Get the data for the category
	$cars_id = $row['cars_id'];
	$cars_name = $row['name'];
		
	//Create an array object 
	//$array_cars[] = $cars_id.'=>'.$cars_name;
	$array_cars[] = $cars_name;
		
					
		
	}//close while loop
		
			//Send data to the Controller
			
			echo json_encode(array('action'=>'success','carData'=>$array_cars, 'console.log'=>$Query));
			exit();
		
		}else{
		
		//Send Error for the first query
		echo json_encode(array('action'=>'mysql error', 'console.log'=>$Query));
		exit();
		
		}//close condition
		
}//Close getAllCars Function	
		
		
		
		
		
/*
$data = array();
$i=1;
while($row = mysqli_fetch_array($Result)){
  		
$key = $row['WebAppActor_ID'] ;

$info = $row['actorName'];

//<input type="hidden" name="recordId['.$key.']" value="'.$key.'" />
$data[] = '<input type="hidden" name="recordId['.$key.']" value="'.$key.'" /><label><input type="checkbox" id="WebAppActor_ID'.$key.'" name="actor'.$key.'" value="'.$key.'" />'.$info.'</label>';

$i++;



}



			$success = "success";
			//Send Back to the Controller
			echo json_encode(array('action2'=>$success,'actors'=>$data));
			exit();




}//Close function

*/


/*
function geteditActors($Host, $User, $Password, $DBName, $table_6){
$Project_ID  = $_SESSION['Project_ID'] ;
//$Project_ID = "4";


$Link = mysqli_connect($Host, $User, $Password, $DBName);


//See what details we have 
		$Query = "SELECT * FROM $table_6 WHERE Project_ID = '".$Project_ID."' ORDER BY WebAppActor_ID";
		//print $Query;
		$Result = mysqli_query($Link, $Query);
		


//Build MODULE Dropdown Menu Here

$data = array();

$i=1;
			while($row = mysqli_fetch_array($Result)){
					
			$key = $row['WebAppActor_ID'] ;
			
			$info = $row['actorName'];
			
			$name = "Actor".$key;
			
			$data[] = '<span class="grid_8"><input type="hidden" name="recordId['.$key.']" value="'.$key.'" /><label><input type="text" name="'.$name.'" value="'.$info.'" /></label></span><span class="grid_2"><label><input data-icon="search" type="checkbox" id="'.$key.'" name="deleteObj['.$key.']" value="true" data-mini="true" />Delete?</label></span>';
			
			
			
			
			$i++;
			
			
			
			}




			$success = "success";
			//Send Back to the Controller
			echo json_encode(array('action2'=>$success,'editActors'=>$data, 'objectivesDelete'=>$deleteBtns));
			exit();



}//Close function 
 */


?>