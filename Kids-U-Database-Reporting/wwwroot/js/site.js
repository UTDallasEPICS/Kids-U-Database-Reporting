// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function showHide() {
	var x = document.getElementById("advancedSearch");
	if (x.style.display === "none" || x.style.display === "") {
		x.style.display = "grid";
	} else {
		x.style.display = "none";
	}
}

function setSelectValue(selectedEthnicity) {
	document.getElementById("ethnicitySelect").value = selectedEthnicity
}