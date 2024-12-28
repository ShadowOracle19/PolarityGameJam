using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class HealthPickup : MonoBehaviour
    {
        public int healthValue;
        
        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                FindObjectOfType<GameManager>().UpdateHealth(healthValue);

                Destroy(gameObject);
            }
        }
    }
}
