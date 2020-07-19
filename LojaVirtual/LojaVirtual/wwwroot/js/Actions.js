$(document).ready(function () {
    $(".btn-danger").click(function (e) {
        var resultado = confirm("Deseja realizar essa operação?");
        if (resultado == false) {
            e.preventDefault();
        }
    });

    $('.dinheiro').mask('000.000.000.000.000,00', { reverse: true });

    AjaxUploadImagemProduto();
});

function AjaxUploadImagemProduto() {
    $(".img-upload").click(function () {
        $(this).parent().parent().find(".input-file").click();
    });

    $(".btn-imagem-excluir").click(function () {
        var CampoHidden = $(this).parent().find("input[name=imagem]");
        var Imagem = $(this).parent().find(".img-upload");
        var BotaoExcluir = $(this).parent().find(".btn-imagem-excluir");
        var Upload = $(this).parent().find(".input-file");

        $.ajax({
            type: "GET",
            url: "/Colaborador/Imagem/Deletar?caminho=" + CampoHidden.val(),
            error: function () {
                
            },
            success: function () {
                CampoHidden.val("");
                Imagem.attr("src", "/img/imagem-padrao.png");
                BotaoExcluir.addClass("btn-ocultar");
                Upload.val("");
            }
        })
    })

    $(".input-file").change(function () {
        var Imagem = $(this).parent().find(".img-upload");

        Imagem.attr("src", "/img/loading.gif" );

        var Formulario = new FormData();
        Formulario.append("file", $(this)[0].files[0]);

        var CampoHidden = $(this).parent().find("input[name=imagem]");
        var BotaoExcluir = $(this).parent().find(".btn-imagem-excluir");
       
        $.ajax({
            type: "POST",
            url: "/Colaborador/Imagem/Armazenar",
            data: Formulario,
            contentType: false,
            processData: false,
            error: function () {
                alert("Erro no envio do arquivo!");
                Imagem.attr("src", "/img/imagem-padrao.png");
            },
            success: function (data) {
                CampoHidden.val(data.caminho);
                Imagem.attr("src", data.caminho);
                BotaoExcluir.removeClass("btn-ocultar");
            }
        });
    });
}