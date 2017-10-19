using System;
using System.Collections;
using System.Collections.Generic;

public class Game
{
    private Stack<Play> Plays;
    private Stack<Play> UnplayedPlays;
    private Board board;
    private Player[] players;
    private int turn = 0;
    public Game(Board board, Player[] players)
    {
        this.board = board;
        this.players = players;
        Plays = new  Stack<Play>();
        UnplayedPlays = new Stack<Play>();
    }

    public Board Board { get { return board; } }
    public IEnumerable<Player> Players { get { return players; } }
    public int Turn { get { return turn; } }
    public Player CurrentPlayer { get { return players[turn]; } }
    
    public int IndexOfPlayer(Player player)
    {
        return Array.IndexOf(players, player);
    }

    public void Play(int column)
    {
        try
        {
            Plays.Push(new Play(players[turn],players[(players.Length-1)-turn],column,board));
            CurrentPlayer.Play(column, board);
            NextTurn();
        }
        catch (InvalidOperationException)
        {
            // Do nothing
        }
    }

    public void UnPlay()
    {
        Plays.Peek().UnDo();
       UnplayedPlays.Push(Plays.Pop());
        PreviousTurn(); 
    }

    private void NextTurn()
    {
        turn = (turn + 1) % players.Length;
    }
    private void PreviousTurn()
    {
        turn = ((turn - 1) + players.Length) % players.Length;
    }
}
