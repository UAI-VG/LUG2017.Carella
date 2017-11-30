using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card  {
    private string Name;
    private bool Tap;
    public Player Owner { get; set; }
    public Player foe { get; set; }
    public abstract void Play(Player Player, Player Playee);
    public string NAME()
    {
        return Name;
    }
    public void NameSeter (string value)
    {
        Name = value;
    }
}
