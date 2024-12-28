using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class MovingPlatform : MonoBehaviour
    {
        public Transform point1, point2;
        public int platformSpeed;
        public bool pingPong;

        public GameObject target;
        private Vector3 offset;
        
        // Start is called before the first frame update
        void Start()
        {
            target = null;
        }

        // Update is called once per frame
        void Update()
        {
            float step = platformSpeed * Time.deltaTime;
            if (pingPong)
            {
                transform.position = Vector3.MoveTowards(transform.position, point1.position, step);
                if(transform.position == point1.position)
                {
                    pingPong = false;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, point2.position, step);
                if (transform.position == point2.position)
                {
                    pingPong = true;
                }
            }
        }

        private void LateUpdate()
        {
            if (target != null)
            {
                target.transform.position = transform.position + offset;
            }
        }

        //private void OnTriggerEnter(Collider other)
        //{
        //    if (other.gameObject.CompareTag("Player"))
        //    {
        //        target = other.gameObject;
        //        offset = target.transform.position - transform.position;
        //    }
        //}

        //private void OnTriggerExit(Collider other)
        //{
        //    if (other.gameObject.CompareTag("Player"))
        //    {
        //        target = null;
        //    }
        //}
        
        
    }
}
