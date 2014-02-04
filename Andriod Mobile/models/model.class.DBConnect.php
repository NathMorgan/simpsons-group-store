<?php

//Connection To MYSQL DataBase
//Function called as DBConnect();

//Handle Global Error reporting

error_reporting(E_ERROR);

//ini_set( "display_errors", 0);

function DBConnect(){

//Share vars with the model
global $DBName, $Host, $User, $DBPassword, $table_1, $table_2, $table_3  ;

$Host = "mysql.scm.tees.ac.uk";
$User = "YourStudentID";
$DBPassword = "yourMYSQLPassWord";
$DBName = "YourStudentID";


$table_1 = "myCars_categorys";
$table_2 = "myCars_cars";
$table_3 = "myCars_images";

}

//Restrict access to models 
/*
function loggedInCheck(){
	
  if (isset($_SESSION['User_ID']) && is_numeric($_SESSION['User_ID'])){
	
	//Continue with session
	//echo json_encode(array('loggedIn'=>true));
   
  }else{
	  
	  $message = "Sorry you do not have the rights to access this resource!";
	  echo json_encode(array('loggedIn'=>false,'html'=>$message));
	  header("location:http://www.wurf.co.uk");
  }
    //return true;
  return false;
}
*/
?>