using BonhommePendu.Models;

namespace BonhommePendu.Events
{
    // Un événement à créer chaque fois qu'un utilisateur essai une "nouvelle" lettre
    public class GuessEvent : GameEvent
    {
        // TODO: Compléter
        public GuessEvent(GameData gameData, char letter) {
            this.Events = new List<GameEvent>();
            // TODO: Commencez par ICI
            GuessedLetterEvent guessedLetterEvent = new GuessedLetterEvent(gameData, letter);
            gameData.GuessedLetters.Add(letter);
            this.Events.Add(guessedLetterEvent);

            int goodletter = 0;
            for(int i = 0; i <= gameData.Word.Length-1; i++) {
                if (gameData.HasSameLetterAtIndex(letter, i))
                {
                    goodletter++;
                    RevealLetterEvent revealLetterEvent = new RevealLetterEvent(gameData, letter, i);
                    this.Events.Add(revealLetterEvent);
                }
            }

            if (goodletter == 0) {
                WrongGuessEvent wrongGuessEvent = new WrongGuessEvent(gameData);
                this.Events.Add(wrongGuessEvent);
            }

        }
    }
}
