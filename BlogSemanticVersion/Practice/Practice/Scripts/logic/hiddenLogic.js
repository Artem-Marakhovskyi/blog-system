$(document).ready(function () {
    var minimized_elements = $('p.article');
    var minimize_character_count = 200;

    for (var i = 0; i < minimized_elements.length; i++) {
        var t = $(minimized_elements[i]).text();
        if (t.length < minimize_character_count) return;

        $(minimized_elements[i]).html(
            t.slice(0, minimize_character_count) + '<span>... </span>');

    }
});