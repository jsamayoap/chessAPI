namespace chessAPI.models.game;

public sealed class clsNewGame
{
    public clsNewGame()
    {
        started = "00:00",
        whites = 0;
        blacks = 0;
        turn = false;
        winner = 0;
    }

    public time started { get; set; }
    public int whites { get; set; }
    public int blacks { get; set; }
    public bool turn { get; set; }
    public int winner { get; set; }
}