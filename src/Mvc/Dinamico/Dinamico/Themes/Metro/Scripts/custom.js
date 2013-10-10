/// <reference path="jquery-1.5.js" />

$(document).ready(function () {

    // Panel
    $('.op-elem').openpanel();

    SetupColorPanel();

    NewsOpenDetails();

    PublishPage();

});

function SetupColorPanel() {
    $(".themecolor").click(function () {
        var color = $(this).attr("data-style");
        $.cookie('themecolor', color, { expires: 360, path: '/' });
        location.reload();
    });
}

function NewsOpenDetails() {

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

}

function PublishPage() {

    $(".publish-page").click(function () {

        //example json to be posted:
        //{"selected":"/languages/en/files/","versionIndex":3}

        var url = $(this).attr("data-url");
        var latestVersion = $(this).attr("data-version-index");
        var actionURL = '/N2/Api/Content.ashx/publish';
        //var params = '{ "selected": "/languages/en/files/", "versionIndex": 4 }'

        var params = { selected: url, versionIndex: latestVersion };

        $.ajax({
            type: "POST",
            url: actionURL,
            data: params,
            success: function (r) {

                //$('.news-title').html(r[0].title);
                location.reload();
            },
            complete: function () {

            },
            error: function (req, status, error) {
                alert(error);
            }
        });


    });

}

function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results == null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}