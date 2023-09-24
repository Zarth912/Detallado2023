using RawDeal._0._PreGame;
using RawDealView;
using RawDealView.Options;

namespace RawDeal._1._InGame;

public class GameFlow {
    private View _view;
    private Player _currentPlayer;
    private Player _otherPlayer;
    private CardVisualization _cardVisualization;
    private PlayCard _playCard;
    public GameFlow(Player currentPlayer, Player otherPlayer, View view) {
        _view = view;
        _currentPlayer = currentPlayer;
        _otherPlayer = otherPlayer;
        _cardVisualization = new CardVisualization(_view, _currentPlayer, _otherPlayer);
        _playCard = new PlayCard(_view, _currentPlayer, _otherPlayer);
        _view.SayThatATurnBegins(_currentPlayer.GetSuperStarName());
        _currentPlayer.DrawCardsfromArsenal(1);
    }
    
    public void Play() {
        ShowGameInfoInOrder();
        NextPlay option = _view.AskUserWhatToDoWhenHeCannotUseHisAbility();
        switch (option) {
            case NextPlay.ShowCards:
                bool correctVisualization = _cardVisualization.SeeCards();
                if (correctVisualization) { Play();}
                break;
            
            case NextPlay.PlayCard:
                _playCard.ShowValidCards();
                bool actionSelectedByPlayer = _playCard.AskCardToPlay();
                if (!actionSelectedByPlayer) {
                    Play();
                    break;
                }
                bool keepPlaying = _playCard.PlayCardSelected();
                if (!keepPlaying) {
                    _view.CongratulateWinner(_currentPlayer.GetSuperStarName());
                    break;
                }
                Play();
                break;
            
            case NextPlay.EndTurn :
                NextTurn();
                break;
            
            case NextPlay.GiveUp:
                _view.CongratulateWinner(_otherPlayer.GetSuperStarName());
                break;
            
            case NextPlay.UseAbility:
                break;
        }
    }
    
    private void NextTurn() {
        if (CheckCardsInArsenal()){
            GameFlow nextTurn = new GameFlow(_otherPlayer, _currentPlayer, _view);
            nextTurn.Play();
        }
    }

    private bool CheckCardsInArsenal() {
        if (_currentPlayer.GetArsenalCards().Any() && _otherPlayer.GetArsenalCards().Any()) {
            return true;
        }
        _view.CongratulateWinner(_otherPlayer.GetSuperStarName());
        return false;
    }
    
    private void ShowGameInfoInOrder() {
        PlayerInfo currentPlayerInfo = _currentPlayer!.UpdatePlayerInfo();
        PlayerInfo otherPlayerInfo = _otherPlayer!.UpdatePlayerInfo();
        _view.ShowGameInfo(currentPlayerInfo, otherPlayerInfo);
    }

}