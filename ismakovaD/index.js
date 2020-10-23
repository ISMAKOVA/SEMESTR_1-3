
    
//var date = Date(document.getElementById("date").value);
document.getElementById("fio").addEventListener("blur", function(){
    var fio = document.getElementById("fio").value;
    re = /[A-ZА-ЯЁa-zа-яё]/gs;
    if(fio.match(re)==null){
        alert("Проверьте введнные данные");
    }
    else{

    }
});

document.getElementById("date").addEventListener("change", function(){
    var date =document.getElementById("date").value;
    var today = new Date();
    var birthday = new Date(date);
    if(today.getTime()>birthday.getTime()){
    result = Math.ceil(today.getFullYear()-birthday.getFullYear());
    document.getElementById("age").value=result;
    }
    else{
        alert("Проверьте правильность ввода даты дня рождения");
    }
});
var radio = document.getElementsByName("who");
for(var i=0; i<radio.length;i++){
    radio[i].addEventListener("change", function(){
    var who;
        if(radio[0].checked){
            who="Студент";
            document.getElementById("end").disabled = true;
        }
        else{
            who="Выпускник";
            document.getElementById("end").disabled = false;
        }
});
}

document.getElementById("education").addEventListener("change",function(){
    var univer =  document.getElementById("education").options[document.getElementById("education").selectedIndex].value;
    var txtAr = document.getElementById("txt");
    document.getElementById("btn").disabled=true;
    if(univer=="ТюмГУ"){
        txtAr.value="Информационные системы и технологии, Прикладная информатика,\nИнформационная безопасность, Математика и информатика."
    }
    else if(univer=="ТюмИУ"){
        txtAr.value="Информационные системы и технологии, \nАвтоматизированные системы управления."
    }
});


document.getElementById("salary").addEventListener("change", function(){
    var salary = document.getElementById("salary").value;
    re = /\d/gs;
    if(salary.match(re)==null || salary.length>5){
        alert("Проверьте введнные данные");
    }
    else{
    }
});

document.getElementById("starus").addEventListener("change",function(){
    var starus =  document.getElementById("starus").options[document.getElementById("starus").selectedIndex].value;
});

// document.getElementById("btn").addEventListener("click", function(){
//     let new_div = document.createElement('div');
    // let myDiv = document.getElementById("form");
    // let parentDiv = myDiv.parentNode;
    // new_div.className="new_div";
    // new_div.innerHTML ="<h3>Резюме</h3> ";
    // new_div.innerHTML += `<p>${fio}, ${result} года</p>`;
    // new_div.innerHTML += `<p>Выпускник ${univer}</p>`;

// });
//не работает
function YO(){
   var div = document.getElementById("div");
    var starus =  document.getElementById("starus").options[document.getElementById("starus").selectedIndex].value;
   div.innerHTML="NOTHING";
}





