using UnityEngine;
using System.Collections;

public class UserPlayer : Player {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.players[GameManager.instance.currentPlayerIndex] == this)
        {
            transform.renderer.material.color = Color.green;
        }

        else
        {
            transform.renderer.material.color = Color.white;
        }
    }

    public override void TurnUpdate()
    {
        if (Vector3.Distance(moveDestination, transform.position) > 0.1f)
        {
            transform.position += (moveDestination - transform.position).normalized * moveSpeed * Time.deltaTime;

            if (Vector3.Distance(moveDestination, transform.position) <= 0.1f)
            {
                transform.position = moveDestination;
                GameManager.instance.nextTurn();
            }
        }

        base.TurnUpdate();
    }
}
