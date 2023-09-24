using RawDeal._0._PreGame;
using RawDeal._0._PreGame.Cards;
using RawDealView.Formatters;

namespace RawDeal._1._InGame;

public class ValidCardsToPlay
{
    private Player _currentPlayer;
    
    public ValidCardsToPlay(Player currentPlayer)
    {
        _currentPlayer = currentPlayer;
    }
    
    public List<Card> GetValidCardsToPlay(List<Card> cards) {
        List<Card> validCards = new List<Card>();
        foreach (var card in cards) {
            if (CheckIfCardIsValid(card)) {
                validCards.Add(card);
            }
        }
        return validCards;
    }

    private bool CheckIfCardIsValid(Card cardInfo) {
        return (CheckFortitud(cardInfo) && CheckValidType(cardInfo));
    }
    
    private bool CheckFortitud(Card card) {
        int fortitude = card.GetFortitude();
        int fortitudePlayer = _currentPlayer.GetFortitude();
        if (fortitude > fortitudePlayer)
            return false;
        return true;
    }
    
    private bool CheckValidType(Card card) {
        List<string> types = card.GetTypes();
        bool hasOneType = CheckOnlyOneTypePerCard(types);
        bool hasValidType = CheckValidTypePerCard(types);
        return (hasOneType && hasValidType);
    }

    private bool CheckOnlyOneTypePerCard(List<string> types) {
        int cantOfTypes = types.Count;
        int cantAllowedOfTypes = 1;
        if (cantOfTypes == cantAllowedOfTypes)
            return true;
        return false;
    }
    
    private bool CheckValidTypePerCard(List<string> types) {
        string maneuverType = "Maneuver";
        string actionType = "Action";
        foreach (var type in types) {
            if ((type != maneuverType) && (type != actionType))
                return false;
        }
        return true;
    }

    public List<PlayInfo> ChangeCardInfoToPlayInfo(List<Card> validCards) {
        List<PlayInfo> playInfos = new List<PlayInfo>();
        foreach (var card in validCards) {
            string cardType = card.GetTypes()[0];
            PlayInfo playInfo = new PlayInfo(card.GetCardInfo(), cardType.ToUpper());
            playInfos.Add(playInfo);
        }
        return playInfos;
    }
    
    public List<string> FormatterCardsToShow(List<PlayInfo> playList) {
        List<string> plays = new List<string>();
        foreach (var cardInfo in playList) {
            string cardString = Formatter.PlayToString(cardInfo);
            plays.Add(cardString);
        }
        return plays;
    }
}