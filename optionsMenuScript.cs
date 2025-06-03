
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class OptionsMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel; // Assign your menu panel in the inspector
    private bool isMenuOpen = false;
    private AudioListener audioListener;
    jk_movementV2 movement;
    jk_mouseMovementV2 mouse;
    jk_skinwalker SKW;
    jk_stunMechanic SM;
    [SerializeField] private GameObject skw1;
    [SerializeField] private GameObject skw2;
    [SerializeField] private GameObject skw3;
    [SerializeField] private GameObject skw4;
    [SerializeField] private GameObject skw5;
    LevelLoader levelLoader;

    void Start()
    {
        if (menuPanel != null)
        {
            menuPanel.SetActive(false);
        }

        // Find and store reference to the AudioListener (usually on the main camera)
        audioListener = FindAnyObjectByType<AudioListener>();

        if (audioListener == null)
        {
            Debug.LogError("No AudioListener found in the scene!");
        }

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        movement = FindAnyObjectByType<jk_movementV2>();
        mouse = FindAnyObjectByType<jk_mouseMovementV2>();
        AudioListener.pause = false;
        SM = FindAnyObjectByType<jk_stunMechanic>();
        SKW = FindAnyObjectByType<jk_skinwalker>();
        levelLoader = FindAnyObjectByType<LevelLoader>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isMenuOpen = !isMenuOpen;
            // Toggle audio pause
            AudioListener.pause = !AudioListener.pause;
            movement.enabled = !isMenuOpen;
            mouse.enabled = !isMenuOpen;
            if(skw1 != null)
            {
                skw1.SetActive(!isMenuOpen);
            }
            if (skw2 != null)
            {
                skw2.SetActive(!isMenuOpen);
            }
            if (skw3 != null)
            {
                skw3.SetActive(!isMenuOpen);
            }
            if (skw4 != null)
            {
                skw4.SetActive(!isMenuOpen);
            }
            if (skw5 != null)
            {
                skw5.SetActive(!isMenuOpen);
            }
            SM.enabled = !isMenuOpen;
            // Toggle menu visibility

            if (menuPanel != null)
            {
                menuPanel.SetActive(isMenuOpen);
            }

            UpdateCursorState();
        }
    }

    private void UpdateCursorState()
    {
        if (isMenuOpen)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }


    public void restartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        levelLoader.LoadNextLevel(scene.name);
    }

    public void quitToMenu()
    {
        levelLoader.LoadNextLevel("GM_title");
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
