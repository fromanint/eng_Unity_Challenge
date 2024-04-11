using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineScript : MonoBehaviour
{

    public AudioClip audioTask;
    public AudioClip audioFinish;
    public AudioSource npcFinish;
    public string menuScene;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Player")
        {
            if (FindFirstObjectByType<AppManager>().canFinish)
            {
                if (!npcFinish.isPlaying)
                {
                    npcFinish.clip = audioFinish;
                    npcFinish.Play();
                    StartCoroutine(WaitForSound());
                }

            }
            else
            {
                if (!npcFinish.isPlaying)
                {
                    npcFinish.clip = audioTask;
                    npcFinish.Play();
                }
            }                 
                    
                
        }
    }
    IEnumerator WaitForSound()
    {
        //Wait Until Sound has finished playing
        while (npcFinish.isPlaying)
        {
            yield return null;
        }

      
        PlayerPrefs.SetString("HighScore", FindFirstObjectByType<TimeControl>().timerText.text);
 
        FindFirstObjectByType<ChangeScene>().ChangeSceneOnClick(menuScene);
       
    }
}
