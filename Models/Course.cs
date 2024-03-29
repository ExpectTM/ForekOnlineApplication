﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ForekOnlineApplication.Enums.Enums;

namespace ForekOnlineApplication.Models
{
    public class Course
    {
        [Key]
        public Guid CourseId { get; set; }

        [ForeignKey("Person")]
        public Guid? PersonId { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public string CourseType { get; set; }
        public string NQL { get; set; }
        public string Modules { get; set; }

    }
}
