// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



$(document).ready(function () {
   
    getDataTable('#table-padrao');
    getDataTable('#table-user');
});

function getDataTable(id)

{
    $(document).ready(function () {
        $(id).DataTable();
    });

}

$('.close-alert').click(function () {
    $('.alert').hide('hide');

});
