using RawDeal._0._PreGame;
using RawDeal._0._PreGame.Cards;
using RawDealView;
using RawDealView.Formatters;
using RawDealView.Options;

namespace RawDeal._1._InGame;

public class CardVisualization
{
    private View _view;
    private Player _currentPlayer;
    private Player _otherPlayer;
    
    public CardVisualization(View view, Player currentPlayer, Player otherPlayer)
    {
        _view = view;
        _currentPlayer = currentPlayer;
        _otherPlayer = otherPlayer;
    }
    
    public bool SeeCards() {
        CardSet cardSet = _view.AskUserWhatSetOfCardsHeWantsToSee();
        switch (cardSet) {
            case CardSet.Hand:
                return ShowHandCards();
                break;
            case CardSet.RingArea:
                return ShowRingAreaCards(_currentPlayer);
                break;
            case CardSet.RingsidePile:
                return ShowRingSideCards(_currentPlayer);
                break;
            case CardSet.OpponentsRingArea:
                return ShowRingAreaCards(_otherPlayer);
                break;
            case CardSet.OpponentsRingsidePile:
                return ShowRingSideCards(_otherPlayer);
                break;
        }
        return false;
    }
    
    private bool ShowHandCards() {
        List<Card> cardsInHand = _currentPlayer.GetHandCards();
        List<string> cards = FormatterCardsToShow(cardsInHand);
        _view.ShowCards(cards);
        return true;
    }
    
    private bool ShowRingAreaCards(Player player) {
        List<Card> cardsInRing = player.GetRingAreaCards();
        List<string> cards = FormatterCardsToShow(cardsInRing);
        _view.ShowCards(cards);
        return true;
    }
    
    private bool ShowRingSideCards(Player player) {
        List<Card> cardsInRing = player.GetRingSideCards();
        List<string> cards = FormatterCardsToShow(cardsInRing);
        _view.ShowCards(cards);
        return true;
    }
    
    private List<string> FormatterCardsToShow(List<Card> cardsList) {
        List<string> cards = new List<string>();
        foreach (var card in cardsList) {
            string cardString = Formatter.CardToString(card.GetCardInfo());
            cards.Add(cardString);
        }
        return cards;
    }
}