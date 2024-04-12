using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnMainFeatures : MonoBehaviour
{

    public GameObject character;
    public GameObject mainCollectible;
    public GameObject finishLine;

    public List<GameObject> SpawnPoints;

    void SpawnNewObject(GameObject objectSpawn)
    {
        int index = UnityEngine.Random.Range(0, SpawnPoints.Count-1);
        GameObject SpawnedObject;
        SpawnedObject = Instantiate(objectSpawn, Vector3.zero, Quaternion.identity);
        SpawnedObject.transform.SetParent(SpawnPoints[index].transform);
        SpawnedObject.transform.localPosition = Vector3.zero;
        SpawnedObject.transform.localRotation = Quaternion.identity;
        SpawnPoints.RemoveAt(index);
        SpawnedObject.transform.SetParent(null);

    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject characterSpawn = FindAnyObjectByType<AppManager>().selectedCharacter;
        try
        {
            SpawnNewObject(characterSpawn);
            
            
        }catch (Exception e)
        {
            SpawnNewObject(character);
          
        }
        SpawnNewObject(mainCollectible);
        SpawnNewObject(finishLine);

        Destroy(this);

    }


}
