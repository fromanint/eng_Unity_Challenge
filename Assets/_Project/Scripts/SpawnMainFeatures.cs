using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMainFeatures : MonoBehaviour
{

    public GameObject character;
    public GameObject mainCollectible;
    public GameObject finishLine;

    public List<GameObject> SpawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
