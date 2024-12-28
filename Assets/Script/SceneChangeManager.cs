using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer
{
    public class SceneChangeManager : MonoBehaviour
    {
        public int currentScene;
        
        void Start()
        {
            currentScene = SceneManager.GetActiveScene().buildIndex;
        }
        
        void Update()
        {
            // If the player presses R it will switch the scene to the main gameplay scene and reset it
            if (Input.GetKeyDown(KeyCode.R) && SceneManager.GetActiveScene().buildIndex == 1)
            {
                SceneManager.LoadScene(1);
            }
            // If the player presses Escape it will return them to the main menu scene 
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
            }
        }

        // Switches the scene to the main gameplay scene when the button on the main menu is pressed
        public void StartGame()
        {
            // Change to the gameplay scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}