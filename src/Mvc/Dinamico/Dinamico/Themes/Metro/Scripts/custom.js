/// <reference path="jquery-1.5.js" />

$(document).ready(function () {

    // Panel
    $('.op-elem').openpanel();

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

                var tag = '';
                for (var i = 0; i < r[0].tags.length; i++) {
                    tag = tag + '<a href="#">' + r[0].tags[i] + '</a>';
                    //Do something
                }
        
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