using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testability : Ability
{
    public override string Name()
    {
        return "TestFeliz";
    }
    public override Ability ReturnMainphase()
    {
        return this;
    }
    public override void ActivateMP(Player Player, Player Playee)
    {
        Player.hp += 1;
    }
}
