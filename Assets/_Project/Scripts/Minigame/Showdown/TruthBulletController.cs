using TMPro;
using UnityEngine;
using ProjectBorderland.Evidence;

namespace ProjectBorderland.Minigame.Showdown
{
    /// <summary>
    /// Handles truth bullet shooting mechanics.
    /// </summary>
    public class TruthBulletController : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        public EvidenceSO Evidence;

        [Header("Attribute Configurations")]
        [SerializeField] private float speed = 5f;

        [Header("Object References")]
        [SerializeField] private Transform truthBullet;
        [SerializeField] private Transform target;



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Update()
        {
            Shoot();
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Shoots truth bullet to target.
        /// </summary>
        private void Shoot()
        {
            if (Vector3.Distance(truthBullet.transform.position, target.position) > 0.1f)
            {
                truthBullet.transform.position = Vector3.MoveTowards(truthBullet.transform.position, target.position, speed * Time.deltaTime);
                truthBullet.transform.LookAt(target.position);
            }
        }
        #endregion
    }
}