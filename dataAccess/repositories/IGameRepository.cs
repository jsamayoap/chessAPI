using chessAPI.dataAccess.models;
using chessAPI.models.Game;
using chessAPI.models.game;

namespace chessAPI.dataAccess.repositores;

public interface IGameRepository<TI, TC>
        where TI : struct, IEquatable<TI>
        where TC : struct
{
    Task<TI> addGame(clsNewGame game);
    Task<IEnumerable<clsGameEntityModel<TI, TC>>> addGame(IEnumerable<clsNewGame> game);
    Task<IEnumerable<clsGameEntityModel<TI,TC>>> getGame(TI playerid);
    Task updateGame(clsGame<TI> updatedGame);
    Task deleteGame(TI id);
}