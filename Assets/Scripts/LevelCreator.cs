using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour {

    public GameObject PartLevel;
    public GameObject Obstacle;
    public GameObject Platform;

    public List<GameObject> PartsLevel;

    public GameObject CreateNextZone()
    {
        Zone zone = (Zone)Random.Range(0, 2);

        GameObject thisZone = null;
        switch(zone)
        {
            case Zone.TrapOnTheFloor:
                {
                    thisZone = Instantiate(PartLevel);

                    int ObstacleNunder = 0;

                    for (int i = -9; i <= 10; i += 2)
                    {
                        if (ObstacleNunder < 2)
                        {
                            int rand = Random.Range(0, 100);

                            if (rand < 50)
                            {
                                GameObject o = Instantiate(Obstacle, thisZone.transform);
                                o.transform.position = new Vector3(o.transform.position.x + i, o.transform.position.y, o.transform.position.z);
                                ObstacleNunder++;
                            }
                            else
                            {
                                ObstacleNunder = 0;
                                i += 2;
                            }
                        }
                        else
                        {
                            ObstacleNunder = 0;
                            i += 2;
                        }
                    }
                    break;
                }
            case Zone.Platform:
                {
                    int i = Random.Range(0, PartsLevel.Count);

                    thisZone = Instantiate(PartsLevel[i]);
                    break;
                }
        }


        return thisZone.gameObject;
    }





    enum Zone
    {
        TrapOnTheFloor,
        Platform,
        Rockets,
        Rndom,
    }
}
