using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play  {
    public Play(Player doer, Player other, int col)
    {
        Doer = doer;
        Other = other;
        Col = col;
    }
    private Player Doer;
    private Player Other;
    private int Col;
    public int col()
    {
        return Col;
    }

    public void Do ()
    {
        
    }
    public void UnDo()
    {

    }
}
