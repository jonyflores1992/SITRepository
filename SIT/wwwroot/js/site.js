// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    $("#loaderbody").addClass('hide');
    $(document).bind('ajaxStart', function () {
        $("#loaderbody").removeClass('hide');

    }).bind('ajaxStop', function () {
        $("#loaderbody").addClass('hide');
    });

});

ShowInPopup = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $("#form-modal .modal-body").html(res);
            $("#form-modal .modal-title").html(title);
            $("#form-modal").modal("show");

        }
    });
}

JQueryAjaxDeleteDefecto = form => { 
    if (confirm("Desea Eliminar el registro?")) {
    try {

            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData:false,
                success: function (res) {

                    if (res.Ok) {
                        $("#view-all").html(res.html);
                        Swal.fire({
                            icon: 'success',
                            title: 'Eliminado con exito',
                            showConfirmButton: false,
                            timer: 2000
                        });

                    }

                    else {
                        Swal.fire({
                            icon: 'error',
                            title: 'Hubo un Error',
                            showConfirmButton: false,
                            timer: 2000
                        });
                    }
                },
                error: function (err) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Hubo un Error',
                        showConfirmButton: false,
                        timer: 2000
                    });
                }
            })
        }
        catch (e) {
            console.log(e)
        }
    }
    return false;
}

JQueryAjaxPost = form => {
        try {

            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {

                    if (res.Ok) {
                        $("#view-all").html(res.html);
                        $("#form-modal .modal-body").html('');
                        $("#form-modal .modal-title").html('');
                        $("#form-modal").modal('hide');
                        $("#Tabla").addClass('display');
                        Swal.fire({
                            icon: 'success',
                            title: 'Guardado con exito',
                            showConfirmButton: false,
                            timer: 2000
                        });

                    }

                    else {
                        $("#form-modal .modal-body").html(res.html);
                        Swal.fire({
                            icon: 'error',
                            title: 'Hubo un Error',
                            showConfirmButton: false,
                            timer: 2000
                        });
                    }
                },
                error: function (err) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Hubo un Error',
                        showConfirmButton: false,
                        timer: 2000
                    });
                }
            })
        }
        catch (e) {
            console.log(e)
        }
    
    return false;
}