using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class GameManager : MonoBehaviour
    {
        public int currentHealth;
        public int maxHealth;

        public bool gameOver; 
        
        // Start is called before the first frame update
        void Start()
        {
            maxHealth = 3;
            currentHealth = maxHealth;

            gameOver = false;
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void UpdateHealth(int healthUpdated)
        {
            //currentHealth += healthUpdated;

            if (currentHealth+healthUpdated !> maxHealth && currentHealth < maxHealth)
            {
                currentHealth += healthUpdated; 
            } 
            else if (healthUpdated <= 0 && currentHealth == 1)
            {
                currentHealth += healthUpdated;
                gameOver = true;
            }
            else if (healthUpdated <= 0 && currentHealth <= maxHealth)
            {
                currentHealth += healthUpdated;
            }
        }
    }
}
