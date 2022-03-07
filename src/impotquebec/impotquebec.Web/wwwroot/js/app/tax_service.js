var tax_service = {};
(function (tax_service) {

    tax_service.init_declaration = function () {
        let taxFormId = $('#TaxFormId').val();
        console.log(taxFormId);
        httpservice.get(`TaxForms/${taxFormId}`, { id: taxFormId },
            function (result) {
                renderDossierChangeList(result, LoadTaxWizard);
            },
            function () {

            }
        )
    };

    let renderDossierChangeList = function (taxForm, callBack) {
        let sections = taxForm.taxFormSections

        renderSectionWizardBlock(taxForm);

        for (let i = 0; i < sections.length; i++) {
            let section = sections[i];
            console.log(section.name + " " + section.rank);
            renderSectionWizardTitle(section);           
        }
               
        function renderSectionWizardTitle(section) {
            let target_id = "step_steps_block";
            let template = `<li data-step-target="step${section.rank}">${section.name}</li> `
            document.getElementById(target_id).innerHTML += template;
        }

        function renderSectionWizardBlock(taxForm) {
            let templateId = 'section-item-template';
            let target_id = 'step_content_block';
            mustacheRenderDataInTemplate(taxForm, templateId, target_id, true);
        }

        if (callBack && typeof callBack == 'function') {
            callBack();
        }
    };

    let LoadTaxWizard = function () {
        setTimeout(function () {
            console.log('calling step wizard...');
            $('#tax_wizard_block').steps({
                onFinish: function () {
                    alert('Wizard Completed');
                }
            }, 2000)
        });
    }

    /**
     * render Data In Template using Mustache
     * @param {object} data
     * @param {string} templateId
     * @param {string} targetId
     * @param {boolean} append
     */
    function mustacheRenderDataInTemplate(data, templateId, targetId, append) {
        if (!$(`#${templateId}`)[0]) {
            let errorMsg = `<p class='text-danger'>The TemplateId <strong>'${templateId}'</strong> does not exist. Can not render '${templateId}' in targetId '${targetId}'</p> `
            document.getElementById(targetId).innerHTML += errorMsg;
            return;
        }
        //debugger;
        let template = document.getElementById(templateId).innerHTML;
        let rendered = Mustache.render(template, { data: data });
        if (append === true)
            document.getElementById(targetId).innerHTML += rendered;
        else
            document.getElementById(targetId).innerHTML = rendered;
    }

    function validateFormId(formId) {
        let isValid = true;
        $(`#${formId} :input`).each(function () {
            // This is the jquery object of the input, do what you will
            let fieldId = $(this).attr('id');
            let req = $(this).attr('required');
            let value = $('#' + fieldId).val();
            if (req && (!value || value.length < 1)) {
                $('#' + fieldId).addClass('is-invalid');
                $('#' + fieldId).removeClass('is-valid');
                isValid = false;
                console.log(`The field '${fieldId}' in form '${formId}' is invalid`);
            } else {
                $('#' + fieldId).addClass('is-valid');
                $('#' + fieldId).removeClass('is-invalid');
            }
        });
        return isValid;
    }

    var steps = $('#tax_wizard_block').steps({
        showFooterButtons: false,
        onFinish: function () {
            alert('Wizard Completed');
        }
    });

    steps_api = steps.data('plugin_Steps');

    $('#btnPrev').on('click', function () {
        steps_api.prev();
    });

    $('#btnNext').on('click', function () {
        steps_api.next();
    });


})(tax_service);