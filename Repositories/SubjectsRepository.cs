using Dapper;
using School.DTOs;
using School.Models;
using School.Utilities;

namespace School.Repositories;

public interface ISubjectsRepository
{
  
   
  
    Task<List<Subjects>> GetList();
    Task<Subjects> GetById(int Id);
    Task<List<SubjectsDTO>>GetListBySubjects(long StudentId);
}

public class SubjectsRepository : BaseRepository, ISubjectsRepository
{
    public SubjectsRepository(IConfiguration config) : base(config)
    {

    }

  public async Task<Subjects> GetById(int SubjectId)
    {
        var query = $@"SELECT * FROM {TableNames.subjects} WHERE Subject_id = @SubjectId";

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Subjects>(query, new { SubjectId });
    }

    public async Task<List<Subjects>> GetList()
    {
        var query = $@"SELECT * FROM {TableNames.subjects}";

        using (var con = NewConnection)
            return (await con.QueryAsync<Subjects>(query)).AsList();
    }

    public async Task<List<SubjectsDTO>> GetListBySubjects(long StudentId)
    {
         var query = $@"SELECT * FROM {TableNames.student_subject} ss 
        LEFT JOIN {TableNames.subjects} s ON s.subject_id = ss.subject_id
         WHERE ss.student_id = @StudentId";

        using (var con = NewConnection)
        {
           // var ids =(await con.QueryAsync(query, new { Id })).AsList();
           // query = $@"SELECT * FROM {TableNames.teacher} WHERE id = {ids}";
            return (await con.QueryAsync<SubjectsDTO>(query, new { StudentId })).AsList();
     }

    }
}