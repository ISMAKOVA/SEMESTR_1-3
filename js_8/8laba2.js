var one = false,
two = false,
tree=false,
four = false,
five=false,
six=false,
seven = false;

var str= document.getElementById('surname').value;

var strL = document.getElementById('login').value;

var strP1 = document.getElementById('password1').value;
var strP2=document.getElementById('password2').value;

var strD=document.getElementById('date').value;

var strN=document.getElementById('number').value;

var numberINN=document.getElementById('inn').value;

function send(){
var rgxS=/[A-ZА-ЯЁ]{1}[a-zа-яё]{2,20}/gs;
var rgxL = /\w{3,10}/gis; 
var strongRegex = new RegExp("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.{8,})");
var rgxD = /(\d\d|\d)[-/.](\d\d|\d)[-/.](\d\d\d\d|\d\d)/;
var rgxNum=/^(\(\d{3}\)?[\- ]?)?[\d\- ]{6,10}$/;

var str_rgxS = str.match(rgxS);
   if(str_rgxS==null)  {document.getElementById('er1').innerHTML="Неправильно введены данные"}
   else{
       document.getElementById('er1').innerHTML="";
       one=true;
    }
var str_rgxL=strL.match(rgxL);
    if(str_rgxL==null) {document.getElementById('er2').innerHTML="Неправильно введены данные"}
   else{
       document.getElementById('er2').innerHTML="";
       two=true;
    }
    if(strongRegex.test(strP1)){
        document.getElementById('er3').innerHTML="";
    }
    else{
        document.getElementById('er3').innerHTML="Неправильно введены данные";
       three =true;
    }

    if(strP1==strP2){document.getElementById('er4').innerHTML="";}
    else{
        document.getElementById('er4').innerHTML="Неправильно введены данные";
        four=true;
    }
var date = strD.match(rgxD);
    if(date==null) {document.getElementById('er5').innerHTML="Неправильно введены данные"}
   else{
       document.getElementById('er5').innerHTML="";
        five=true;
    }
var number = strN.match(rgxNum);
    if(number==null){document.getElementById('er6').innerHTML="Неправильно введены данные"}
   else{
       document.getElementById('er6').innerHTML="";
       six=true;
    }

}
function checkINN(){
    var sum2=0;
    var sum1=0;
    var n2=0;
    var n1=0;
    var numberINN=document.getElementById('inn').value;
    var arrK_n2 = [7,2,4,10,3,5,9,4,6,8,0,0];
    var arrK_n1 = [3,7,2,4,10,3,5,9,4,6,8,0];
    var digit = numberINN.split('');
    if(digit.length==12){
        for(var i=0;i<digit.length;i++){
            sum2+=digit[i]*arrK_n2[i];
            sum1+=digit[i]*arrK_n1[i];
        }
        n2=sum2%11;
        n1=sum1%11;
        if(n2==digit[0] && n1==digit[11]){
            document.getElementById('er7').innerHTML="";
            seven= true;
        }
        else{
            document.getElementById('er7').innerHTML="Неправильно введены данные";
        }
        
    }
    else if(digit.length==10){
        for(var i=0;i<digit.length;i++){
            sum1+=digit[i]*arrK_n1[i+2];
        }
        n1=sum1%11;
        if( n1==digit[9]){
            document.getElementById('er7').innerHTML="";
            seven= true;
        }
        else{
            document.getElementById('er7').innerHTML="Неправильно введены данные";
        }
    }
    else{document.getElementById('er7').innerHTML="Неправильно введены данные";}
}