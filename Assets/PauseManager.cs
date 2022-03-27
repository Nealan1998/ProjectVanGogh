using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseManager : MonoBehaviour
{
    public bool isPauseMenuOpen;
    public AudioSource[] audioList;
    public GameObject firstButton, pauseMenu, instructions;
    EventSystem theEventSystem;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        theEventSystem = FindObjectOfType<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            HandlePauseMenu();
        }
    }

    // Open and close the Pause Menu
    public void HandlePauseMenu()
    {
        audioList[0].Play();
        // Open Pause Menu
        if (!isPauseMenuOpen)
        {
            // Set first button, open menu, change speed
            theEventSystem.SetSelectedGameObject(firstButton);
            pauseMenu.SetActive(true);
            isPauseMenuOpen = true;
            Time.timeScale = 0;
        }
        else if (isPauseMenuOpen)
        {
            // Close pause menu
            pauseMenu.SetActive(false);
            instructions.SetActive(false);
            isPauseMenuOpen = false;
            Time.timeScale = 1;
        }
    }

    // Go to Title Screen
    public void GoToTitleScreen()
    {
        Destroy(CameraMovement.instance.gameObject);
        Destroy(UI.instance.gameObject);
        pauseMenu.SetActive(false);
        audioList[0].Play(); 
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
        
    }

    // Quit Game
    public void QuitGame()
    {
        audioList[0].Play();
        Application.Quit();
    }

    public void ShowInstructions(GameObject button)
    {
        instructions.SetActive(true);
        audioList[0].Play();
        theEventSystem.SetSelectedGameObject(button);
    }

    public void CloseInstructions()
    {
        theEventSystem.SetSelectedGameObject(firstButton);
        instructions.SetActive(false);
        audioList[0].Play();
    }
    // Play Select Sound Effect
    public void PlaySFX()
    {
        audioList[1].Play();
    }
}
