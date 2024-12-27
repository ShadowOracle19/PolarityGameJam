using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class PlayerMagnitism : MonoBehaviour
    {
        #region dont touch this
        private static PlayerMagnitism _instance;
        public static PlayerMagnitism Instance
        {
            get
            {
                if (_instance is null)
                {
                    Debug.LogError("PlayerMagnitism is NULL");
                }

                return _instance;
            }
        }

        private void Awake()
        {
            _instance = this;
        }
        #endregion

        public bool magnickSetting = false; //false - attract, true - repulse
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                magnickSetting = !magnickSetting;

                if(magnickSetting)
                {
                    GetComponent<MeshRenderer>().material.color = new Color(0, 0, 1, 0.16f);
                }
                else
                {
                    GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.16f);
                }
            }
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
