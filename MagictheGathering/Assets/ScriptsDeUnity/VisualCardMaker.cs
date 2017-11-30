using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VisualCardMaker : MonoBehaviour {
    [SerializeField]
    private Text Atk;
   [SerializeField]
    private Text HP;
   [SerializeField]
    private Text Name;
    private Creature Creature;
    [SerializeField]
    private int CardNumber;
    public Button boton;
    public PlayerMaker Owner;
    public PlayerMaker foe;
    public Text test;

    public void Update()
    {
        Creature.Owner = Owner.player;
        Creature.foe = foe.player;
        test.text = Creature.Owner.turn.ToString();
        
    }

    public void Click()
    {
        int PosX = 0;
        switch (Creature.Owner.turn)
        {
            case 1:
                {
                    foreach (Ability Skill in Creature.MainPhaseAbilities())
                    {
                        int n = PosX;
                        Button ToCreate = Instantiate(boton,transform);
                        ToCreate.transform.position += transform.right
                            * PosX * 15;
                        /*ToCreate.GetComponent<AbilityContainer>().Ability = Skill;
                        ToCreate.GetComponent<AbilityContainer>().Player = Creature.Owner;
                        ToCreate.GetComponent<AbilityContainer>().Playee = Creature.foe;*/
                        ToCreate.onClick.AddListener(delegate { OnClickMP(n); });
                        PosX++;
                       
                        
                    }
                    break;
                }
        }
        
    }
    public void OnClickMP(int N)
    {
        Debug.Log(N);
        Creature.Abilities[N].ActivateMP(Creature.Owner, Creature.foe);
       /* GetComponent<AbilityContainer>().Ability.ActivateMP(
            GetComponent<AbilityContainer>().Player,
            GetComponent<AbilityContainer>().Playee);*/
    }
    public void Awake()
    {
        Creature=CreateCreature(CardNumber);
   
        ////////////////////////////////////////////
        Name.text = Creature.NAME();
        Atk.text = Creature.ATK().ToString();
        HP.text = Creature.HP().ToString();
    }
    private Creature CreateCreature(int Number)
    {
        switch(Number)
        {
            case 0:
                {
                 return new TestCreature();
                    
                }
            default:
                {
                    return new TestCreature();
                }
                
        }
    }

}
