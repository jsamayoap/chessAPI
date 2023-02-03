using chessAPI.dataAccess.models;
using chessAPI.models.Game;

namespace chessAPI.dataAccess.repositores;

public interface IGameRepository<TI, TC>
        where TI : struct, IEquatable<TI>
        where TC : struct
{
    Task<TI> addGame(clsGame game);
    Task<IEnumerable<clsGameEntityModel<TI, TC>>> addGame(IEnumerable<clsGame> game);
    Task<IEnumerable<clsGameEntityModel<TI,TC>>> getGame(TI playerid)
    Task updateGame(clsGamer<TI> updatedGame);
    Task deleteGame(TI id);
}