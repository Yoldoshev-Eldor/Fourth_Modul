﻿using OnlineLearningPlatform.DataAccess.Enums;

namespace OnlineLearningPlatform.DataAccess.Entities;

public class User
{
    public long UserId { get; set; }
    public string Name  { get; set; }
    public string Email  { get; set; }
    public UserRole Role { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; }
    public ICollection<Course> Courses { get; set; }

}
