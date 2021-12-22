window.global = {
    openModal: function (modalId) {
        modalId = '#' + modalId;
        $(modalId).modal('show');
    },
    closeModal: function (modalId) {
        modalId = '#' + modalId;
        $(modalId).modal('hide');
    },
    mostrarAlertaError: function(mensaje) {
        $.aceToaster.add({
            placement: 'tr',
            title: 'Error!',
            body: mensaje,

            icon: '<i class="text-danger mr-2 text-130">\
                        <i class="fas fa-exclamation-circle mt-25 fa-2x text-red"></i>\
                       </i>',
            iconClass: 'mt-3',

            delay: 5000,

            closeClass: 'btn btn-light-danger border-0 btn-bgc-tp btn-xs px-2 py-0 text-150 position-tr mt-n25',

            className: 'bgc-white-tp1 border-none border-t-4 brc-red-tp1 rounded-sm pl-3 pr-1',
            headerClass: 'bg-transparent border-0 text-120 text-danger-d3 font-bolder mt-3',
            bodyClass: 'pt-0 pb-3 text-105'
        })
    },
    mostrarAlertaExito: function (mensaje) {
        $.aceToaster.add({
            placement: 'tr',
            title: 'Acción exitosa!',
            body: mensaje,

            icon: '<i class="text-blue mr-2 text-130">\
                        <i class="fas fa-exclamation-circle mt-25 fa-2x text-blue"></i>\
                       </i>',
            iconClass: 'mt-3',

            delay: 5000,

            closeClass: 'btn btn-light-danger border-0 btn-bgc-tp btn-xs px-2 py-0 text-150 position-tr mt-n25',

            className: 'bgc-white-tp1 border-none border-t-4 brc-primary-tp1 rounded-sm pl-3 pr-1',
            headerClass: 'bg-transparent border-0 text-120 text-blue-d3 font-bolder mt-3',
            bodyClass: 'pt-0 pb-3 text-105'
        })
    }
}