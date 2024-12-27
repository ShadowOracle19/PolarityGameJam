using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class PlayerMagnitism : MonoBehaviour
    {
        
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.transform.CompareTag("Metal"))
            {
                other.GetComponent<MetalObject>().inAttractionRange = true;
                other.GetComponent<MetalObject>().playerPosition = transform;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.transform.CompareTag("Metal"))
            {
                other.GetComponent<MetalObject>().inAttractionRange = false;
            }

        }
    }
}
