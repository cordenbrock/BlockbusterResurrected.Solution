namespace BlockbusterResurrected.Models
{
  public class ConsoleGame
  {
    public int ConsoleGameId { get; set; }
    public int ConsoleId { get; set; }
    public int GameId { get; set; }
    public Console Console { get; set; }
    public Game Game { get; set; }
  }
}