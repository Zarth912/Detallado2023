using RawDeal._0._PreGame.Cards;

namespace RawDeal._0._PreGame;

public class Deck {
    private readonly List<Card> _deck;
    private SuperStarCard _cardSuperStar;
    private SuperStarCardCatalog _catalogSuperStar;
    private bool _isFace;
    private bool _isHeel;
    
    public Deck(List<Card> deck, SuperStarCard superStarCard, SuperStarCardCatalog catalogSuperStar) {
        _deck = deck;
        _cardSuperStar = superStarCard;
        _catalogSuperStar = catalogSuperStar;
    }

    public bool CheckIsValidDeck() {
        bool isSizeCorrect = CheckDeckSize();
        bool deckHasOneSuperStar = CheckDeckHasOneSuperStar();
        bool hasOnlyOneType = CheckOneTypeOfCardsPerDeck();
        bool maxCards = CheckMaxCardsAllowed();
        return isSizeCorrect && deckHasOneSuperStar && maxCards && hasOnlyOneType;
    }

    private bool CheckDeckSize() {
        int maxSizeDeck = 60;
        int deckSize = _deck.Count;
        return (deckSize == maxSizeDeck);
    }
    
    private bool CheckDeckHasOneSuperStar() {
        foreach (var card in _deck) {
            List<string> subTypes = card.GetSubtypes();
            if (CheckOtherSuperStarInDeck(subTypes))
                return false;
        }
        return true;
    }
    
    private bool CheckOtherSuperStarInDeck(List<string> subTypes) {
        foreach (var subType in subTypes) {
            bool superStarInCard = CheckSuperStarInCard(subType);
            if (superStarInCard)
                return true;
        }
        return false;
    }

    private bool CheckSuperStarInCard(string subType) {
        List<string> superStarLogos = _catalogSuperStar.GetSuperStarLogos();
        superStarLogos.Remove(_cardSuperStar.GetLogo());
        foreach (var superStarName in superStarLogos) {
            if (superStarName == subType)
                return true;
        }
        return false;
    }
    
    private bool CheckOneTypeOfCardsPerDeck() {
        foreach (var card in _deck) {
            List<string> subTypes = card.GetSubtypes();
            TypeOfDeck(subTypes);
        }
        if (_isFace && _isHeel)
            return false;
        return true;
    }

    private void TypeOfDeck(List<string> subTypes) {
        foreach (string subType in subTypes) {
            if (subType == "Face")
                _isFace = true;
            if (subType == "Heel")
                _isHeel = true;
        }
    }
    
    private bool CheckMaxCardsAllowed() {
        List<Card> notSetUpCards = ExcludeSetUpCardsFromCount();
        bool maxThreePerCard = CheckThreeCardsPerNormalType(notSetUpCards);
        bool maxOneInUniqueType = CheckAmountIsUniqueCards(notSetUpCards);
        return maxThreePerCard && maxOneInUniqueType;
    }
    
    private List<Card> ExcludeSetUpCardsFromCount() {
        List<Card> notSetUpCards  = new List<Card>();
        string searchSetUpSubType = "SetUp";
        foreach (var card in _deck) {
            List<string> subTypes = card.GetSubtypes();
            if (!subTypes.Contains(searchSetUpSubType))
                notSetUpCards.Add(card);
        }
        return notSetUpCards;
    }

    private bool CheckAmountIsUniqueCards(List<Card> notSetUpCards) {
        List<string> uniqueCards  = new List<string>();
        string searchUniqueSubType = "Unique";
        foreach (var card in notSetUpCards) {
            List<string> subTypes = card.GetSubtypes();
            if (subTypes.Contains(searchUniqueSubType))
                uniqueCards.Add(card.GetTitle());
        }
        return CountCantUniqueCardOk(uniqueCards);
    }
    
    private bool CountCantUniqueCardOk(List<string> uniqueCards) {
        int maxCardPerdDeck = 1;
        foreach (var cardTitle in uniqueCards) {
            int cant = uniqueCards.Count(card => card == cardTitle);
            if (cant > maxCardPerdDeck)
                return false;
        }
        return true;
    }
    
    private bool CheckThreeCardsPerNormalType(List<Card> notSetUpCards) {
        List<string> cardTitles = new List<string>();
        foreach (var card in notSetUpCards) {
            string title = card.GetTitle();
            cardTitles.Add(title);
        }
        return CountNormalCards(cardTitles);
    }
    
    private bool CountNormalCards(List<string> cardsByTitle) {
        int maxCardPerdDeck = 3;
        foreach (var cardTitle in cardsByTitle) {
            int cant = cardsByTitle.Count(card => card == cardTitle);
            if (cant > maxCardPerdDeck)
                return false;
        }
        return true;
    }
    
    public  List<Card> GetDeck()
        => _deck;
    
    public SuperStarCard GetSuperStar()
        => _cardSuperStar;
}