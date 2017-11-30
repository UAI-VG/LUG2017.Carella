using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player   {

    public int hp { get; set; }
    public int turn { get; set; }
     int RedMana { get; set; }
    private int BlueMana;
    private int GreenMana;
    private int WhiteMana;
    private int BlackMana;
    private int ColorlessMana;
    private Stack<Card> Deck;
    private List<Card> Hand;
    private Board Board;
   
}
