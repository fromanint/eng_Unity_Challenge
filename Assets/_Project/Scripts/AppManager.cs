using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    public GameObject selectedCharacter;
    // Start is called before the first frame update
    void Awake()
    {
        //AppManager[] appManagers = FindObjectsOfType<AppManager>();
        AppManager[] appManagers = FindObjectsByType<AppManager>(FindObjectsSortMode.None);
        if(appManagers.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    
}
