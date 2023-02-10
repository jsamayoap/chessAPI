using chessAPI.dataAccess.common;
using chessAPI.dataAccess.interfaces;
using chessAPI.dataAccess.models;
using chessAPI.models.Game;
using chessAPI.models.game;
using Dapper;
using System.Net;

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

    //POST
    public async Task<TI> addGame(clsNewGame game)
    {
       
        var p = new DynamicParameters();
        p.Add("Started", game.started);
        p.Add("Whites", game.whites);
        p.Add("Blacks", game.blacks);
        p.Add("Turn", game.turn);
        p.Add("Winner", game.winner);
        return await add<TI>(p).ConfigureAwait(false);
    }

     //POST VARIOS
    public async Task<IEnumerable<clsGameEntityModel<TI, TC>>> addGame(IEnumerable<clsNewGame> games)
    {
        var r = new List<clsGameEntityModel<TI, TC>>(games.Count());
        foreach (var game in games)
        {
            TI gameId = await addGame(game).ConfigureAwait(false);
            r.Add(new clsGameEntityModel<TI, TC>() { id = gameId, started = game.started, whites = game.whites, blacks = game.blacks,
            turn = game.turn, winner = game.winner});
        }
        return r;
    }

    public Task deleteGame(TI id)
    {
        throw new NotImplementedException();
    }

    //GET 
    public async Task<IEnumerable<clsGameEntityModel<TI,TC>>> getGame(TI id)
    {
        var p = new DynamicParameters();
        return await getALL(p).ConfigureAwait(false);

    }
    
    //PUT
    public Task updateGame(clsGame<TI> updatedGame)
    {
        throw new NotImplementedException();
    }


    protected override DynamicParameters fieldsAsParams(clsGameEntityModel<TI, TC> entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        var p = new DynamicParameters();
        p.Add("ID", entity.id);
        p.Add("Started", entity.started);
        p.Add("Whites", entity.whites);
        p.Add("Blacks", entity.blacks);
        p.Add("Turn", entity.turn);
        p.Add("Winner",entity.winner);
        return p;
    }

    protected override DynamicParameters keyAsParams(TI key)
    {
        var p = new DynamicParameters();
        p.Add("ID", key);
        return p;
    }
}