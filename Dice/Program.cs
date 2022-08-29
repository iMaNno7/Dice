Console.WriteLine("enter username players :");

var board = new Board(new(Console.ReadLine()), new(Console.ReadLine()));

var winner = board.Play();

Console.WriteLine(winner.Username);
Console.WriteLine(winner.Score);
//switch (play)
//{
//    case 1:
//        new Dice().Play();
//        break;
//    default:
//        break;
//}

class Board
{
    private readonly Dice _dice = new();
    public Player PlayerOne { get; init; }
    public Player PlayerTwo { get; init; }

    public Board(Player playerOne, Player playerTwo)
    {
        PlayerOne = playerOne;
        PlayerTwo = playerTwo;
    }
    public Player Play()
    {        
        PlayerTwo.AddScore((sbyte)(_dice.Play() + _dice.Play()));
        PlayerOne.AddScore((sbyte)(_dice.Play() + _dice.Play()));
        
        if (PlayerTwo.Score == PlayerOne.Score)
            Play();

        return PlayerOne.Score > PlayerTwo.Score ? PlayerOne : PlayerTwo;
    }

}

class Player
{

    public Player(string username)
    {
        Username = username;
    }
    public string Username { get; init; }
    public sbyte Score { get; private set; }

    public void AddScore(sbyte score)
    {
        this.Score += score;
    }

}
class Dice
{
    const int min = 1;
    const int max = 6;

    public sbyte Play()
    {
        return GenerateRandomNmmber();
    }
    public sbyte GenerateRandomNmmber()
    {
        return (sbyte)new Random().Next(min, max);
    }
}