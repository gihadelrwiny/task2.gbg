using Microsoft.EntityFrameworkCore;
using StudentGradeManagementSystem.Data;
using WebApplication3.Service;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider
        .GetRequiredService<SystemContext>();

    SeedData.Initialize(context);

    var studentService = new StudentService(context);

    var courseService = new CourseService(context);

    var enrollmentService = new EnrollmentService(context);



    // =========================
    // STUDENT OPERATIONS
    // =========================

    studentService.AddStudent(new Student
    {
        Name = "Ahmed",
        Email = "ahmed@gmail.com",
        DateOfBirth = new DateTime(2003, 5, 10)
    });

    studentService.AddStudent(new Student
    {
        Name = "Sara",
        Email = "sara@gmail.com",
        DateOfBirth = new DateTime(2004, 7, 20)
    });

    var students = studentService.GetAllStudents();

    foreach (var student in students)
    {
        Console.WriteLine(student.Name);
    }

    var studentById = studentService.GetStudentById(1);

    if (studentById != null)
    {
        Console.WriteLine(studentById.Name);

        studentById.Name = "Ahmed Mohamed";

        studentService.UpdateStudent(studentById);
    }

    studentService.DeleteStudent(2);



    // =========================
    // COURSE OPERATIONS
    // =========================

    courseService.AddCourse(new Course
    {
        Title = "Database",
        MaxStudents = 30,
        InstructorName = "Dr.Ahmed"
    });

    courseService.AddCourse(new Course
    {
        Title = "Algorithms",
        MaxStudents = 25,
        InstructorName = "Dr.Mona"
    });

    var courses = courseService.GetAllCourses();

    foreach (var course in courses)
    {
        Console.WriteLine(course.Title);
    }

    var courseById = courseService.GetCourseById(1);

    if (courseById != null)
    {
        Console.WriteLine(courseById.Title);

        courseById.Title = "Advanced Database";

        courseService.UpdateCourse(courseById);
    }

    courseService.DeleteCourse(2);



    // =========================
    // ENROLLMENT OPERATIONS
    // =========================

    enrollmentService.EnrollStudent(1, 1);

    enrollmentService.EnrollStudent(1, 2);

    enrollmentService.GetCoursesForStudent(1);

    enrollmentService.GetStudentsInCourse(1);



    // =========================
    // GRADE OPERATIONS
    // =========================

    enrollmentService.AssignGrade(
        1,
        new Grade
        {
            Score = 95,
            GradedAt = DateTime.Now
        }
    );

    enrollmentService.AssignGrade(
        2,
        new Grade
        {
            Score = 88,
            GradedAt = DateTime.Now
        }
    );




    enrollmentService.GetAverageGrades();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
