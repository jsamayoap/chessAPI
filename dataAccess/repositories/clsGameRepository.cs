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
        p.Add(@started, game.started)
        p.Add(@whites, game.whites);
        P.Add(@blacks, game.blacks);
        p.Add(@turn, game.turn);
        p.Add(@winner,game.winner);
        return await add<TI>(p).ConfigureAwait(false);
    }

    public async Task<IEnumerable<clsGameEntityModel<TI, TC>>> addGame(IEnumerable<clsNewGame> game)
    {
        var r = new List<clsGameEntityModel<TI, TC>>(games.Count());
        foreach (var game in games)
        {
            TI gameId = await addGame(game).ConfigureAwait(false);
            r.Add(new clsGameEntityModel<TI, TC>() { id = gameId, started = game.started, whites = game.whites, blacks = game.blacks,
            turn = game.turn, winner = game.winner});
        }
    }

    public Task deleteGame(TI id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<clsGameEntityModel<TI,TC>>> getGame(TI id)
    {
        var p = new DynamicParameters();
        return await getALL(p).ConfigureAwait(false);

    }

    public Task updateGame(clsGame<TI> updatedGame)
    {
        throw new NotImplementedException();
    }


    protected override DynamicParameters fieldsAsParams(clsGameEntityModel<TI, TC> entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        var p = new DynamicParameters();
        p.Add("ID", entity.id);
        p.Add(@started, entity.started)
        p.Add(@whites, entity.whites);
        P.Add(@blacks, entity.blacks);
        p.Add(@turn, entity.turn);
        p.Add(@winner,entity.winner);
        return p;
    }

    protected override DynamicParameters keyAsParams(TI key)
    {
        var p = new DynamicParameters();
        p.Add("ID", key);
        return p;
    }
}