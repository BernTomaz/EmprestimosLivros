﻿
$(document).ready(function () {

    $('#Emprestimos').DataTable({
        language: {
            "decimal": "",
            "emptyTable": "No data available in table",
            "info": "Mostrando _START_ Registro de _END_ em total de _TOTAL_ entradas",
            "infoEmpty": "Showing 0 to 0 of 0 entries",
            "infoFiltered": "(filtered from _MAX_ total entries)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ entradas",
            "loadingRecords": "Loading...",
            "processing": "",
            "search": "Procurar:",
            "zeroRecords": "No matching records found",
            "paginate": {
                
                "last": "ultimo",
                "next": "proximo",
                "previous": "anterior"
            },
            "aria": {
                "orderable": "Order by this column",
                "orderableReverse": "Reverse order this column"
            }
        }
    })

    setTimeout(function () {
        $(".alert").fadeOut("slow", function () {
            $(this).alert('close');
        })
    }, 5000)


});