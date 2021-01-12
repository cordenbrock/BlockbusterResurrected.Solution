using System.Collections.Generic;

namespace BlockbusterResurrected.Models
{
  public class Game
  {
    public Game()
    {
      this.Consoles = new HashSet<ConsoleGame>();
    }

    public int GameId { get; set; }
    public string GameTitle { get; set; }
    public virtual ICollection<ConsoleGame> Consoles { get; set; }
  }
}