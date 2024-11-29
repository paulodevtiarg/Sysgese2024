$(function () {
    $('.date').mask('99/99/9999');
    $('.time').mask('00:00:00');
    $('#cep').mask('99.999-999');
    $('#Cep').mask('99.999-999');
    $('.phone').mask('9999-9999');
    $('.telefone').mask('(99)9999-9999');
    $('.celular').mask("(99)99999-9999");
    $('#Celular').mask("(99)99999-9999");
    $('#cnpj').mask('99.999.999/9999-99');
    $('#Cnpj').mask('99.999.999/9999-99');
    $('.cnpj').mask('99.999.999/9999-99');
    $('#telefone').mask('(99)9999-9999');
    $('#Telefone').mask('(99)9999-9999');
    $(".senha").mask("xxxxxxxxx");
    $("#cest").mask("99.999.99");
    $("#ProcuraNCM").mask("9999.99.99");
    $("#ncm").mask("9999.99.99");
    $(".decimal").mask("9999,999");
    $(".pr-aliq").mask("9999.999");
});
$(function () {
    const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]')
    const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl))
    $('[data-toggle="tooltip"]').tooltip()
});

//function limparInputs() {
//    // Obtém todos os elementos de entrada (inputs) usando document.querySelectorAll
//    var inputs = document.querySelectorAll('input');

//    //Objem o nome do titulo, que serve como o nome do controller
//    var controller = document.getElementById("titulo").innerHTML;

//    // Itera sobre os elementos e define o valor de cada input como uma string vazia
//    inputs.forEach(function (input) {
//        input.value = '';
//    });
//    //variavel auxiliar valor que recebe vazia
//    var valor = "TODOS";

//    document.getElementById('Status').value = valor;


//    //chama a index novamente para carregar as listas e atualizar a página, de acordo com seu controller
//    //que é justamente o titulo da pagina
//    window.location.href = '/' + controller + '/Index';
//}
function limparInputsESelects() {
    // Obtém todos os elementos de entrada (inputs) usando document.querySelectorAll
    var inputs = document.querySelectorAll('input');

    // Itera sobre os inputs e define o valor de cada input como uma string vazia
    inputs.forEach(function (input) {
        input.value = '';
    });

    // Obtém todos os elementos de seleção (selects)
    var selects = document.querySelectorAll('select');

    // Itera sobre os selects e define o valor selecionado para o primeiro <option> com "selected"
    selects.forEach(function (select) {
        var firstOption = select.querySelector('option[selected]');
        if (firstOption) {
            select.value = firstOption.value;
        } else {
            // Caso nenhuma opção tenha "selected", seleciona a primeira opção
            select.selectedIndex = 0;
        }
    });

    // Variável auxiliar para o status
    var valor = "TODOS";
    document.getElementById('Status').value = valor;

    // Obtém o nome do título, que serve como o nome do controller
    var controller = document.getElementById("titulo").innerHTML;

    // Redireciona para a index novamente para carregar as listas e atualizar a página
    window.location.href = '/' + controller + '/Index';
}
function maiuscula(z) {
    v = z.value.toUpperCase();
    z.value = v;
}

function minuscula(z) {
    v = z.value.toLowerCase();
    z.value = v;
}


function buscarDadosClientes() {
    var cnpj = $('#Cnpj').val().replace(/[^\d]/g, '');
    alert("Chegou aqui"+cnpj)
    if (cnpj == "") {
        alert("DIGITE UM CNPJ VdÁLIDO");
    } else {
        $.ajax({
            type: 'GET',
            url: '/Cliente/BuscarDadosCliente',
            data: { cnpj: cnpj },
            success: function (data) {
                console.log(data);
                $('#Razao').val(data.razao);
                $('#Fantasia').val(data.fantasia);
                $('#NatJuridica').val(data.natJuridica);
                $('#AtvPrincipal').val(data.atvPrincipal);
                $('#Cep').val(data.cep);
                $('#Endereco').val(data.endereco);
                $('#Numero').val(data.Numero);
                $('#Complemento').val(data.complemento);
                $('#Bairro').val(data.bairro);
                $('#Cidade').val(data.cidade);
                $('#UF').val(data.uf);
                $('#NomeResponsavel').val(data.nomeResponsavel);
                $('#Telefone').val(data.telefone);
                $('#Email').val(data.email);
                $('#SitCadastral').val(data.sitCadastral);
                $('#MotDescCred').val(data.motDescCred);
                $('#DataAbertura').val(data.dataAbertura);
            }
        });
    }
}
//$(function () {
//    $.ajaxSetup({ cache: false });
//    $("#btnBuscarClientes").click(function () {
//        var inputValue = $("#Cnpj").val(); // Pega o valor do input
//        alert(inputValue)
//    })
//});
//FECHAR O ALERT APOS A MENSAGEM
$(function () {
    setTimeout(function () {
        $(".alert").fadeOut("slow", function () {
            $(this).alert('close');
        });
    }, 5000);
});