using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonk : MonoBehaviour
{
    public GetHurt playerSuffer;
    // Start is called before the first frame update
    void Start()
    {
        playerSuffer = BattleInitiation.currentPlayer.GetComponent<GetHurt>();
        BonkDamage();
    }

    private void BonkDamage()
    {
        playerSuffer.SufferDamage(50);
    }

}
