using RawDeal._0._PreGame;
using RawDeal._0._PreGame.Cards;
using RawDealView;
using RawDealView.Formatters;

namespace RawDeal._1._InGame;

public class PlayCard {
    private View _view;
    private Player _currentPlayer;
    private Player _otherPlayer;
    private List<string> _posibleCardToPlays;
    private int _playAction;
    private List<Card> _validCards;
    private ValidCardsToPlay _validationOfCards;

    public PlayCard(View view, Player currentPlayer, Player otherPlayer) {
        _view = view;
        _currentPlayer = currentPlayer;
        _otherPlayer = otherPlayer;
        _validationOfCards = new ValidCardsToPlay(_currentPlayer);
    }

    public void ShowValidCards() {
        List<Card> cardsInHand = _currentPlayer.GetHandCards();
        _validCards = _validationOfCards.GetValidCardsToPlay(cardsInHand);
        List<PlayInfo> playCardsInfo = _validationOfCards.ChangeCardInfoToPlayInfo(_validCards);
        _posibleCardToPlays = _validationOfCards.FormatterCardsToShow(playCardsInfo);
        
    }

    public bool AskCardToPlay() {
        int idAction = _view.AskUserToSelectAPlay(_posibleCardToPlays);
        int backToMenu = -1;
        if (idAction == backToMenu)
            return false;
        _playAction = idAction;
        return true;
    }

    public bool PlayCardSelected() {
        Card cardToPlay = _validCards[_playAction];
        int damage = cardToPlay.GetDamage();
        _currentPlayer.ChangeFortitude(damage);
        _currentPlayer.PlayCardIfValid(cardToPlay);
        bool validPlay = PrintPlayInformation(damage, cardToPlay);
        return validPlay;
    }

    private bool PrintPlayInformation(int totalDamage, Card cardToPlay) {
        string playInfo = ChangeCardToPlay(cardToPlay);
        _view.SayThatPlayerIsTryingToPlayThisCard(_currentPlayer.GetSuperStarName(), playInfo);
        _view.SayThatPlayerSuccessfullyPlayedACard();
        _view.SayThatSuperstarWillTakeSomeDamage(_otherPlayer.GetSuperStarName(), totalDamage);
        bool allCardsWhereTakenFromOtherPlayer = PrintDiscardCardsFromOtherPlayer(totalDamage);
        return allCardsWhereTakenFromOtherPlayer;
    }

    private bool PrintDiscardCardsFromOtherPlayer(int totalDamage) {
        for (int currentDamage = 1; currentDamage <= totalDamage; currentDamage++) {
            if (!AreCardsLeftInArsenal()) {return false;}
            Card cardToDiscard = _otherPlayer.GetTopArsenalCard();
            string stringCardFromOtherPlayer = ChangeCardToString(cardToDiscard.GetCardInfo());
            _view.ShowCardOverturnByTakingDamage(stringCardFromOtherPlayer, currentDamage, totalDamage);
        }
        return true;
    }

    private bool AreCardsLeftInArsenal() {
        int cantCardsInArsenal = _otherPlayer.GetArsenalCards().Count();
        if (cantCardsInArsenal > 0) {return true;}
        return false;
    }
    
    private string ChangeCardToPlay(Card card) {
        string cardType = card.GetTypes()[0];
        PlayInfo playInfo = new PlayInfo(card.GetCardInfo(), cardType.ToUpper());
        string cardString = Formatter.PlayToString(playInfo);
        return cardString;
    }
    
    private string ChangeCardToString(CardInfo card) {
        string cardString = Formatter.CardToString(card);
        return cardString;
    }
}