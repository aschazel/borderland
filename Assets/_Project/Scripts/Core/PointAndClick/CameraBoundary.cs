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
            Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);

            Vector3 xMinimum = new Vector3(0f - MinimumCameraConstraint.x, 0f, 0f);
            Vector3 xMaximum = new Vector3(0f + MaximumCameraConstraint.x, 0f, 0f);
            Gizmos.DrawLine(Vector3.zero, xMinimum);
            Gizmos.DrawLine(Vector3.zero, xMaximum);

            Vector3 yMinimum = new Vector3(0f, 0f - MinimumCameraConstraint.y, 0f);
            Vector3 yMaximum = new Vector3(0f, 0f + MaximumCameraConstraint.y, 0f);
            Gizmos.DrawLine(Vector3.zero, yMinimum);
            Gizmos.DrawLine(Vector3.zero, yMaximum);

            Vector3 zMinimum = new Vector3(0f, 0f, 0f - MinimumCameraConstraint.z);
            Vector3 zMaximum = new Vector3(0f, 0f, 0f + MaximumCameraConstraint.z);
            Gizmos.DrawLine(Vector3.zero, zMinimum);
            Gizmos.DrawLine(Vector3.zero, zMaximum);
        }
        #endregion
    }
}