using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : Card {

    private int RedCost;
    private int BlueCost;
    private int GreenCost;
    private int WhiteCost;
    private int BlackCost;
    private int ColorlessCost;
    //private string Type;
    public List<Ability> Abilities { get; set; }
    public List<Ability> MainPhaseAbilities()
    {
        List<Ability> MainPhaseOnes = new List<Ability>();
        foreach (Ability A in Abilities)
        {
            MainPhaseOnes.Add(A.ReturnMainphase());
        }
        return MainPhaseOnes;
    }
}
