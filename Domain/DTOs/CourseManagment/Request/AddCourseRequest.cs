﻿using Domain.DTOs.Base.Response;
using Domain.Enums;

namespace Domain.DTOs.CourseManagment.Request
{
    public class AddCourseRequest
    {
        public AddCourseRequest()
        {
            CourseType = new SelectModel();
            PreRequireds = new List<SelectModel>();
        }
        public string CourseName { get; set; }
        public string CourseNo { get; set; }
        public string CourseCode { get; set; }
        public int UnitCount { get; set; }
        public IList<SelectModel> PreRequireds { get; set; }
        public SelectModel CourseType { get; set; }
    }
}
