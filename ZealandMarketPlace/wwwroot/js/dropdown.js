$(document).ready(function(){
    $('.slider').click(function(){
        $('.filtering_dropdown ul').toggleClass('active');
    });

    $('.main_option').click(function(){
        $('.filtering_dropdown ul').toggleClass('active');
    });

    $('.filtering_dropdown ul li').click(function(){
        const category = $(this).text();
        $('.main_option').text(category);
        $('.filtering_dropdown ul').removeClass('active');

    });
});