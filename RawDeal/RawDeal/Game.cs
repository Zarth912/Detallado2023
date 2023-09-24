using RawDeal._0._PreGame;
using RawDeal._1._InGame;
using RawDealView;

namespace RawDeal;

public class Game
{
    private readonly View _view;
    private readonly string _deckFolder;
    private CreatePlayer _createPlayer;
    private Player? _player1;
    private Player? _player2;
    private Turns _turns;
    private Player _currentPlayer;
    private Player _otherPlayer;
    
    public Game(View view, string deckFolder) {
        _view = view;
        _deckFolder = deckFolder;
        _createPlayer = new CreatePlayer(_view, _deckFolder);
    }

    public void Play() {
        _player1 = _createPlayer.Create();
        if (!_createPlayer.ValidPlayer(_player1))
            return;
        _player2 = _createPlayer.Create();
        if (!_createPlayer.ValidPlayer(_player2))
            return;
        PlayMenu();
    }
    
    private void PlayMenu() {
        SetInitialTurns();
        GameFlow gameFLow = new GameFlow(_currentPlayer, _otherPlayer, _view);
        gameFLow.Play();
    }
    
    private void SetInitialTurns() {
        _turns = new Turns(_player1!, _player2!);
        _currentPlayer = _turns.FirstPlayer();
        _otherPlayer = _turns.SecondPlayer();
    }
}