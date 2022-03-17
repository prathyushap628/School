using Dapper;
using School.Models;
using School.Utilities;

namespace School.Repositories;

public interface IStudentRepository
{
    Task<Student> Create(Student Item);
    Task<bool> Update(Student Item);
   
    Task<List<Student>> GetList();
    Task<Student> GetById(int Id);
}

public class StudentRepository : BaseRepository, IStudentRepository
{
    public StudentRepository(IConfiguration config) : base(config)
    {

    }

    public async Task<Student> Create(Student Item)
    {
        var query = $@"INSERT INTO {TableNames.student} 
        (Student_name, gender, date_of_birth,  parent_mobile, class_id) 
        VALUES (@StudentName, @Gender, @DateOfBirth,@ParentMobile, @ClassId) 
        RETURNING *";

        using (var con = NewConnection)
            return await con.QuerySingleAsync<Student>(query, Item);
    }



    public async Task<Student> GetById(int StudentId)
    {
        var query = $@"SELECT * FROM {TableNames.student} WHERE Student_id = @StudentId";

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Student>(query, new { StudentId });
    }

    public async Task<List<Student>> GetList()
    {
        var query = $@"SELECT * FROM {TableNames.student}";

        using (var con = NewConnection)
            return (await con.QueryAsync<Student>(query)).AsList();
    }

    public async Task<bool> Update(Student Item)
    {
        var query = $@"UPDATE {TableNames.student} 
        SET Student_name = @StudentName, parent_mobile = @ParentMobile WHERE Student_id = @StudentId";

        using (var con = NewConnection)
            return await con.ExecuteAsync(query, Item) > 0;
    }
}