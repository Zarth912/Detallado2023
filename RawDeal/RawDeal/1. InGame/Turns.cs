using RawDeal._0._PreGame;

namespace RawDeal._1._InGame;

public class Turns  {
    private Player _player1;
    private Player _player2;
    private Player _currentPlayer;
    
    public Turns(Player player1, Player player2) {
        _player1 = player1;
        _player2 = player2;
    }

    public Player FirstPlayer() {
        int handSizePlayer1 = _player1.GetInitialHandSize();
        int handSizePlayer2 = _player2.GetInitialHandSize();
        if (handSizePlayer1 >= handSizePlayer2) 
            return _player1;
        return _player2;
    }
    
    public Player SecondPlayer() {
        if (_currentPlayer == _player2) 
            return _player1;
        return _player2;
    }

    public Player ChangeCurrentPlayer(Player player) {
        if (_player1 == player)
            return _player2;
        return _player1;
    }
}
