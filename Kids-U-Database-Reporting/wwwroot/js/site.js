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
function setSelectValue(selectedEthnicity, selectedGender, selectedSchool, selectedLunch, selectedIncome, selectedActive, selectedSchoolGrade, selectedYearsEnrolled, selectedSite) {
	document.getElementById("ethnicitySelect").value = selectedEthnicity
	document.getElementById("genderSelect").value = selectedGender
	document.getElementById("schoolSelect").value = selectedSchool
	document.getElementById("lunchSelect").value = selectedLunch
	document.getElementById("incomeSelect").value = selectedIncome
	document.getElementById("activeSelect").value = selectedActive
	document.getElementById("schoolGradeSelect").value = selectedSchoolGrade
	document.getElementById("yearsEnrolledSelect").value = selectedYearsEnrolled
	document.getElementById("siteSelect").value = selectedSite
}