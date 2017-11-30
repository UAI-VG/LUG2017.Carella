using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMaker : MonoBehaviour {

    public Player player { get; set; }

    private void Awake()
    {
        player = new Player();
        player.hp = 20;
        player.turn = 1;
        
    }
    public void Update()
    {
        GetComponent<Text>().text = player.hp.ToString();
    }
}
