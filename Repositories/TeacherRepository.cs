using Dapper;
using School.DTOs;
using School.Models;
using School.Utilities;

namespace School.Repositories;

public interface ITeacherRepository
{
    Task<Teacher> Create(Teacher Item);
    Task<bool> Update(Teacher Item);

    Task<List<Teacher>> GetList();
    Task<Teacher> GetById(int Id);
    Task<List<TeacherDTO>> GetListByTeacher(long StudentId);
}

public class TeacherRepository : BaseRepository, ITeacherRepository
{
    public TeacherRepository(IConfiguration config) : base(config)
    {

    }

    public async Task<Teacher> Create(Teacher Item)
    {
        var query = $@"INSERT INTO {TableNames.teacher} 
        (Teacher_name, gender, mobile, date_of_joining) 
        VALUES (@TeacherName, @Gender,@Mobile, @DateOfJoining) 
        RETURNING *";

        using (var con = NewConnection)
            return await con.QuerySingleAsync<Teacher>(query, Item);
    }



    public async Task<Teacher> GetById(int TeacherId)
    {
        var query = $@"SELECT * FROM {TableNames.teacher} WHERE Teacher_id = @TeacherId";

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Teacher>(query, new { TeacherId });
    }

    public async Task<List<Teacher>> GetList()
    {
        var query = $@"SELECT * FROM {TableNames.teacher}";

        using (var con = NewConnection)
            return (await con.QueryAsync<Teacher>(query)).AsList();
    }

    public async Task<List<TeacherDTO>> GetListByTeacher(long StudentId)
    {
        var query = $@"SELECT t.*, s.subject_name AS subject_name FROM {TableNames.student_teacher} st 
        LEFT JOIN {TableNames.teacher} t ON t.teacher_id = st.teacher_id
        LEFT JOIN {TableNames.subjects} s ON s.subject_id = t.subject_id
        WHERE st.student_id = @StudentId";

        using (var con = NewConnection)
        {

            return (await con.QueryAsync<TeacherDTO>(query, new { StudentId })).AsList();
        }



    }

    public async Task<bool> Update(Teacher Item)
    {
        var query = $@"UPDATE {TableNames.teacher} 
        SET Teacher_name = @TeacherName, mobile = @Mobile WHERE Teacher_id = @TeacherId";

        using (var con = NewConnection)
            return await con.ExecuteAsync(query, Item) > 0;
    }
}