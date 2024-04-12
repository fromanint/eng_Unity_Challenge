using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnMap : MonoBehaviour
{
    public List<GameObject> maps;
    [SerializeField] Camera miniMapCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        int index = Random.Range(0, maps.Count-1);
        Instantiate(maps[index], Vector3.zero, Quaternion.identity);
        Destroy(this);        
    }

  
}
