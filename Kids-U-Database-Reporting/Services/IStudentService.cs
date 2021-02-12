﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kids_U_Database_Reporting.Models;

namespace Kids_U_Database_Reporting.Services
{
    public interface IStudentService
    {
        //student CRUD operations
        Task<Student[]> GetStudentsAsync();
        Task<Student[]> GetStudentsAsync(Search search);
        Task<Student[]> GetStudentsWithReportCardsAsync(Search searchData);
        Task<Student> GetStudentById(int Id);
        Task<Student> EditStudentAsync(int Id);
        Task<bool> ApplyEditStudentAsync(Student editedStudent);
        Task<bool> DeleteStudentAsync(int Id);
        Task<bool> AddStudentAsync(Student newStudent);

        //report card CRUD operations
        Task<ReportCard[]> GetReportCardsAsync(int Id);
        Task<ReportCard> GetReportCardAsync(int Id);
        Task<bool> SubmitNewReportCardAsync(ReportCard newReportCard);
        Task<bool> ApplyEditReportCardAsync(ReportCard editedReportCard);

        //outcome measurement CRUD operations
        Task<OutcomeMeasurement[]> GetOutcomesAsync(int Id);
        Task<OutcomeMeasurement> GetOutcomeAsync(int Id);
        Task<bool> SubmitNewOutcomeAsync(OutcomeMeasurement newOutcomeMeasurement);
        Task<bool> ApplyEditOutcomeAsync(OutcomeMeasurement editedOutcomeMeasurement);
    }
}
