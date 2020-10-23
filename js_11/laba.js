(function ($) {
    $(function () {
        $("ul.tabs_caption").on("click", "li:not(.active)", function () {
            $(this)
                .addClass("active")
                .siblings()
                .removeClass("active")
                .closest("div.tabs")
                .find("div.tabs_content")
                .removeClass("active")
                .eq($(this).index())
                .addClass("active");
            $(".tab_text").css("display", "none");

        });
    });

    $(function () {
        $(".item").on("click", function () {
             $(".tab_text").slideToggle();
        });
    });
})(jQuery);
