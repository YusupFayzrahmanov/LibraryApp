
function ajaxModal() {
    var href = $('a[datatoggle="ajax-modal"]');
    href.attr('datatoggle', '');
    href.click(function (event) {
        var url = $(this).attr('href');
        $.get(url).done(function (data) {
            $('.modal').modal('hide');
            $('#ajax-modal-placeholder').html(data);
            $('#ajax-modal-placeholder > .modal').modal('show');
            ajaxModal();
        });
        $('.modal').modal('hide');
        return false;
    });
}
window.onload = function () {
    ajaxModal();
};