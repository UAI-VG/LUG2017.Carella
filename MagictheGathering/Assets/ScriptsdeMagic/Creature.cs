using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature : Spell {

    private int Atk;
    private int Hp;
    public int ATK()
    {
        return Atk;
    }
    public int HP ()
    {
        return Hp;
    }
    public void AtkSetter(int value)
    {
        Atk = value;
    }
    public void HpSetter(int value)
    {
        Hp = value;
    }

}
