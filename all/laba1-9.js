function translation(){
	var txt = "";
	var lang = document.getElementsByName('language');
	var animal = nine.animal.options[nine.animal.selectedIndex].value;
	var cat = {
		english:"Cat",
		deutsch:"Katze",
		french:"Chat"
	}
	var dog={
		english:"Dog",
		deutsch:"Hund",
		french:"Chien"
	}
if(animal=="Кошка"){
		for(var i=0; i<lang.length;i++){
		if(lang[i].checked && lang[i].type=="radio"){
			txt=txt+lang[i].value;
		}
		switch(txt){
			case "english":
			document.getElementById("translation").innerHTML  = "<p>Перевод:</p>"+ cat.english;
			break;
			case "deutsch":
			document.getElementById("translation").innerHTML  = "<p>Перевод:</p>"+cat.deutsch;
			break;
			case "french":
			document.getElementById("translation").innerHTML  = "<p>Перевод:</p>"+cat.french;
			break;
			default:
			document.getElementById("translation").innerHTML  = "<p>Перевод:</p>"+"НИЧЕГО НЕТ";
		}
	}

}
else{
for(var i=0; i<lang.length;i++){
		if(lang[i].checked && lang[i].type=="radio"){
			txt=txt+lang[i].value;
		}
		switch(txt){
			case "english":
			document.getElementById("translation").innerHTML  = "<p>Перевод:</p>"+ dog.english;
			break;
			case "deutsch":
			document.getElementById("translation").innerHTML  = "<p>Перевод:</p>"+dog.deutsch;
			break;
			case "french":
			document.getElementById("translation").innerHTML  = "<p>Перевод:</p>"+dog.french;
			break;
			default:
			document.getElementById("translation").innerHTML  = "<p>Перевод:</p>"+"НИЧЕГО НЕТ";
                    } 
                 }
    }
}






/*
function background(){
	var n=" ";
	var b =eight.bkc.options[eight.bkc.selectedIndex].value;
	var picture = document.getElementsByName('pic');
	for(var i=0; i<picture.length;i++){
		if(picture[i].checked)n=n+picture[i].value;
	}
	if(b=="body"){
		switch(n){
			case "pic1":
			document.body.style.backgroundImage = url'("Снимок экрана 2019-02-17 в 9.57.38.png")';
			break;
			case "pic2":
			document.body.style.background= src("Снимок экрана 2019-02-17 в 10.08.20.png");
			break;
			case "pic3":
			document.body.style.background= src("Снимок экрана 2019-02-17 в 10.08.05.png");
			break;
			default:
			document.getElementById("background").innerHTML  ="НИЧЕГО НЕТ";
		}
	}
}
*/






































