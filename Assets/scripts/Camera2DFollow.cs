using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Camera2DFollow : MonoBehaviour
    {
        public Transform target;
        public float damping = 1;
        public float lookAheadFactor = 3;
        public float lookAheadReturnSpeed = 0.5f;
        public float lookAheadMoveThreshold = 0.1f;
        public float lowY;
        private float initialLowY;
        public Transform startMap;
        public Transform endMap;
        public float cameraSize;

        public bool followYplayer;

        private float m_OffsetZ;
        private Vector3 m_LastTargetPosition;
        private Vector3 m_CurrentVelocity;
        private Vector3 m_LookAheadPos;


        // Use this for initialization
        private void Start()
        {
            //target.position.Set(target.position.x, lowY, target.position.z);
            m_LastTargetPosition = new Vector3(target.position.x, lowY, target.position.z);
            m_OffsetZ = (transform.position - target.position).z;
            transform.parent = null;
            initialLowY = lowY;
           

        }


        // Update is called once per frame
        private void Update()
        {
            if (followYplayer)
            {
				if (target.position.y > initialLowY)
					lowY = target.position.y;
				else 
					lowY = initialLowY;
            }
            else {
                lowY = initialLowY;
            }
            Vector3 posZero;
            if (target.position.x > (startMap.position.x+(cameraSize)) && target.position.x < (endMap.position.x - (cameraSize))) { 
            posZero = new Vector3(target.position.x, lowY, target.position.z);
           
            // only update lookahead pos if accelerating or changed direction
            float xMoveDelta = (posZero - m_LastTargetPosition).x;

            bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

            if (updateLookAheadTarget)
            {
                m_LookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
            }
            else
            {
                m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
            }


            Vector3 aheadTargetPos = posZero + m_LookAheadPos + Vector3.forward * m_OffsetZ;
            Vector3 newPos = Vector3.SmoothDamp(posZero, aheadTargetPos, ref m_CurrentVelocity, damping);

            transform.position = newPos;

            m_LastTargetPosition = new Vector3(target.position.x, lowY, target.position.z);
            }
            else
            {
                posZero = new Vector3(transform.position.x, lowY, transform.position.z);

            
                transform.position = new Vector3(transform.position.x, lowY, target.position.z);

                m_LastTargetPosition = new Vector3(transform.position.x, lowY, target.position.z);


            }
        }
    }
}
