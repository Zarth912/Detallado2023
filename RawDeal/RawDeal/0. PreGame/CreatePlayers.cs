using RawDealView;

namespace RawDeal._0._PreGame;

public class CreatePlayer
{
    private View _view;
    private string _deckFolder;
    
    public CreatePlayer(View view, string deckFolder) {
        _view = view;
        _deckFolder = deckFolder;
    }

    public Player? Create() {
        Deck deck = CreateDeckPlayer();
        if (!deck.CheckIsValidDeck()) return null;
        Player player = new Player(deck);
        return player;
    }

    private Deck CreateDeckPlayer() {
        string pathDeckChosen = _view.AskUserToSelectDeck(_deckFolder);
        DeckManagement deckManagement = new DeckManagement(pathDeckChosen);
        Deck deck = deckManagement.GetDeck();
        return deck;
    }

    public bool ValidPlayer(Player? player) {
        if (player != null) 
            return true;
        _view.SayThatDeckIsInvalid();
        return false;
    }
}