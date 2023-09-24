using RawDealView.Formatters;

namespace RawDeal._0._PreGame.Cards;

public class CardInfo:IViewableCardInfo  {
    public string Title { get ; set ; }
    public List<string> Types { get ; set ; }
    public List<string> Subtypes { get ; set ; }
    public string Fortitude { get ; set ; }
    public string Damage { get ; set ; }
    public string StunValue { get ; set ; }
    public string CardEffect { get ; set ; }
    
    public CardInfo(string title, List<string> types, List<string> subtypes, string fortitude, string damage, string stunvalue, string cardeffect) {
        Title = title;
        Types = types;
        Subtypes = subtypes;
        Fortitude = fortitude;
        Damage = damage;
        StunValue = stunvalue;
        CardEffect = cardeffect;
    }
}