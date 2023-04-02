using UnityEngine;

namespace ProjectBorderland.Core.PointAndClick
{
    /// <summary>
    /// Handles point and click camera boundary.
    /// </summary>
    public class CameraBoundary : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        [Header("Attribute Configurations")]
        public Vector3 MinimumCameraConstraint;
        public Vector3 MaximumCameraConstraint;



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void OnDrawGizmosSelected()
        {
            DrawConstraintGizmos();
        }



        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, 0.1f);
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Draws camera constraint gizmos.
        /// </summary>
        private void DrawConstraintGizmos()
        {
            Gizmos.color = Color.green;

            Vector3 xMinimum = new Vector3(transform.position.x - MinimumCameraConstraint.x, transform.position.y, transform.position.z);
            Vector3 xMaximum = new Vector3(transform.position.x + MaximumCameraConstraint.x, transform.position.y, transform.position.z);
            Gizmos.DrawLine(transform.position, xMinimum);
            Gizmos.DrawLine(transform.position, xMaximum);

            Vector3 yMinimum = new Vector3(transform.position.x, transform.position.y - MinimumCameraConstraint.y, transform.position.z);
            Vector3 yMaximum = new Vector3(transform.position.x, transform.position.y + MaximumCameraConstraint.y, transform.position.z);
            Gizmos.DrawLine(transform.position, yMinimum);
            Gizmos.DrawLine(transform.position, yMaximum);

            Vector3 zMinimum = new Vector3(transform.position.x, transform.position.y, transform.position.z - MinimumCameraConstraint.z);
            Vector3 zMaximum = new Vector3(transform.position.x, transform.position.y, transform.position.z + MaximumCameraConstraint.z);
            Gizmos.DrawLine(transform.position, zMinimum);
            Gizmos.DrawLine(transform.position, zMaximum);
        }
        #endregion
    }
}