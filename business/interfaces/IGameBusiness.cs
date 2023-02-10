using chessAPI.models.game;
using chessAPI.models.Game;

namespace chessAPI.business.interfaces;

public interface IGameBusiness<TI> 
    where TI : struct, IEquatable<TI>
{
    Task<clsGame<TI>> addGame(clsNewGame newGame);
}