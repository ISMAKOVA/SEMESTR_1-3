$(document).ready(function() {
  var last_pic;
  var pic_root = "file:///Users/daana/Pictures/всякое/js/js_12/pics";
  var click_flag = 1;
  var count_click = 0;
  var array_pic = [1, 3, 2, 5, 4, 6, 7, 1, 4, 2, 6, 8, 5, 8, 7, 3];
  var count_p = 0;
  mix(array_pic);

  $("#txt").keypress(function() {
    $(this).css("backgroundColor", "rgb(255, 241, 250)");
  });
  $("#GameStop").click(function(){
    document.location.reload();
  });
  $("#btn").click(function() {
    if ($("#txt").val().length > 2 && $("#txt").val() != "tester") {
      $("#SplashScreen").hide();
      $("#n").text($("#txt").val());

      setTimeout(function() {
        var sec = 30;
        var counter = setInterval(function timer() {
          sec = sec - 1;
          if (sec >= 10) {
            document.getElementById("timer").innerHTML = "00:" + sec;
          } else {
            document.getElementById("timer").innerHTML = "00:0" + sec;
          }
          if (sec <= 0) {
            clearInterval(counter);
            document.getElementById("timer").innerHTML = "00:00";
            $("#GameStop").css("display", "flex");
            if (count_p == 40){
              $("#result").html("Поздравляем, вы победили! У вас 40 баллов!");
              $("#win").css("backgroundImage","url(/Users/daana/Pictures/всякое/js/js_12/Ve1.gif)");
              $(".blocks div").each(function(i) {
                $(this).css("backgroundImage", "none");
              });
            }
            else{
              $("#result").html("Ваш результат " + count_p + " баллов. Попробуйте еще!");
              $(".blocks div").each(function(i) {
                $(this).css("backgroundImage", "none");
              });
            }
            return;
          }
        }, 1000);
      }, 5000);
    } else if ($("#txt").val() == "tester") {
      $("#SplashScreen").hide();
      $("#n").text($("#txt").val());
      $("#n").css("color", "red");
      /*     if(count_p == 40){
        $("#GameStop").css("display", "flex");
        $("#result").html("Поздравляем, вы победили! У вас 40 баллов!");
              $("#win").css("backgroundImage","url(/Users/daana/Pictures/всякое/js/js_12/Ve1.gif)");
              $(".blocks div").each(function(i) {
                $(this).css("backgroundImage", "none");
              });
            } */
    } else {
      $("#txt").css("backgroundColor", "rgb(230, 134, 150)");
    }
  });
  function mix(mixArr) {
    let index, valueIndex;
    for (var i = 0; i < mixArr.length - 1; i++) {
      index = Math.floor(Math.random() * i);
      valueIndex = mixArr[index];
      mixArr[index] = mixArr[i];
      mixArr[i] = valueIndex;
    }
    return mixArr;
  }

  $("#btn").click(function() {
    if ($("#txt").val().length > 2) {
      $(".blocks div").each(function(i) {
        $(this).css(
          "backgroundImage",
          "url(" + pic_root + "/" + array_pic[i] + ".png)"
        );
      });
      setTimeout(function() {
        $(".blocks div").each(function(i) {
          $(this).css("backgroundImage", "none");
        });
      }, 5000);
    }
  });

  $(".blocks div").each(function() {
    $(this).attr({ class: "num" + array_pic[count_click], "data-state": "0" });
    count_click++;
  });

  count_click = 0;

  $(".blocks div").click(function() {
    if ($(this).data("state") == 0 && click_flag == 1) {
      if (count_click == 0) {
        count_click++;
        last_pic = $(this).attr("class");
        $(this)
          .data("state", 1)
          .attr("data-state", 1)
          .css(
            "backgroundImage",
            "url(" + pic_root + "/" + last_pic.substr(3, 1) + ".png)"
          );
      } else {
        if (last_pic == $(this).attr("class")) {
          $("." + last_pic)
            .data("state", 2)
            .attr("data-state", 2)
            .css(
              "backgroundImage",
              "url(" + pic_root + "/" + last_pic.substr(3, 1) + ".png)"
            );
          count_p = count_p + 5;
          $("#p").html(count_p);
        } else {
          $(this)
            .data("state", 1)
            .attr("data-state", 1)
            .css(
              "backgroundImage",
              "url(" +
                pic_root +
                "/" +
                $(this)
                  .attr("class")
                  .substr(3, 1) +
                ".png)"
            );

          click_flag = 0;

          function hidePic() {
            $(".blocks div").each(function() {
              if ($(this).data("state") == 1) {
                $(this)
                  .data("state", 0)
                  .attr("data-state", 0)
                  .css("backgroundImage", "none");
              }
            });
            click_flag = 1;
          }
          setTimeout(hidePic, 500);
        }
        count_click = 0;
      }
    }
  });
});
