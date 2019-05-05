var canvas = document.getElementById("sprite");
var ctx = canvas.getContext("2d");

var x=0,
    y=0,
tick_count=0;


var sprite = new Image();
sprite.src='/Users/daana/Pictures/всякое/I_NEED_IT/useful_things/animation/animal-2a.png';
sprite.onload = function(){
    tick();
    requestAnimationFrame(tick);
};
function tick(){
    if(tick_count>20){
        draw();
        tick_count=1;
    }
    tick_count+=1;
    requestAnimationFrame(tick);
//384/4=96
}

function draw(){
    ctx.clearRect(0,0,canvas.width,canvas.height);
    x=(x===384?0:x+96);
    ctx.drawImage(sprite,x,y,96,96,15,15,96,96);
}

