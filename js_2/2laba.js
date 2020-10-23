
function check(){
	var distance = document.getElementById('distance').value,
    priceb = document.getElementById('priceb').value,
    consump = document.getElementById('consump').value;
    if((distance.length<1) && (priceb.length<1) && (consump.length<1)){
    	alert("В поле ничего нет");
	document.getElementById('button').disabled= true;
	
}
    else{
	document.getElementById('button').disabled= false;
}
}

function calculate(){
    var distance = document.getElementById('distance').value,
    priceb = document.getElementById('priceb').value,
    consump = document.getElementById('consump').value;

	if(distance===""){
		alert("В поле РАССТОЯНИЕ ничего нет");
		return false;
	}
	if(priceb===""){
		alert("В поле ЦЕНА БЕНЗИНА ничего нет");
		return false;
	}
	if(consump===""){
		alert("В поле ПОТРЕБЛЕНИЕ ничего нет");
		return false;
	}
	if(isNaN(distance)){
		alert("В поле РАССТОЯНИЕ не число");
		return false;
	}
	if(isNaN(priceb)){
		alert("В поле ЦЕНА БЕНЗИНА не число");
		return false;
	}
	if(isNaN(consump)){
		alert("В поле ПОТРЕБЛЕНИЕ не число");
		return false;
	}
	var total=Math.round((distance/100)*consump*priceb);
	document.getElementById('value').value=total;
}




//Для второй лабы











































