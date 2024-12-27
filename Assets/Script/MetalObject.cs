using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Platformer
{
    public class MetalObject : MonoBehaviour
    {
        public bool inAttractionRange = false;
        public Transform playerPosition;
        Rigidbody _rigidbody;
        public float force = 1;

        // Start is called before the first frame update
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            if(inAttractionRange)
            {
                if(PlayerMagnitism.Instance.magnickSetting)
                {
                    Vector3 dir = (transform.position - new Vector3(playerPosition.position.x, playerPosition.position.y + 2f, playerPosition.position.z)).normalized;
                    _rigidbody.AddForce(dir * force, ForceMode.Impulse);
                }
                else
                {
                    Vector3 dir = (transform.position - new Vector3(playerPosition.position.x, playerPosition.position.y + 2f, playerPosition.position.z)).normalized;
                    _rigidbody.AddForce(-dir * force, ForceMode.Impulse);
                }

                

                //_rigidbody.MovePosition(Vector3.MoveTowards(transform.position, new Vector3(playerPosition.position.x, playerPosition.position.y + 2f, playerPosition.position.z), 0.003f));
                //transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerPosition.position.x, playerPosition.position.y + 2f, playerPosition.position.z), 0.003f);
            }
        }
    }
}
