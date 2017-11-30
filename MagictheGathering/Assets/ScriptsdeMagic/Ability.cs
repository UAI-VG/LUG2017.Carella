using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability  {

    public abstract string Name();
    public virtual void ActivateMP(Player Player, Player Playee)
    {
        
    }
    public virtual Ability ReturnMainphase()
    {
        return null;
    }
}
