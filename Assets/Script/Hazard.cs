using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class Hazard : MonoBehaviour
    {
        public int damageValue;

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag("Player"))
            {
                GameManager.Instance.Damage(damageValue);

                if(GetComponent<MetalObject>() != null)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
