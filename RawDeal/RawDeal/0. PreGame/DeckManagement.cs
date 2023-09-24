using RawDeal._0._PreGame.Cards;

namespace RawDeal._0._PreGame;

public class DeckManagement {
    private CardCatalog _catalog = new CardCatalog();
    private SuperStarCardCatalog _catalogSuperStar = new SuperStarCardCatalog();
    private SuperStarCard _superStarCard = null!;
    private string _pathDeckChosen;
    private List<Card> _cardsOfDeck;
    private Deck _deck;

    public DeckManagement(string pathDeckChosen) {
        _pathDeckChosen = pathDeckChosen;
        _cardsOfDeck = new List<Card>();
        _deck = ReadDeck();
    }

    public Deck GetDeck() {
        return _deck;
    }

    private Deck ReadDeck() {
        string[] originalDeck = File.ReadAllLines(_pathDeckChosen);
        CreateSuperStarCard(originalDeck[0]);
        
        int largeDeckChosen = originalDeck.Length;
        string[] cardTitles = originalDeck[1..(largeDeckChosen)];
        return(CreateDeck(cardTitles));
    }
    
    private void CreateSuperStarCard(string superStarCardName) {
        string realSuperStarCardName = superStarCardName.Replace(" (Superstar Card)", "") ;
        SuperStarCard superStarCard = _catalogSuperStar.GetSuperStarCardByName(realSuperStarCardName);
        _superStarCard = superStarCard;
    }

    private Deck CreateDeck(string[] cardTitles) {
        foreach (var cardTitle in cardTitles) {
            Card card = _catalog.GetCard(cardTitle);
            _cardsOfDeck.Add(card);
        }
        Deck deck = new Deck(_cardsOfDeck, _superStarCard, _catalogSuperStar);
        return deck;
    }
}