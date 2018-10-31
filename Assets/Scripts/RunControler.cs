using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunControler : MonoBehaviour {

    private bool run;

    public Player Player;

    private void Start()
    {

        Player = Player == null ? GetComponent<Player>() : Player;
        if (Player == null)
        {
            Debug.LogError("Player not set to controller");
        }
    }

    private void FixedUpdate()
    {

        if (Player != null)
        {
            if (run)
            {
                Player.MoveRight();
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Player.Jump();
                }
            }
        }
    }

    public void StartRun()
    {
        run = true;
    }
}
