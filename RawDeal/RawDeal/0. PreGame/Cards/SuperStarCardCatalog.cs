using Newtonsoft.Json;

namespace RawDeal._0._PreGame.Cards;

public class SuperStarCardCatalog {
    private readonly Dictionary <string, SuperStarCardInfo> _cardInfo ;
    
    public SuperStarCardCatalog(){
        _cardInfo = new Dictionary<string, SuperStarCardInfo>();
        foreach (var cardInfo in ReadCardInfos())
            _cardInfo[cardInfo.Name] = cardInfo;
    }

    private SuperStarCardInfo[] ReadCardInfos() {
        string fileName = Configuration.SuperStarCardsPath;
        string jsonString = File.ReadAllText(fileName);
        return JsonConvert.DeserializeObject<SuperStarCardInfo[]>(jsonString)!;
    }
    
    public SuperStarCard GetSuperStarCardByName(string cardName)
        => new SuperStarCard(_cardInfo[cardName]);

    public List<string> GetSuperStarLogos() {
        List<string> logos = new List<string>();
        List<SuperStarCardInfo> superStarCardInfos = new List<SuperStarCardInfo>(_cardInfo.Values);
        foreach (var card in superStarCardInfos) {
            logos.Add(card.Logo);
        }
        return logos;
    }
    
}