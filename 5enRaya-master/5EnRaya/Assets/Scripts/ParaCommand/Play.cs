﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play  {
    public Play(Player doer, Player other, int col, Board board)
    {
        Doer = doer;
        Other = other;
        Col = col;
        Board = board;
    }
    private Board Board;
    private Player Doer;
    private Player Other;
    private int Col;
    public int col()
    {
        return Col;
    }

    public void Do ()
    {

        Doer.Play(col(), Board);

}
    public void UnDo()
    {
      Board.Remove(Col);
    }
}
