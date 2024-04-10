using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ChangeSceneOnClick(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
