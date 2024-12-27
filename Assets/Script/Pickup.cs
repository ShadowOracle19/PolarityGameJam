using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class Pickup : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            if(other.transform.CompareTag("Player"))
            {
                PickUpCoin();
            }
        }
        
        public void PickUpCoin()
        {
            Destroy(gameObject);
        }
    }
}
