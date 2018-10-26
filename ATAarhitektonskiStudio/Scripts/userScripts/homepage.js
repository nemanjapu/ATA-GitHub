var height = $(window).height();
$('.projects-carousel img').css('height', height);
$('.img-bottom').height(height - ($('.menu-container').height() + $('.banner-text').height()) - 20);
window.onresize = function () {
    var height = $(window).height();
    $('.projects-carousel img').css('height', height);
    $('.img-bottom').height(height - ($('.menu-container').height() + $('.banner-text').height()) - 20);
};

$('#logo-start').on('click', function () {
    $('.loader-container').fadeOut();
});

