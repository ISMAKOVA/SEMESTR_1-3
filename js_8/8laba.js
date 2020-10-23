var one = false,
two = false,
three=false,
four = false,
five=false,
six=false,
seven = false;


var str;
var strL;
var strP1;
var strP2;
var strD;
var strN;
var numberINN;
var s;

function checkSurname(){
    str= document.getElementById('surname').value;
    var rgxS=/[A-ZА-ЯЁ]{1}[a-zа-яё]{2,20}/gs;
    var str_rgxS = str.match(rgxS);
   if(str_rgxS==null)  {
       document.getElementById('er1').innerHTML="Неправильно введены данные";
       document.getElementById('send').style.display="none";
       one=false;
    }
   else{
       document.getElementById('er1').innerHTML="";
       document.getElementById('one').innerHTML=str;
       one=true;
    }
}
function checkLogin(){
    strL = document.getElementById('login').value;
    var rgxL = /\w{3,10}/gis; 
    var str_rgxL=strL.match(rgxL);
    if(str_rgxL==null) {
        document.getElementById('er2').innerHTML="Неправильно введены данные"; 
        document.getElementById('send').style.display="none";
        document.getElementById('button').disabled= true;
        two=false;
    }
   else{
       document.getElementById('er2').innerHTML="";
       document.getElementById('two').innerHTML=strL;
       two=true;
    }

}
function getPasW1(){
    strP1 = document.getElementById('password1').value;
    var strongRegex = new RegExp("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.{8,})");
    if(strongRegex.test(strP1)){
        document.getElementById('er3').innerHTML="";
        document.getElementById('three').innerHTML=strP1;
        three =true;
    }
    else{
        document.getElementById('er3').innerHTML="Неправильно введены данные";
        document.getElementById('send').style.display="none";
        document.getElementById('button').disabled= true;
        three=false;
    }

}
function getPasW2(){
    strP2=document.getElementById('password2').value;
    if(strP1==strP2){
    document.getElementById('er4').innerHTML="";
    four=true;
}
    else{
        document.getElementById('er4').innerHTML="Неправильно введены данные";
        document.getElementById('send').style.display="none";
        document.getElementById('button').disabled= true;
        four=false;
    }
}
function checkDate(){
    strD=document.getElementById('date').value;
    var rgxD = /(\d\d|\d)[-/.](\d\d|\d)[-/.](\d\d\d\d|\d\d)/g;
    var date = strD.match(rgxD);
    if(date==null) {
        document.getElementById('er5').innerHTML="Неправильно введены данные";
        document.getElementById('send').style.display="none";
        document.getElementById('button').disabled= true;
        five=false;
    }
   else{
       document.getElementById('er5').innerHTML="";
       document.getElementById('four').innerHTML=date[0];
        five=true;
    }

}
function checkNum(){
    strN=document.getElementById('number').value;
    var rgxNum=/^(\(\d{3}\)?[\- ]?)?[\d\- ]{6,10}$/;
    var number = strN.match(rgxNum);
    if(number==null){
        document.getElementById('er6').innerHTML="Неправильно введены данные"; 
        document.getElementById('send').style.display="none";
        document.getElementById('button').disabled= true;
        six=false;
    }
   else{
       document.getElementById('er6').innerHTML="";
       document.getElementById('five').innerHTML=strN;
       six=true;
    }
   
}

function checkINN(){
    var sum2=0;
    var sum1=0;
    var n2=0;
    var n1=0;
    numberINN=document.getElementById('inn').value;
    var arrK_n2 = [7,2,4,10,3,5,9,4,6,8,0,0];
    var arrK_n1 = [3,7,2,4,10,3,5,9,4,6,8,0];
    var digit = numberINN.split('');
    if(digit.length==12){
        for(i=0;i<digit.length;i++){
            sum2+=digit[i]*arrK_n2[i];
            sum1+=digit[i]*arrK_n1[i];
        }
        n2=sum2%11;
        n1=sum1%11;
        if(n2==digit[0] && n1==digit[11]){
            document.getElementById('er7').innerHTML="";
            document.getElementById('six').innerHTML=numberINN;
            seven= true;
        }
        else{
            document.getElementById('er7').innerHTML="Неправильно введены данные";
            document.getElementById('send').style.display="none";
            document.getElementById('button').disabled= true;
            seven=false;
        }
        
    }
    else if(digit.length==10){
        for(i=0;i<digit.length;i++){
            sum1+=digit[i]*arrK_n1[i+2];
        }
        n1=sum1%11;
        if( n1==digit[9]){
            document.getElementById('er7').innerHTML="";
            document.getElementById('six').innerHTML=numberINN;
            seven= true;
        }
        else{
            document.getElementById('er7').innerHTML="Неправильно введены данные";
            document.getElementById('send').style.display="none";
            document.getElementById('button').disabled= true;
            seven=false;
        }
    }
    else{
        document.getElementById('er7').innerHTML="Неправильно введены данные";
        document.getElementById('send').style.display="none";
        document.getElementById('button').disabled= true;
    }
}
function last(){
   if( one==true && two==true && three==true && four==true && five==true && six==true && seven==true){
    if(document.getElementById('m').checked){
        document.getElementById('button').disabled= false;
        document.getElementById('seven').innerHTML=document.getElementById('m').value;
    }
    else{
    document.getElementById('button').disabled= false;
    document.getElementById('seven').innerHTML=document.getElementById('w').value;
    }
}
        
}
function send(){
    document.getElementById('send').style.display="block";
}
function rere(){
    document.getElementById('send').style.display="none";
    document.getElementById('button').disabled= true;

}
