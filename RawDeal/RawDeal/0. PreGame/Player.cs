using RawDeal._0._PreGame.Cards;
using RawDealView;

namespace RawDeal._0._PreGame;

public class Player  {
    private List<Card> _deck;
    private SuperStarCard SuperStar { get; }
    private int Fortitude { get; set;  }
    private CardCollection _handCards = new CardCollection() ;
    private CardCollection _arsenalCards = new CardCollection() ;
    private CardCollection _ringsideCards = new CardCollection() ;
    private CardCollection _ringAreaCards = new CardCollection() ;

    public Player(Deck deck) {
        _deck = deck.GetDeck();
        SuperStar = deck.GetSuperStar();
        Fortitude = 0;
        SetInitialArsenal();
        SetInitialHand();
    }
    
    public void ChangeFortitude(int newFortitudeValue)  
        => Fortitude += newFortitudeValue;
    
    public string GetSuperStarName()  
        => SuperStar.GetName();
    
    public int GetFortitude() {
        return Fortitude;
    }
    
    public int GetInitialHandSize()  
        => SuperStar.GetHandSize();

    private void SetInitialArsenal() {
        foreach (Card card in _deck) {
            _arsenalCards.Add(card);
        }
    }
    
    private void SetInitialHand() {
        int handSize = SuperStar.GetHandSize();
        DrawCardsfromArsenal(handSize);
    }

    public List<Card> GetHandCards() {
        List<Card> cards = _handCards.GetCards();
        return cards;
    }
    
    public List<Card> GetRingAreaCards() {
        List<Card> cards = _ringAreaCards.GetCards();
        return cards;
    }
    
    public List<Card> GetArsenalCards() {
        List<Card> cards = _arsenalCards.GetCards();
        return cards;
    }
    
    public List<Card> GetRingSideCards() {
        List<Card> cards = _ringsideCards.GetCards();
        return cards;
    }
    
    public void DrawCardsfromArsenal(int n) {
        for (int i = 0; i < n; i++) {
            _arsenalCards.GiveTopCardTo(_handCards);
        }
    }

    public void PlayCardIfValid(Card card) {
        _handCards.PlayCard(card, _ringAreaCards);
    }
    
    
    public Card GetTopArsenalCard() {
        Card card = _arsenalCards.GetTopCard();
        _arsenalCards.GiveTopCardTo(_ringsideCards);
        return card;
    }
    
    public PlayerInfo UpdatePlayerInfo() {
        string superStarName = SuperStar.GetName();
        int numberOfCardsInHand = _handCards.Count(), numberOfCardsInArsenal = _arsenalCards.Count();
        PlayerInfo playerInfo =
            new PlayerInfo(superStarName, Fortitude, numberOfCardsInHand, numberOfCardsInArsenal);
        return playerInfo;
    }
    
}