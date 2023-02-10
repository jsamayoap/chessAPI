namespace chessAPI.dataAccess.queries.postgreSQL;

public sealed class qTeam : IQTeam
{

    private const string _selectAll = @"
    SELECT id, name, created_at
    FROM public.team";

    private const string _selectOne =
  @"IF EXISTS(SELECT id)
    FROM public.team
     RETURNING id
    ELSE 
     RETURNING 404";

    public string SQLGetAll => _selectAll;

    public string SQLDataEntity => _selectOne;

    public string NewDataEntity => throw new NotImplementedException();

    public string DeleteDataEntity => throw new NotImplementedException();

    public string UpdateWholeEntity => throw new NotImplementedException();
}