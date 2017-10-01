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

        private float m_OffsetZ;
        private Vector3 m_LastTargetPosition;
        private Vector3 m_CurrentVelocity;
        private Vector3 m_LookAheadPos;

        public MovementDirection currentDirection = MovementDirection.Right;

        Vector3 aheadTargetPos = Vector3.zero;
        float xMoveDelta;
        bool updateLookAheadTarget = false;
        Vector3 newPos = Vector3.zero;

        // Use this for initialization
        private void Start()
        {
            m_LastTargetPosition = target.position;
            switch (currentDirection)
            {
                case MovementDirection.Up:
                    m_OffsetZ = (transform.position - target.position).y;
                    transform.parent = null;
                    break;
                case MovementDirection.Down:
                    m_OffsetZ = (transform.position - target.position).y;
                    transform.parent = null;
                    break;
                case MovementDirection.Left:
                    m_OffsetZ = (transform.position - target.position).z;
                    transform.parent = null;
                    break;
                case MovementDirection.Right:
                    m_OffsetZ = (transform.position - target.position).z;
                    transform.parent = null;
                    break;
                default:
                    m_OffsetZ = (transform.position - target.position).z;
                    transform.parent = null;
                    break;
            }

        }

        // Update is called once per frame
        private void Update()
        {

            switch (currentDirection)
            {
                case MovementDirection.Up:
                    // only update lookahead pos if accelerating or changed direction
                    xMoveDelta = (target.position - m_LastTargetPosition).y;

                    updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

                    if (updateLookAheadTarget)
                    {
                        m_LookAheadPos = lookAheadFactor * Vector3.up * Mathf.Sign(xMoveDelta);
                    }
                    else
                    {
                        m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
                    }

                    aheadTargetPos = target.position + m_LookAheadPos + Vector3.up * m_OffsetZ;

                    newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

                    transform.position = new Vector3(transform.position.x, newPos.y, transform.position.z);

                    break;
                case MovementDirection.Down:

                    // only update lookahead pos if accelerating or changed direction
                    xMoveDelta = (target.position - m_LastTargetPosition).y;

                    updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

                    if (updateLookAheadTarget)
                    {
                        m_LookAheadPos = lookAheadFactor * Vector3.up * Mathf.Sign(xMoveDelta);
                    }
                    else
                    {
                        m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
                    }

                    aheadTargetPos = target.position + m_LookAheadPos + Vector3.up * m_OffsetZ;

                    newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

                    transform.position = new Vector3(transform.position.x, newPos.y, transform.position.z);

                    break;
                case MovementDirection.Left:
                    // only update lookahead pos if accelerating or changed direction
                    xMoveDelta = (target.position - m_LastTargetPosition).x;

                    updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

                    if (updateLookAheadTarget)
                    {
                        m_LookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
                    }
                    else
                    {
                        m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
                    }

                    aheadTargetPos = target.position + m_LookAheadPos + Vector3.forward * m_OffsetZ;

                    newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

                    transform.position = new Vector3(newPos.x, transform.position.y, newPos.z);
                    break;
                case MovementDirection.Right:
                    // only update lookahead pos if accelerating or changed direction
                    xMoveDelta = (target.position - m_LastTargetPosition).x;

                    updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

                    if (updateLookAheadTarget)
                    {
                        m_LookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
                    }
                    else
                    {
                        m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
                    }

                    aheadTargetPos = target.position + m_LookAheadPos + Vector3.forward * m_OffsetZ;

                    newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

                    transform.position = new Vector3(newPos.x, transform.position.y, newPos.z);
                    break;
                default:
                    // only update lookahead pos if accelerating or changed direction
                    xMoveDelta = (target.position - m_LastTargetPosition).x;

                    updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

                    if (updateLookAheadTarget)
                    {
                        m_LookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
                    }
                    else
                    {
                        m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
                    }

                    aheadTargetPos = target.position + m_LookAheadPos + Vector3.forward * m_OffsetZ;

                    newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

                    transform.position = newPos;
                    break;
            }




            m_LastTargetPosition = target.position;
        }
    }
}
