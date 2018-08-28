var height = $(window).height();
$('.projects-carousel img').css('height', height);
window.onresize = function () {
    var height = $(window).height();
    $('.projects-carousel img').css('height', height);
}

$(".projects-carousel").owlCarousel({
    items: 1,
    loop: true,
    nav: true,
    dots: false,
    autoplay: true,
    animateOut: 'fadeOut',
    animateIn: 'fadeIn',
    navText: ["", ""],
    mouseDrag: false,
    stagePadding: 0,
    margin: 0
});

$('.projects-carousel').trigger('refresh.owl.carousel');

$(window).bind('load', function () {
    setTimeout(
        function () {
            $('.loader-container').fadeOut();
        }, 2000);
});

new TypeIt('#loader-text', {
    speed: 40
});