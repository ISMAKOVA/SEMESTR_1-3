var interval;
function start(){
  var id=[1,2,3,4,5,6];
  var x=[0,0,0,-500,-500,-500];
  var y=[0,-180,-360,0,-180,-360];
  let car= document.querySelectorAll('.block');
  for(var i=0;i<car.length;i++){
    if(car[i].id==`car${id[i]}`){
      car[i].style.backgroundImage="url('cars.jpg')";
      car[i].style.backgroundPosition=`${x[i]}px ${y[i]}px`;
    }
  }
}
document.addEventListener("mouseover", function(e) {
  let txt=document.getElementById('carName');
  let elCar=e.target.id;
  //console.log(e.target.id);
  if(elCar=='car1'){
    txt.value="Jaguar E-Type, 1961";
  }
  if(elCar=='car2'){
    txt.value="Rolls-Royce Silver-Shadow, 1965";
  }
  if(elCar=='car3'){
    txt.value="Aston Martin DB5, 1963";
  }
  if(elCar=='car4'){
    txt.value="MG MGB, 1962";
  }
  if(elCar=='car5'){
    txt.value="Morgan Plus 8, 1962";
  }
  if(elCar=='car6'){
    txt.value="Lotus Esprit, 1976";
  }
}, false);

 var t=0;
 var count=1;

function exec(elemN,count){
  let elem=document.querySelectorAll('.block');
  for(var i=0; i<elem.length-2;i++){
  elem[elemN].style.order=`${count}`;
  if(elem[elemN]>3){
    elem[i].style.order="0";
  }
  }
}

function Run(){
  interval=setInterval(function change(){
    t++;
      if(t>3)
      {
      t=0;
      count++;
      }
    return exec(t,count);
  },1000);
  console.log(interval);
  document.getElementById('stop').disabled=false;
}

function Stop(){
  clearInterval(interval);
}
function Show(){
  t++;
      if(t>3)
      {
      t=0;
      count++;}
      return exec(t,count);
}
