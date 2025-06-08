$(function () {
    $('#ButtonEnviar').click(function (e) {
        var nombre = $('#TextBoxNombre').val().trim();
        var correo = $('#TextBoxCorreo').val().trim();
        var correoRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        var error = false;

        // Limpiar mensajes previos
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
            e.preventDefault();
            return false;
        }
    });
});