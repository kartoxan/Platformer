using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveName : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void saveName(Text Name)
    {
        PlayerPrefs.SetString("Name", Name.text);
    }

    public void ClearPlaerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

}
