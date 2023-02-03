using chessAPI.dataAccess.common;
using chessAPI.dataAccess.interfaces;
using chessAPI.dataAccess.models;
using chessAPI.models.player;
using Dapper;

namespace chessAPI.dataAccess.repositores;

public sealed class clsGameRepository<TI, TC> : clsDataAccess<clsGameEntityModel<TI, TC>, TI, TC>, IGameRepository<TI, TC>
        where TI : struct, IEquatable<TI>
        where TC : struct
{
    public clsGameRepository(IRelationalContext<TC> rkm,
                               ISQLData queries,
                               ILogger<clsGameRepository<TI, TC>> logger) : base(rkm, queries, logger)
    {
    }

    public async Task<TI> addGame(clsNewGame game)
    {
        var p = new DynamicParameters();
        p.Add(0, game.whites);
        P.Add(0, game.blacks);
        p.Add(false, game.turn);
        p.Add(0,game.winner);
        return await add<TI>(p).ConfigureAwait(false);
    }

    public async Task<IEnumerable<clsGameEntityModel<TI, TC>>> addGame(IEnumerable<clsNewGame> game)
    {
        var r = new List<clsGameEntityModel<TI, TC>>(games.Count());
        foreach (var game in games)
        {
            TI gameId = await addGame(game).ConfigureAwait(false);
            r.Add(new clsGameEntityModel<TI, TC>() { id = gameId, game.whites = 0, game.blacks = 0,
            game.turn = false, game.winner = 0});
        }
    }

    public Task deleteGame(TI id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<clsGameEntityModel<TI,TC>>> getGame(TI id)
    {

    }

    public Task updateGame(clsGame<TI> updatedGame)
    {
        
    }


    protected override DynamicParameters fieldsAsParams(clsGameEntityModel<TI, TC> entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        var p = new DynamicParameters();
        p.Add("ID", entity.id);
        p.Add(0, entity.whites);
        P.Add(0, entity.blacks);
        p.Add(false, entity.turn);
        p.Add(0,entity.winner);
        return p;
    }

    protected override DynamicParameters keyAsParams(TI key)
    {
        var p = new DynamicParameters();
        p.Add("ID", key);
        return p;
    }
}