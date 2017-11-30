using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCreature : Creature
{
    public TestCreature()
    {
        NameSeter("Richus Maximus");
        AtkSetter(1);
        HpSetter(1);
        Abilities = new List<Ability>();
        Abilities.Add(new Testability());
        Abilities.Add(new Testability2());
    }
       

    public override void Play(Player Player, Player Playee)
    {
        throw new NotImplementedException();
    }
}
