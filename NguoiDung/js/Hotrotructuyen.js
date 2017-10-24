
$(function () {
    var d = 300;
    $('#hotrotructuyen div#main_hotro').each(function () {
        $(this).stop().animate({
            'marginLeft': '0px'
        }, d += 150);
    });
    $('#hotrotructuyen > li').hover(
      function () {
          $('div#main_hotro', $(this)).stop().animate({
              'marginLeft': '80'
          }, 200);
      },
      function () {
          $('div#main_hotro', $(this)).stop().animate({
              'marginLeft': '0px'
          }, 200);
      }
      );
});