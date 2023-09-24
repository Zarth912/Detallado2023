namespace RawDeal._0._PreGame.Cards;

public class CardCollection
{
    private List<Card> _cards = new List<Card>();

    public void Add(Card card)
        => _cards.Add(card);

    public void GiveTopCardTo(CardCollection destination)
        => GiveCardTo(GetTopCard(), destination);

    public Card GetTopCard() {return _cards.Last();}

    private void GiveCardTo(Card card, CardCollection destination) {
        destination.Add(card);
        _cards.Remove(card);
    }

    public List<Card> GetCards() {
        return _cards;
    }

    public int Count()
        => _cards.Count();
    
    public void PlayCard(Card card, CardCollection destination) 
        => GiveCardTo(card, destination);
    
}