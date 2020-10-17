let globalUrl = window.location.origin;
function RedirecionaParaPagina(controller, pagina) {
    window.location.href = globalUrl.concat("/", controller, "/", pagina);
};

function successMessage(header, mensagem, callback) {
    var modal = '<div  id="modalSucess" class="modal fade bd-example-modal-sm" tabindex=" - 1" role="dialog">' +
        '< div class="modal-dialog modal-sm" role = "document" > ' +
        '<div class="modal-content">  ' +
        '<div class="modal-header">  ' +
        ' <h5 class="modal-title">' + header + '</h5>  ' +
        '    <button type="button" class="close" data-dismiss="modal" aria-label="Close">' +
        '        <span aria-hidden="true">&times;</span>' +
        '    </button>' +
        '</div>' +
        '<div class="modal-body">' +
        '    <p>' + mensagem + '</p>' +
        '</div>' +
        '<div class="modal-footer">' +
        '    <button type="button" class="btn btn-primary">Save changes</button>' +
        '    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>' +
        '</div>' +
        '</div>' +
        '</div >' +
        '</div >';

    $("body").append(modal);
    $("#modalSucess").modal("show");
    $('#modalSucess').on('hidden.bs.modal', function (e) {
        if (typeof callback == "function")
            callback();
    });
}

function SetarMascaraCpf(idCampoCpf) {
    $(idCampoCpf).mask('000.000.000-00', { reverse: false });
};

function ControlaGridAtivo(event) {
    let idAbaAtiva = event.id;
    let idGridAtivo = idAbaAtiva.replace("aba", "");

    $('[id^="aba"] a').removeClass("active");
    $("#" + idAbaAtiva + " a").addClass("active");

    $('[id^="grid"]').hide();
    $("#grid" + idGridAtivo).show();
};