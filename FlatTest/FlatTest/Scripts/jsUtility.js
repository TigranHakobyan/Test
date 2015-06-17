$(function () {
    $.ajaxSetup({ cache: false });
    $(".stItem").click(function (e) {
        e.preventDefault();
        $.get(this.href, function (data) {
            $('#dialogContent').html(data);
            $.validator.unobtrusive.parse($('#dialogContent'));
            $('#modDialog').modal('show');

        });
    });
})
