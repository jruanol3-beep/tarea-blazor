window.bsModal = {
    show: function (id) {
        var el = document.getElementById(id);
        var modal = bootstrap.Modal.getOrCreateInstance(el);
        modal.show();
    },
    hide: function (id) {
        var el = document.getElementById(id);
        var modal = bootstrap.Modal.getOrCreateInstance(el);
        modal.hide();
    }
};