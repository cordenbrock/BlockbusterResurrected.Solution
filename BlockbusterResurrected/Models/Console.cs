using System.Collections.Generic;

namespace BlockbusterResurrected.Models
{
  public class Console
  {
    public Console()
    {
    this.Games = new HashSet<ConsoleGame>();
    }

    public int ConsoleId { get; set; }
    public string ConsoleName { get; set; }
    public virtual ICollection<ConsoleGame> Games { get; set; }
  }
}