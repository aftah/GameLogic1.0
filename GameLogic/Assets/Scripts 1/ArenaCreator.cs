using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ArenaCreator : MonoBehaviour
{

    public void CreateMap()
    {

        DataContainer.singleton.dataArena.arena.obstaclesObject.Clear();
        DataContainer.singleton.dataArena.arena.obstaclesPosition.Clear();

        foreach (GameObject obstacle in FindObjectsOfType<GameObject>().Where(x => x.gameObject.CompareTag("Obstacle")))
        {
            
            DataContainer.singleton.dataArena.arena.obstaclesPosition.Add(obstacle.transform.position);

            int indexOfObstacle = DataContainer.singleton.metaData.obstaclesName.IndexOf(obstacle.GetComponent<ObstacleReference>().objectName);
            DataContainer.singleton.dataArena.arena.obstaclesObject.Add(DataContainer.singleton.metaData.obstacles[indexOfObstacle]);

        }

    }

}
