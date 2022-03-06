var tax_service = {};
(function (tax_service) {

    tax_service.init_declaration = function () {
        let taxFormId = $('#TaxFormId').val();
        console.log(taxFormId);
        httpservice.get(`TaxForms/${taxFormId}`, { id: taxFormId },
            function (result) {
                renderDossierChangeList(result);
            },
            function () {

            }
        )
    };

    let renderDossierChangeList = function (taxForm) {
        let sections = taxForm.taxFormSections
        for (let i = 0; i < sections.length; i++) {
            let section = sections[i];
            renderSectionWizardTitle(section);           
        }

        renderSectionWizardBlock(taxForm);

        function renderSectionWizardTitle(section) {
            let target_id = "step_steps_block";
            let template = `<li data-step-target="step${section.rank}">${section.name}</li> `
            document.getElementById(target_id).innerHTML += template;
        }

        function renderSectionWizardBlock(section) {
            let templateId = 'section-item-template';
            let target_id = 'step_content_block';
            mustacheRenderDataInTemplate(section, templateId, target_id, true);
        }
    };

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


})(tax_service);