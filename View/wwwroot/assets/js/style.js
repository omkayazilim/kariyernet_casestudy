$(document).ready(function () {
  if ($(".home-header-slider").length > 0) {
    var homekatalogslider = new Swiper(".home-header-slider", {
      pagination: {
        el: ".paginations",
        clickable: true,
      },
    });
  }


  if ($(".home-certifica-slider").length > 0) {
    var homekatalogslider = new Swiper(".home-certifica-slider", {
      slidesPerView: 4,
      spaceBetween: 30,
      navigation: {
        nextEl: ".btn-next",
        prevEl: ".btn-prev",
      },
      breakpoints: {
        0: {
          slidesPerView: 2,
        },
        640: {
          slidesPerView: 2,
        },
        768: {
          slidesPerView: 2,
        },
        1024: {
          slidesPerView: 4,
        },
      },
    });
  }

  //form submit buttons animasyon ve alert olayları
  $(document).on("submit", "form", function (e) {
    e.preventDefault();
    $(this).find('button[type=submit]').attr("disabled", "true").addClass('active');
    setTimeout(() => {
      $(this).find('button[type=submit]').removeAttr("disabled").removeClass('active');
      Toast.fire({
        icon: 'success',
        title: 'Mesajınız Gönderilmiştir.',
        timerProgressBar: false,
      });
      return false;
    }, 3000);
  });


  //menu toggle olayları start
  $(".nav-item > .sub-menu").hover(function () {
    $(this).parent().addClass("active");
  });

  $(".nav-item > .sub-menu").mouseleave(function () {
    $(this).parent().removeClass("active");
  });

  $(".navicon").on("click", function () {
    $(this).toggleClass("navicon--active");
    $(".navbar-collapse").toggleClass("navbar-collapse--active");
    $("body,html").toggleClass("overflow");
    $(".overlay-body").toggle();
  });


  //menu toggle olayları end

  // sitedeki tüm dropdownları calıştırma  özelliği

  $(".js-down > li").click(function () {
    $(this).parent().prev().find("span").text($(this).text());
  });

  //dropdown ok toggle yönü
  $(".dropdown > .btn").on("show.bs.dropdown", function () {
    $(this).children(".bi-chevron-down").toggleClass("rotate-90");
  });

  $(".dropdown > .btn").on("hidden.bs.dropdown", function () {
    $(".bi-chevron-down").removeClass("rotate-90");
  });


  $('.lang-links').click(function () {
    $('.lang-links').removeClass("active");
    $(this).addClass("active");
  })


});

jQuery("img.svg").each(function () {
  var $img = jQuery(this);
  var imgID = $img.attr("id");
  var imgClass = $img.attr("class");
  var imgURL = $img.attr("src");
  jQuery.get(
    imgURL,
    function (data) {
      var $svg = jQuery(data).find("svg");
      if (typeof imgID !== "undefined") {
        $svg = $svg.attr("id", imgID);
      }
      if (typeof imgClass !== "undefined") {
        $svg = $svg.attr("class", imgClass + " replaced-svg");
      }
      $svg = $svg.removeAttr("xmlns:a");
      if (!$svg.attr("viewBox") && $svg.attr("height") && $svg.attr("width")) {
        $svg.attr(
          "viewBox",
          "0 0 " + $svg.attr("height") + " " + $svg.attr("width")
        );
      }
      $img.replaceWith($svg);
    },
    "xml"
  );
});