using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyboardController : MonoBehaviour {

    public Player Player;
	
	private void Start () {

        Player = Player == null ? GetComponent<Player>() : Player;
        if(Player == null)
        {
            Debug.LogError("Player not set to controller");
        }
    }

    private void FixedUpdate() {

        if (Player != null)
        {

            if (Input.GetKey(KeyCode.D))
            {
                Player.MoveRight();
            }
            if (Input.GetKey(KeyCode.A))
            {
                Player.MoveLeft();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Player.Jump();
            }
        }
    }
}