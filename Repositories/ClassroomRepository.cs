using Dapper;
using School.Models;
using School.Utilities;

namespace School.Repositories;

public interface IClassroomRepository
{


    Task<List<Classroom>> GetList();
    Task<Classroom> GetById(int Id);
}

public class ClassroomRepository : BaseRepository, IClassroomRepository
{
    public ClassroomRepository(IConfiguration config) : base(config)
    {

    }
    public async Task<Classroom> GetById(int ClassId)
    {
        var query = $@"SELECT * FROM {TableNames.classroom} WHERE Class_id = @ClassId";

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Classroom>(query, new { ClassId });
    }

    public async Task<List<Classroom>> GetList()
    {
        var query = $@"SELECT * FROM {TableNames.classroom}";

        using (var con = NewConnection)
            return (await con.QueryAsync<Classroom>(query)).AsList();
    }


}