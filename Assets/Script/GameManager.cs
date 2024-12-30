using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Platformer
{
    public class GameManager : MonoBehaviour
    {

        #region dont touch this
        private static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                if (_instance is null)
                {
                    Debug.LogError("GameManager is NULL");
                }

                return _instance;
            }
        }

        private void Awake()
        {
            _instance = this;
        }
        #endregion

        public int currentHealth;
        public int maxHealth;

        public int collectableAmount;
        public int maxCollectables;
        public Transform collectableParent;
        public TextMeshProUGUI collectableText;

        public bool gameOver;
        public bool gameWon;
        
        // Start is called before the first frame update
        void Start()
        {
            maxHealth = 3;
            currentHealth = maxHealth;

            gameOver = false;
            gameWon = false;

            foreach (Transform coin in collectableParent)
            {
                if(coin.gameObject.GetComponent<Pickup>() != null)
                {
                    maxCollectables += 1;
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            collectableText.text = "Gears Collected: \n     " + collectableAmount.ToString() + "/" + maxCollectables.ToString();

            if(collectableAmount == maxCollectables)
            {
                gameWon = true;
            }
        }

        public void Heal(int healValue)
        {
            currentHealth += healValue;
        }

        public void Damage(int damageValue)
        {
            currentHealth -= damageValue;
            if(currentHealth <= 0)
            {
                gameOver = true;
            }
        }
    }
}
