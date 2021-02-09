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

// Sets the select inputs to the value from the last search
function setSelectValue(search) {
	document.getElementById("ethnicitySelect").value = search.ethnicity || ""
	document.getElementById("genderSelect").value = search.gender || ""
	document.getElementById("lunchSelect").value = search.lunch || ""
	document.getElementById("incomeSelect").value = search.income || ""
	document.getElementById("activeSelect").value = search.active || ""
	document.getElementById("schoolGradeSelect").value = search.schoolGrade || ""
	document.getElementById("yearsEnrolledSelect").value = search.yearsEnrolled || ""
	document.getElementById("schoolSelect").value = search.school || "Select School"
	document.getElementById("siteSelect").value = search.site || "Select KU Site"
	document.getElementById("sortOrderSelect").value = search.sortOrder || "0"
}