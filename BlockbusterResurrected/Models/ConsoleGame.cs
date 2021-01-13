namespace BlockbusterResurrected.Models
{
  public class ConsoleGame
  {
    public int ConsoleGameId { get; set; }
    public int GConsoleId { get; set; }
    public int GameId { get; set; }
    public GConsole GConsole { get; set; }
    public Game Game { get; set; }
  }
}