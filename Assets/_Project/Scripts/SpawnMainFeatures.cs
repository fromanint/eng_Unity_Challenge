using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnMainFeatures : MonoBehaviour
{

    public GameObject character;
    public GameObject mainCollectible;
    public GameObject finishLine;

    public List<GameObject> SpawnPoints;

    void SpawnNewObject(GameObject objectSpawn)
    {
        int index = Random.Range(0, SpawnPoints.Count-1);
        GameObject SpawnedObject;
        SpawnedObject = Instantiate(objectSpawn, SpawnPoints[index].transform.position, Quaternion.identity);
        SpawnedObject.transform.SetParent(SpawnPoints[index].transform);
        //SpawnedObject.transform.localPosition = Vector3.zero;
        //SpawnedObject.transform.localRotation = Quaternion.identity;
        SpawnPoints.RemoveAt(index);
        //SpawnedObject.transform.SetParent(null);

    }

    // Start is called before the first frame update
    void Start()
    {
        
        SpawnNewObject(mainCollectible);
        SpawnNewObject(finishLine);

        GameObject characterSpawn = FindAnyObjectByType<AppManager>().selectedCharacter;
       if(characterSpawn != null)
            SpawnNewObject(characterSpawn);
       else
            SpawnNewObject(character);



      //  Destroy(this);

    }


}
