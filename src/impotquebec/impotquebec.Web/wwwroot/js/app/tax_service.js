﻿var tax_service = {};
(function (tax_service) {

    let taxFormModel = {};

    tax_service.init_declaration = function () {
        let taxFormId = $('#TaxFormId').val();
        console.log(taxFormId);
        httpservice.get(`TaxForms/${taxFormId}`, { id: taxFormId },
            function (result) {
                taxFormModel = result;
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
                onChange: function (currentIndex, newIndex, stepDirection) {
                   
                    if (stepDirection === 'forward') {
                        let tab_id = $(`#tab_step_${++currentIndex}`).attr('id');
                        return validateFormId(tab_id);
                    }                      
                    
                    return true;
                },
                onFinish: function () {
                    saveDeclarationForm();
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
                //$('#' + fieldId).addClass('is-valid');
                $('#' + fieldId).removeClass('is-invalid');
            }
        });
        return isValid;
    }

    $(document).ready(function () {                

        $('.step-btn').on('click', function (e) {
            e.preventDefault();

            var steps = $('#tax_wizard_block').steps();
            let steps_api = steps.data('plugin_Steps');
            var idx = steps_api.getStepIndex();
            let tab_id = $(`#tab_step_${++idx}`).attr('id');
            if (validateFormId(tab_id)) {
                return;
                console.log(`Data not valid .`);
            }

            let action = $(this).attr('data-step-action');
            console.log(action);
            
            console.log(idx);
            steps_api.prev();

            

            getTaxFormData();
        });

    })

    function saveDeclarationForm() {
        var declaration = getTaxFormData();
    }

    function getTaxFormData() {
        let sections = taxFormModel.taxFormSections;

        let details = [];

        let declarationId = $('#DeclarationId').val();

        for (let i = 0; i < sections.length; i++) {
            let section = sections[i];
            for (let j = 0; j < section.taxFormLines.length; j++) {
                let taxFormLine = section.taxFormLines[j];
                taxFormLine.value = $(`#id_${taxFormLine.taxFormLineId}`).val();
                let detail = {
                    declarationId: declarationId,
                    declarationDetailId: 0,
                    taxFormLineId: taxFormLine.taxFormLineId,
                    LineNumber: taxFormLine.lineNumber,
                    value: taxFormLine.value
                }
                details.push(detail);
            }
            console.log(section);

        //      public int DeclarationId { get; set; }
        //public float DeclarationDetailId { get; set; }
        //public int TaxFormLineId { get; set; }
        //public float LineNumber { get; set; }
        //public string Value { get; set; }
        }

        return {
            declarationId: declarationId,
            taxFormId: taxFormModel.taxFormId,           
            fiscalYear: $('#FiscalYear').val(),
            userId: $('#UserId').val(),
            taxForm: taxFormModel,
            details: details
        }
    }


})(tax_service);