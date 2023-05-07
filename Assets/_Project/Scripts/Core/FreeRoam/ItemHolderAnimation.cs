using UnityEngine;
using DG.Tweening;
using ProjectBorderland.DeveloperTools.PublishSubscribe;

namespace ProjectBorderland.Core.FreeRoam
{
    /// <summary>
    /// Handles free roam item holder animation.
    /// </summary>
    public class ItemHolderAnimation : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private Vector3 originalPosition;
        private Quaternion originalRotation;
        private Tween drawTween;
        private Tween jiggleTween;



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Awake()
        {
            originalPosition = transform.localPosition;
            originalRotation = transform.localRotation;
            PublishSubscribe.Instance.Subscribe<OnEquipItemMessage>(PlayEquipAnimation);
            PublishSubscribe.Instance.Subscribe<OnThrowStateChangedMessage>(PlayJiggleAnimation);
        }



        private void OnDisable()
        {
            PublishSubscribe.Instance.Unsubscribe<OnEquipItemMessage>(PlayEquipAnimation);
            PublishSubscribe.Instance.Unsubscribe<OnThrowStateChangedMessage>(PlayJiggleAnimation);
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Plays item equip animation.
        /// </summary>
        private void PlayEquipAnimation(OnEquipItemMessage message)
        {
            if (drawTween != null)
            {
                drawTween.Kill();
                drawTween = null;
            }

            transform.localPosition = new Vector3(0f, -0.5f, 0f);
            drawTween = transform.DOLocalMove(new Vector3(originalPosition.x, 0f, originalPosition.z), 0.5f);
        }



        /// <summary>
        /// Plays item jiggle animation.
        /// </summary>
        private void PlayJiggleAnimation(OnThrowStateChangedMessage message)
        {
            if (message.IsReadyToThrow && jiggleTween == null)
            {
                jiggleTween = transform.DOShakeRotation(1f, new Vector3(0f, 5f, 0f), 50);
                jiggleTween.SetLoops(-1, LoopType.Restart);
            }

            else if (!message.IsReadyToThrow && jiggleTween != null)
            {
                jiggleTween.Kill();
                jiggleTween = null;

                transform.localRotation = originalRotation;
            }
        }
        #endregion
    }
}