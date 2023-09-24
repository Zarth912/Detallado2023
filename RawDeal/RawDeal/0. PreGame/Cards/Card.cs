namespace RawDeal._0._PreGame.Cards;

public class Card {
    private CardInfo _cardInfo;
    
    public Card(CardInfo cardInfo)
        => _cardInfo = cardInfo;

    public int GetDamage() {
        return _cardInfo.Damage != "#" ? Convert.ToInt32(_cardInfo.Damage) : 0;
    }

    public int GetFortitude() {
        return Convert.ToInt32(_cardInfo.Fortitude);
    }
    
    public int GetStuntValue() {
        return Convert.ToInt32(_cardInfo.StunValue);
    }
    
    public List<string> GetSubtypes() {
        return (_cardInfo.Subtypes);
    }
    
    public string GetTitle() {
        return (_cardInfo.Title);
    }

    public CardInfo GetCardInfo() {
        return _cardInfo;
    }
    
    public List<string> GetTypes() {
        return _cardInfo.Types;
    }
}