﻿namespace Demo.Presentation.ViewModels
{
    public class DepartmentEditViewModel
    {
        public string Code { get; set; }= string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateOnly CreatedOn { get; set; }
    }
}
