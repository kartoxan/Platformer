using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelControler : MonoBehaviour {

    public Player player;
    public GameObject Connection;

    public GameObject GameOverPanel;
    public Text HighScoreText;
    public Text TexstScore;
    //public Text GmameOverScore;

    public GameObject MainMenu;

    public GameObject SetNmaePnel;

    public List<Text> nameHighScore;
    public List<Text> HighScores;


    private int Score;
    private int HighScore;

    public LevelCreator LevelCreator;

    public List<GameObject> Platforms;

    private int PassedPlatforms = 0;

    public bool gmame;

    // Use this for initialization
    void Start () {
        HighScore = PlayerPrefs.GetInt("HighScore0");
        HighScoreText.text = "Ваш рекорд: " + HighScore.ToString();
        GenerateLevel();
        if (!PlayerPrefs.HasKey("Name"))
        {
            SetNmaePnel.SetActive(true);
        }
        else
        {
            MainMenu.SetActive(true);
        }
	}

    // Update is called once per frame
    private bool temp = true;
    void Update () {
        if (gmame)
        {
            Score += (int)player.WalkSpeed;
            TexstScore.text = Score.ToString();
            player.WalkSpeed *= 1.0001f;
        }
        if(player == null)
        {
            if (temp)
            {
                temp = false;
                GmameOver();
            }
        }
    }

    public void StartGame()
    {
        gmame = true;
    }

    public void GenerateLevel()
    {
        if (true)
        {
            GameObject Platform = LevelCreator.CreateNextZone();

            Platform.transform.position = transform.GetChild(transform.childCount - 1).transform.position;
            Platform.transform.position = new Vector3(Platform.transform.position.x + 12, Platform.transform.position.y, Platform.transform.position.z);

            Platform.transform.SetParent(this.transform);

            GameObject Con = Instantiate(Connection);

            ;

            Con.transform.position = transform.GetChild(transform.childCount - 1).transform.position;
            Con.transform.position = new Vector3(Con.transform.position.x + 12, Con.transform.position.y, Con.transform.position.z);

 
            Con.transform.SetParent(this.transform);

            
        }
    }

    public void DestroyLevel()
    {
        PassedPlatforms++;
        if (PassedPlatforms > 3)
        {
            
            Destroy(transform.GetChild(0).gameObject);
        }
    }

    public void GmameOver()
    {
        gmame = false;
        GameOverPanel.SetActive(true);
        TexstScore.text = "";
        Debug.Log("lol1");
        bool temp = false;
        for (int i = 0; i < 3; i++)
        {
            if (!temp)
            {
                if (PlayerPrefs.HasKey("HighScore" + i))
                {

                    if (Score > PlayerPrefs.GetInt("HighScore" + i))
                    {
                        temp = true;
                        for (int j = 3; j > i; j--)
                        {
                            PlayerPrefs.SetInt("HighScore" + j, PlayerPrefs.GetInt("HighScore" + (j - 1)));
                            PlayerPrefs.SetString("HighScoreName" + j, PlayerPrefs.GetString("HighScoreName" + (j - 1)));
                        }
                        PlayerPrefs.SetInt("HighScore" + i, Score);
                        PlayerPrefs.SetString("HighScoreName" + i, PlayerPrefs.GetString("Name"));
                    }

                }
                else
                {
                    Debug.Log("lol");
                    temp = true;
                    PlayerPrefs.SetInt("HighScore" + i, Score);
                    PlayerPrefs.SetString("HighScoreName" + i, PlayerPrefs.GetString("Name"));
                    HighScores[i].text = PlayerPrefs.GetInt("HighScore" + i).ToString();
                    nameHighScore[i].text = i + 1 + ". " + PlayerPrefs.GetString("HighScoreName" + i);
                    break;
                }
            }
            if (PlayerPrefs.HasKey("HighScore" + i))
            {
                HighScores[i].text = PlayerPrefs.GetInt("HighScore" + i).ToString();
                nameHighScore[i].text = i + 1 + ". " + PlayerPrefs.GetString("HighScoreName" + i);
            }


        }
    }


    

}
