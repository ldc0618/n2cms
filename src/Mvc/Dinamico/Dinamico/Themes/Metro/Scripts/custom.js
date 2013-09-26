/// <reference path="jquery-1.5.js" />

$(document).ready(function () {

    // Panel
    $('.op-elem').openpanel();

    $(".themecolor").click(function () {
        var color = $(this).attr("data-style");
        $.cookie('themecolor', color, { expires: 360, path: '/' });
        location.reload();
    });

    $(".news-open").click(function () {

        $('.op-elem').trigger('click');

        var itemId = $(this).attr("data-itemid");
        var parentId = $(this).attr("data-parentid");
        var actionURL = '/NewsContainer/GetNewsItem';
        var params = 'parentid=' + parentId + '&itemid=' + itemId;

        $.ajax({
            type: "POST",
            url: actionURL,
            data: params,
            success: function (r) {

                $('.news-title').html(r[0].title);
                $('.news-date').html(r[0].published);
                $('.news-text').html(r[0].text);
                $('.news-image').attr('src', r[0].image);

                //tags
                $('.icon-tags').hide();
                var tag = '';
                for (var i = 0; i < r[0].tags.length; i++) { 
                    tag = tag + '<a class="tag-popup" href="#">' + r[0].tags[i] + '</a>';
                    $('.icon-tags').show();
                }
                
                $('.tag-popup').remove();
                $('.news-tags').append(tag);
            },
            complete: function () {
                
            },
            error: function (req, status, error) {
                alert(error);
            }
        });

        
    });
});