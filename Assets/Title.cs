using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Title : MonoBehaviour
{
    bool instructionsOpen;
    EventSystem theEventSystem;
    public AudioSource[] audioList;
    // Start is called before the first frame update
    void Start()
    {
        theEventSystem = FindObjectOfType<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ManageInstructions(GameObject instructions)
    {
        if(instructionsOpen)
        {
            instructionsOpen = false;
            instructions.SetActive(false);
        }
        else if (!instructionsOpen)
        {
            instructionsOpen = true;
            instructions.SetActive(true);
        }
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void SetButton(GameObject button)
    {
        theEventSystem.SetSelectedGameObject(button);
    }

    public void PlaySFX(int whatToPlay)
    {
        audioList[whatToPlay].Play();
    }
}
