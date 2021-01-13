using System.Collections.Generic;

namespace BlockbusterResurrected.Models
{
  public class GConsole
  {
    public GConsole()
    {
    this.Games = new HashSet<ConsoleGame>();
    }

    public int GConsoleId { get; set; }
    public string GConsoleName { get; set; }
    public string Description {get; set; }
    public virtual ICollection<ConsoleGame> Games { get; set; }
  }
}