using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer
{
    public class SceneChangeManager : MonoBehaviour
    {
        public int currentScene;
        public GameObject pauseMenu;
        public GameManager gameManager;

        void Start()
        {
            currentScene = SceneManager.GetActiveScene().buildIndex;
        }
        
        void Update()
        {
            // If the player presses R it will switch the scene to the main gameplay scene and reset it
            if (Input.GetKeyDown(KeyCode.R) && SceneManager.GetActiveScene().buildIndex == 1)
            {
                SceneManager.LoadScene("SampleScene");
            }
            // If the player presses Escape it will return them to the main menu scene 
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
                pauseMenu.transform.position = new Vector3(432.17554f, 175.6278f, 3.5227f);
                //SceneManager.LoadScene("Main Menu");
            }

            if (gameManager != null)
            {
                if (gameManager.gameWon)
                {
                    Cursor.lockState = CursorLockMode.None;
                    SceneManager.LoadScene("Win");
                }
                if (gameManager.gameOver)
                {
                    Cursor.lockState = CursorLockMode.None;
                    SceneManager.LoadScene("Game Over");
                }
            }
        }

        public void unpause()
        {
            Time.timeScale = 1;
            pauseMenu.transform.position = new Vector3(-2000, -2000, -2000);
        }

        public void returnToMenu()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Main Menu");
        }

        // Switches the scene to the main gameplay scene when the button on the main menu is pressed
        public void StartGame()
        {
            // Change to the gameplay scene
            SceneManager.LoadScene("SampleScene");
        }
    }
}