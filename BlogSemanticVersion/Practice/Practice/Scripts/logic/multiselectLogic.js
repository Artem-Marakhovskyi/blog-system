$(document).ready(function () {
    $('#example-selectAllName').multiselect({
        includeSelectAllOption: true,
        selectAllName: 'select-all-name',
        enableFiltering: true,
        filterBehavior: 'value'
    });
});