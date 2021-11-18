using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessUpDirection : MonoBehaviour
{
    GameObject Player;
    Move move;
    private void OnEnable()
    {
        Player = BattleInitiation.currentPlayer.gameObject;
        move = Player.GetComponent<Move>();
        Skill();
        Check();
    }
    private void OnDisable()
    {
        Recover();
    }
    private void Check()
    {
        if (EnemyStatus.Checkexist("CanBeHorny" + "(Clone)"))
        {
            GameObject temp;
            temp = GameObject.Find("INeedToBeHorny" + "(Clone)").gameObject;
            if (temp != null)
                PlayerStatus.offsetPlayerSkill(temp);
        }
    }

    private void Skill()
    {
        Move.isMessUp = true;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (Player.transform.position.x <= 8.5)
                this.gameObject.transform.position += new Vector3(move.horizontal, 0f, 0f);
            move.playerSpriteRenderer.flipX = false;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x > -8.5)
                this.gameObject.transform.position += new Vector3(-1 * move.horizontal, 0f, 0f);
            move.playerSpriteRenderer.flipX = true;
        }
        // Exist in Move.MessUp function
    }

    private void Recover()
    {
        Move.isMessUp = false;
    }
}
