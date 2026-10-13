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

// Reemplaza el onclick en línea que tenía NavMenu.razor
document.addEventListener("click", function (e) {
    if (e.target.closest(".nav-scrollable")) {
        var toggler = document.querySelector(".navbar-toggler");
        if (toggler) toggler.click();
    }
});