// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function confirmDelete() {
    console.log("We are here");
    if (confirm("Are you sure you want to delete this record?")
    {
        window.Location.href = '@Url.Action("Delete", "Author", new {id = Model.Id})';
    })
}