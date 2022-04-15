var contact = {
    init: function () {
        contact.registerEvents();
    },
    registerEvents: function () {
        $('#btnSend').off('click').on('click', function () {
            var name = $('#txtName').val();
            var phone = $('#txtPhone').val();
            var addpress = $('#txtAddpress').val();
            var email = $('#txtEmail').val();
            var content = $('#txtContent').val();

            $.ajax({
                url: '/Contact/Send',
                type: 'POST',
                dataType: 'json',
                data: {
                    name = name,
                    phone = phone,
                    addpress =addpress,
                    email = email,
                    content = content,
                },
                success: function (res) {
                    if (res.status == true) {
                        alert('SUCCESS');
                        contact..resetForm();
                    }
                }
            });
        });
    },
    resetForm: function () {
         $('#txtName').val('');
       $('#txtPhone').val('');
        $('#txtAddpress').val('');
        $('#txtEmail').val('');
       $('#txtContent').val('');
    }
}
contact.init();