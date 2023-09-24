namespace RawDeal._0._PreGame.Cards;

public class SuperStarCard {
    private SuperStarCardInfo _cardInfo;
    
    public SuperStarCard(SuperStarCardInfo cardInfo)
        => _cardInfo = cardInfo;

    public int GetHandSize()
        => _cardInfo.HandSize;
    
    public string GetLogo()
        => _cardInfo.Logo;
    
    public string GetName()
        => _cardInfo.Name;
    
    public string GetSuperStarAbility()
        => _cardInfo.SuperStarAbility;
}