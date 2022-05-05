    paging: function(totalRow, callback) {
        var totalPage = Math.ceil(totalRow/8)
    $('#pagination').twbsPagination({
        totalPages: totalPage,
    visiblePages: 8,
    onPageClick: function (event, page) {
     homeController.LoadData();
            }
        });
    }
LoadData: function() {
    $.ajax({
        url: '/Search/Index',
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            if (response.status) {
                var data = response.data;
                var html = '';
                var template = $()
            }
        }
    })
}