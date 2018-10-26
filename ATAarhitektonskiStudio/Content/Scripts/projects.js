var imgsOwl = $('.project-imgs-carousel');
imgsOwl.owlCarousel({
    loop: false,
    autoPlay: false,
    nav: true,
    dots: false,
    mouseDrag: false,
    rewind: true,
    responsive: {
        0: {
            items: 1,
            autoWidth: false,
            margin: 0
        },
        768: {
            items: 2,
            margin: 10,
            autoWidth: false,
        },
        1200: {
            autoWidth: true,
            margin: 10
        }
    }
});
imgsOwl.on('translated.owl.carousel', function (event) {
    if ($('.project-imgs-carousel .owl-item:first-child').hasClass('active')) {
        $('.owl-prev').hide();
    }
    else {
        $('.owl-prev').show();
    }
});

lightbox.option({
    'resizeDuration': 200,
    'wrapAround': true,
    'showImageNumberLabel': false
});

if ($(window).width() > 1200) {
    var imgsHeight = $(window).height() / 2;
    $('.project-img > img').height(imgsHeight);
    $(document).ready(function () {
        $('#video > iframe').height(imgsHeight);
    });
    $('#projectText').height($(window).height() / 2 - $('.menu-container').height() - 70);
    $('#projectText').mouseover(function () {
        $(this).height($('.project-text').height() + 40);
    });
    $('#projectText').mouseleave(function () {
        $(this).height($(window).height() / 2 - $('.menu-container').height() - 70);
    });
}

window.onresize = function () {
    if ($(window).width() > 1200) {
        var imgsHeight = $(window).height() / 2;
        $('.project-img > img').height(imgsHeight);
        $('#video > iframe').height(imgsHeight);
        $('#projectText').height($(window).height() / 2 - $('.menu-container').height() - 70);
        $('#projectText').mouseover(function () {
            $(this).height($('.project-text').height() + 40);
        });
        $('#projectText').mouseleave(function () {
            $(this).height($(window).height() / 2 - $('.menu-container').height() - 70);
        });
    }
    else {
        $('.project-img > img').height('300px');
    }
};

$(document).ready(function () {
    if ($('.project-imgs-carousel .owl-item:first-child').hasClass('active')) {
        $('.owl-prev').hide();
    }
});