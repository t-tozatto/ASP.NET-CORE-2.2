﻿$(document).ready(function () {
    $(".btn-danger").click(function (e) {
        var resultado = confirm("Deseja realizar essa operação?");
        if (resultado == false) {
            e.preventDefault();
        }
    });
});