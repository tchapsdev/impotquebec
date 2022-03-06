var tax_service = {

    init_declaration: function() {
        let taxFormId = $('#TaxFormId').val();
        console.log(taxFormId);
        httpservice.get(`TaxForms/${taxFormId}`, { id: taxFormId },
            function (result) {
                console.log(result);
            },
            function () {

            }
        )
    }
}



$(document).ready(function () {

    

})