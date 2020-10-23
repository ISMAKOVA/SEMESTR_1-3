function create(){
    let path = window.location.pathname;
	path = path.substring(1, path.length - 10);
    const width=500;
    const height=450;
    let text1=document.getElementById("text1").value;
    let text2=document.getElementById("text2").value;
    let picture = document.getElementsByName("anim");
    let backgroundC= document.getElementById("select").options[document.getElementById("select").selectedIndex].value;
    let color=document.getElementsByName("color");
    let font_color="";
    let colors=["#000","#191970","#006400","#fff"];
    for(var i=0;i<color.length;i++){
        if(color[i].checked)
           font_color+=colors[i];
    }
    let img="";
    let pic=["pic1.jpg","pic2.jpg","pic3.jpg","pic4.jpg"];
    for(i=0;i<picture.length;i++){
        if(picture[i].checked)
          img=pic[i];
    }
   
    //Первый вариант
    let new_div = document.createElement('div');
    let myDiv = document.getElementById("nothing");
    let parentDiv= myDiv.parentNode;
    new_div.className="new_div";
    new_div.style.backgroundColor=`${backgroundC}`;
    new_div.style.backgroundSize = "100% 100%";
	new_div.style.width = `${width}px`;
    new_div.style.height = `${height}px`;
    new_div.style.color=`${font_color}`;
    new_div.innerHTML = `<h2 color=${font_color}>${text1}</h2>`;
    new_div.innerHTML += `<img style="height:300px;" src=${img}></img>`;
    new_div.innerHTML += `<h2 color="${font_color};font-size:30pt;">${text2}</h2>`;
    new_div.innerHTML += "<button class='button forClose' onclick=' Remove(event.path[1])'>Закрыть</button>";
    parentDiv.insertBefore(new_div,myDiv);

    //Второй вариант
    let new_window = window.open("about:blank", "popup",`width=${width},height=${height}`);
    let doc=new_window.document;
    doc.open();
    doc.write('<head><meta charset="UTF-8"><link rel="stylesheet" type="text/css" href="9.1laba.css"><title>новое окно</title></head><body>');
    doc.write(`<div class="new_div" style="background-color:${backgroundC}; background-size:100% 100%; color:${font_color}";>`);
    doc.write(`<h2 color=${font_color}>${text1}</h2>`);
    doc.write(`<img style="height:300px;" src=${img}></img>`);
    doc.write(`<h2 color="${font_color};font-size:28pt;">${text2}</h2>`);
    doc.write(`</div>`);
    doc.write('</body></html>');
    doc.close();

}
function Remove(block){
    block.parentNode.removeChild(block);
}