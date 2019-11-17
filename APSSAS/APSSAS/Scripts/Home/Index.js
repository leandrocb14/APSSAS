var varsConst = {
    InputUploadFile: $('#File'),
    BotaoSubmit: $('#BtnSubmit'),
    ChaveTextBox: $('#Chave'),
    TipoCriptografiaDropDown: $('#TipoCriptografia'),
    ChaveContainer: $('#container-chave'),
    AESValue: "AES",
    DESValue: "DES",
    BASE64Value: "Base64"
};

$(document).ready(function () {
    varsConst.BotaoSubmit.attr("disabled", "true");
    CarregaEventos();
    VerificaAtivacaoCampoChave();
});

function CarregaEventos() {
    varsConst.InputUploadFile.change(function () {
        AvaliaAtivacaoBotao();
    });
    varsConst.TipoCriptografiaDropDown.change(function () {
        VerificaAtivacaoCampoChave();
    });

    varsConst.ChaveTextBox.on("input", function () {
        AvaliaAtivacaoBotao();
    });
}

function VerificaAtivacaoCampoChave() {
    varsConst.ChaveTextBox.val("");
    if (varsConst.TipoCriptografiaDropDown.val() === varsConst.AESValue || varsConst.TipoCriptografiaDropDown.val() === varsConst.DESValue) {
        varsConst.ChaveContainer.removeClass("container-chave-visible");
        if (varsConst.TipoCriptografiaDropDown.val() === varsConst.AESValue)
            varsConst.ChaveTextBox.attr("maxlength", "32");
        else if (varsConst.TipoCriptografiaDropDown.val() === varsConst.DESValue)
            varsConst.ChaveTextBox.attr("maxlength", "24");
    }        
    else {
        varsConst.ChaveTextBox.attr("maxlength", "0");
        varsConst.ChaveTextBox.val("");
        varsConst.ChaveContainer.addClass("container-chave-visible");        
    }       
}

function AvaliaAtivacaoBotao() {
    if ((varsConst.InputUploadFile.val().trim().length === 0 || varsConst.ChaveTextBox.val().trim().length === 0) && varsConst.TipoCriptografiaDropDown.val() !== varsConst.BASE64Value)
        varsConst.BotaoSubmit.attr("disabled", "true");
    else
        varsConst.BotaoSubmit.removeAttr("disabled");
}