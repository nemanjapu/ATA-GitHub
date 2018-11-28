var height = $(window).height();
$('.projects-carousel img').css('height', height);
$('.img-bottom').height(height - ($('.menu-container').height() + $('.banner-text').height()) - 20);
$('.img-bottom').css("max-height", height * 2 / 5);
window.onresize = function () {
    var height = $(window).height();
    $('.projects-carousel img').css('height', height);
    $('.img-bottom').height(height - ($('.menu-container').height() + $('.banner-text').height()) - 20);
    $('.img-bottom').css("max-height", height * 2 / 5);
};

if (sessionStorage.getItem('advertOnce') !== 'true') {
    $('body').append('<div class="loader-container"><div class="loader-content"><img id="logo-start" src="/Content/images/logo2-black.png" alt="Ata Arhitektonski Studio d.o.o" /></div></div>')
    sessionStorage.setItem('advertOnce', 'true');
}

$('#logo-start').on('click', function () {
    $('.loader-container').fadeOut();
});

