using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleDamage : MonoBehaviour
{
    public GetHurt playerSuffer;
    public GeneralHuman Self;
    public GeneralHuman Player;
    // Start is called before the first frame update
    void Start()
    {
        playerSuffer = BattleInitiation.currentPlayer.GetComponent<GetHurt>();
        Player = BattleInitiation.currentPlayer.GetComponent<GeneralHuman>();
        Self = BattleInitiation.currentEnemy.GetComponent<GeneralHuman>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            playerSuffer.SufferDamage(Self.atk - Player.def);
    }
}
