using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ChangeScene))]
public class CharacterSelection : MonoBehaviour
{

    [Header("PLEASE CHOOSE THE CHARACTERS IN THE CORRECT ORDER FROM PREFABS")]
    [SerializeField] List<GameObject> characterList;

    [Header("NEXT SCENE NAME")]
    [SerializeField] string newSceneName;

    [Header("GET FIRST BUTTON")]
    [SerializeField] Button firstSelected;

    [Header("BACKGROUND COLORS FOR SELECTION")]
    [SerializeField] Color selectedColor;
    [SerializeField] Color unSelectColor;
    int previousSelected;
    

    
    // Start is called before the first frame update
    void Start()
    {
        firstSelected.Select();
        previousSelected = 0;

    }
    public void ChangeSelected(int index)
    {
        if (index == previousSelected)
        {
            AppManager appManager = FindFirstObjectByType<AppManager>();
            appManager.selectedCharacter = characterList[index];
            GetComponent<ChangeScene>().ChangeSceneOnClick(newSceneName);
        }
        else
        {
            previousSelected = index;
        }
        
        
    }

    
    

}
