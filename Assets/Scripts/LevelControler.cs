using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelControler : MonoBehaviour {

    public Player player;

    public GameObject PrefabPlatform;
    public GameObject PrefabObstacle;

    public GameObject GameOverPanel;
    public Text TexstScore;
    public Text GmameOverScore;

    private int Score;
    private int numderplatform = 0;

    public bool gmame;

    // Use this for initialization
    void Start () {
        GenerateLevel();
	}
	
	// Update is called once per frame
	void Update () {
        if(gmame)
        {
            Score +=(int) player.WalkSpeed;
            TexstScore.text = Score.ToString();
            player.WalkSpeed *= 1.00001f;
        }







    }

    public void StartGame()
    {
        gmame = true;
    }

    public void GenerateLevel()
    {
        numderplatform++;
        GameObject platform = Instantiate(PrefabPlatform);
        
        platform.transform.SetParent(transform);
        platform.transform.position = new Vector3(numderplatform * 20, -5, 0);


        for (int i = 0; i < 3; i++)
        {
            GameObject Obstacle = Instantiate(PrefabObstacle);
            Obstacle.transform.SetParent(platform.transform);
            Obstacle.transform.position = new Vector3(numderplatform * 20 + Random.Range(-10 , 10), Obstacle.transform.position.y, Obstacle.transform.position.z);
            Obstacle.GetComponent<ObstacleControler>().LC = this;
        }

    }

    public void GmameOver()
    {
        gmame = false;
        GameOverPanel.SetActive(true);
        TexstScore.text = "";
        GmameOverScore.text = "Ваш щет: " + Score.ToString();
    }
}
