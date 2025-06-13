$(function () {
    cargarUsuarios();

    $('#ButtonEnviar').click(function (e) {
        e.preventDefault();

        $('#ErrorGeneral').html(''); // Limpiar mensaje general

        var nombre = $('#TextBoxNombre').val().trim();
        var correo = $('#TextBoxCorreo').val().trim();
        var correoRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        var error = false;

        $('#ErrorNombre').html('');
        $('#ErrorCorreo').html('');

        if (nombre === "") {
            $('#ErrorNombre').html('El campo Nombre es obligatorio.');
            error = true;
        }
        if (correo === "") {
            $('#ErrorCorreo').html('El campo Correo electrónico es obligatorio.');
            error = true;
        } else if (!correoRegex.test(correo)) {
            $('#ErrorCorreo').html('El correo electrónico no tiene un formato válido.');
            error = true;
        }

        if (error) {
            return false;
        }

        $.ajax({
            type: "POST",
            url: "Default.aspx/GuardarUsuario",
            data: JSON.stringify({ nombre: nombre, correo: correo }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var res = JSON.parse(response.d);
                if (res.success) {
                    $('#TextBoxNombre').val('');
                    $('#TextBoxCorreo').val('');
                    cargarUsuarios();
                } else {
                    $('#ErrorGeneral').html('Error al guardar el usuario.');
                }
            },
            error: function () {
                $('#ErrorGeneral').html('Error de comunicación con el servidor al guardar el usuario.');
            }
        });
    });

    function cargarUsuarios() {
        $.ajax({
            type: "POST",
            url: "Default.aspx/ObtenerUsuarios",
            data: '{}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var datos = JSON.parse(response.d);
                var html = '';
                if (datos.length === 0) {
                    html = '<tr><td colspan="2" class="text-center">No existen registros.</td></tr>';
                } else {
                    for (var i = 0; i < datos.length; i++) {
                        html += '<tr><td>' + datos[i].Nombre + '</td><td>' + datos[i].Correo + '</td></tr>';
                    }
                }
                $('#GridViewDatos tbody').html(html);
            },
            error: function () {
                var html = '<tr><td colspan="2" class="text-center text-danger">Error de comunicación con el servidor.</td></tr>';
                $('#GridViewDatos tbody').html(html);
            }
        });
    }
});