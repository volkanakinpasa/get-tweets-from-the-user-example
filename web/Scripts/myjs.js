(function ($) {

    $(document).ready(function () {
        //Jquery nesnesine extention method yazmak için...
        $("#readAllWithExtentionMethod div").readAllWithExtentionMethod();
        $("#readAllWithExtentionMethod div").readAllWithExtentionMethodV2();
        $("#readAllWithExtentionMethod div").readAllWithExtentionMethodV3(true);

        $.fn.getCallback($.fn.myCallback);
    });

     


    $.fn.readAllWithExtentionMethod = function () {
        this.each(function () {
            console.log("readAllWithExtentionMethod-------" + this.innerHTML);
        });
    };

    $.fn.extend({
        readAllWithExtentionMethodV2: function () {
            this.each(function () {
                console.log("readAllWithExtentionMethodV2-------" + this.innerHTML);
            });
        },
        readAllWithExtentionMethodV3: function (param) {
            this.each(function () {
                console.log("readAllWithExtentionMethodV3-------" + param + "--------" + this.innerHTML);
            });
        }

    });

    $.fn.getCallback = function(callback) {
        callback();
    };

    $.fn.myCallback = function () {
        console.log("myCallback called");
    };

})(jQuery);

 