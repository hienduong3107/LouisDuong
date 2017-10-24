
$(function () {
    var d = 300;
    $('#cart_shopping div#main_cart').each(function () {
        $(this).stop().animate({
            'marginLeft': '0px'
        }, d += 150);
    });
    $('#cart_shopping > li').hover(
      function () {
          $('div#main_cart', $(this)).stop().animate({
              'marginLeft': '150'
          }, 200);
      },
      function () {
          $('div#main_cart', $(this)).stop().animate({
              'marginLeft': '0px'
          }, 200);
      }
      );
});