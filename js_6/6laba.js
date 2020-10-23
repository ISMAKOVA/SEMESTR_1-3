
 var number;

function undis(){

	number = document.getElementById('number').value;
	
if(number.length>0 ){
	document.getElementById('newArr').disabled = false;
}
else{
	alert("Вы ничего не ввели");
	document.getElementById('newArr').disabled = true;
}
return number;
}

function enter(){
	
	var num100 = parseInt(number);
	var cr = createNewArr();
if( cr.length!==num100){
	document.getElementById('ish').innerHTML="Количество элементов не совпадает";
}
else{
document.getElementById('ish').innerHTML="";
}
}

function createNewArr(){
	document.getElementById('sourceArr').value=getRandomNum(number);
	/* var newArr = [];
	 var string = document.getElementById('sourceArr').value;	
	 newArr.length= number;
	 var newArr = (new Function("return [" + string+ "];")());
	 return newArr;*/
}
var a =[];
function change(){
	var newArr = [];
	var string = document.getElementById('sourceArr').value;	
	newArr.length= number;
	var newArr = (new Function("return [" + string+ "];")());
	var sum=0,
	neg=0,
	pos=0;
	
	for(var i=0; i<number; i++){
		sum +=newArr[i]; 
		if(newArr[i]<0){
			neg++;
		}
		if(newArr[i]>0){
			pos++;
		}
	}
	var min =Math.min.apply(null, newArr);
	var max =Math.max.apply(null, newArr);

	a.push(min,max,sum,neg,pos);

	var checkbox = document.forms["array"].elements["checkbox"];
	for(var i= 0; i<checkbox.length; i++){
		if(checkbox[i].checked){
		document.getElementById(checkbox[i].value+'t').value=a[i];
		}
	}

}


function pupa(){

	var newArr = [];
	var string = document.getElementById('sourceArr').value;	
	newArr.length= number;
	var newArr = (new Function("return [" + string+ "];")());

	var sortir = document.getElementsByName('sort');
	for(var i=0; i<sortir.length; i++){
		if(sortir[i].checked && sortir[i].type=="radio"){

			switch(sortir[i].value){
				case 'a1':
				newArr.sort(function(a, b){return a - b});
				document.getElementById('getArr').value=newArr;
				break;
				case 'a2':
				newArr.sort(sDecrease);
				document.getElementById('getArr').value=newArr;	
				break;	
				case 'a3':
				document.getElementById('getArr').value=newArr;		
				break;
				default:
				document.getElementById('getArr').value="ничего не выбрано";	
			} 


		}
	}

}
function sDecrease(i, ii) { // сортировка по убыванию
    if (i > ii)
        return -1;
    else if (i < ii)
        return 1;
    else
        return 0;
}

function getRandomNum(n){
    var Arr=[];
	for(var i=0; i<n;i++){
        p=Math.round(Math.random()*(200)-100);
        Arr.push(p);
    }
return Arr;
}
function getRandomArbitary(min, max){
  return Math.random() * (max - min) + min;
}
















	