using Newtonsoft.Json;

namespace RawDeal._0._PreGame.Cards;

public class CardCatalog
{
    private readonly Dictionary<string, CardInfo> _cardInfo;

    public CardCatalog()
    {
        _cardInfo = new Dictionary<string, CardInfo>();
        foreach (var cardInfo in ReadCardInfos())
            _cardInfo[cardInfo.Title] = cardInfo;
    }

    private CardInfo[] ReadCardInfos()
    {
        string fileName = Configuration.PathToCardsJson;
        string jsonString = File.ReadAllText(fileName);
        return JsonConvert.DeserializeObject<CardInfo[]>(jsonString)!;
    }

    public Card GetCard(string cardTitle)
        => new Card(_cardInfo[cardTitle]);
}