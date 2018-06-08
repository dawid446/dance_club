
    $(function () {
        $(".datepicker").datetimepicker({
            format: 'DD/MM/YYYY hh:mm',

        });

        $(".datepicker1").datetimepicker({
        format: 'DD/MM/YYYY',

                });
                jQuery.validator.methods["datepicker1"] = function (value, element) { return true; }
            });