// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const form = document.getElementById("employee-form");
function showForm() {
    if (form.style.display == "none") {
        form.style.display = "inherit";
    }

    else {

        form.style.display = "none";
    }
}
