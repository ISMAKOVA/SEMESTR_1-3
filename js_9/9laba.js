function getHeadline(){
    var a=document.getElementById('text1').value;
    document.getElementById('one').innerHTML = document.getElementById('text1').value;
}
function pic(){
var imgArray = new Array();
imgArray[0] = new Image();
imgArray[0].src = 'pic1.jpg' ;

imgArray[1] = new Image();
imgArray[1].src = 'pic2.jpg';

imgArray[2] = new Image();
imgArray[2].src = 'pic3.jpg';

imgArray[3] = new Image();
imgArray[3].src = 'pic4.jpg';
var checkbox=document.getElementsByName('anim');
for(var i=0; i<checkbox.length;i++){
    if(checkbox[i].checked){
        document.getElementById('pict').src = imgArray[i].src;
        document.getElementById('pict').style.display="block";
    }
}
}
function getText(){
    var b=document.getElementById('text2').value;
    document.getElementById('two').innerHTML = document.getElementById('text2').value;
}
function changeBgC(){
    var colors=['#90EE90','#fff','#AFEEEE','#CD5C5C'];
    var c = document.getElementById('select');
    var index = c.selectedIndex;
        document.getElementById('buba').style.backgroundColor=colors[index];
}
function changeTxtC(){
    var c=document.getElementsByName('color');
    var colors=['#000','#191970','#006400','#fff'];
    for(var i=0;i<c.length;i++){
        if(c[i].checked){
        document.getElementById('buba').style.color=colors[i];
    }
    }
}
function show(){
    document.getElementById('buba').style.display="block";
    document.getElementById('one').innerHTML = document.getElementById('text1').value;
    document.getElementById('two').innerHTML = document.getElementById('text2').value;

    var divText= document.getElementById('buba').outerHTML;
    var myWindow = window.open('','','width=500,height=450');
    var doc = myWindow.document;
    doc.open();
    doc.write('<head><meta charset="UTF-8"><link rel="stylesheet" type="text/css" href="9laba.css"><title>новое окно</title></head><body>');
    doc.write(divText);
    doc.write('</body></html>');
    doc.close();

}
function getr(){
document.getElementById('buba').style.display="none";
}