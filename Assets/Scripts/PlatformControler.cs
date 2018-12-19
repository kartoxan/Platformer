using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControler : MonoBehaviour {





	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            LevelControler controler = transform.parent.GetComponent<LevelControler>();
            controler.GenerateLevel();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //LevelControler controler = transform.parent.GetComponent<LevelControler>();
            //controler.DestroyLevel();
        }
    }


}
