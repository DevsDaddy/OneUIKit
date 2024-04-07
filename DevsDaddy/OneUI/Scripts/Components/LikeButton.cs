using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DevsDaddy.OneUI.Scripts.Components
{
    [RequireComponent(typeof(Animator))]
    [DisallowMultipleComponent]
    [AddComponentMenu("One UI/Components/Like Button")]
    public class LikeButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
    {
        // General Parameters
        [Header("General Setup")]
        [SerializeField] private bool IsLikedAtStart = false;
        
        // Callbacks
        public Action<bool> OnLikeStateChanged;

        // Required Components
        private Animator m_CurrentAnimator;

        public bool isActive = false;
        private static readonly int hover = Animator.StringToHash("Hover");
        private static readonly int press = Animator.StringToHash("Press");
        private static readonly int active = Animator.StringToHash("isActive");

        /// <summary>
        /// On Like Button Awake
        /// </summary>
        private void Awake() {
            m_CurrentAnimator = GetComponent<Animator>();
        }

        /// <summary>
        /// On Like Button Start
        /// </summary>
        private void Start() {
            SetLiked(IsLikedAtStart);
        }

        /// <summary>
        /// On Pointer Click
        /// </summary>
        /// <param name="pointerEventData"></param>
        public void OnPointerClick(PointerEventData pointerEventData) {
            ToggleLiked();
            m_CurrentAnimator.SetTrigger(press);
        }

        /// <summary>
        /// On Pointer Enter
        /// </summary>
        /// <param name="pointerEventData"></param>
        public void OnPointerEnter(PointerEventData pointerEventData) {
            m_CurrentAnimator.SetTrigger(hover);
        }

        /// <summary>
        /// Set Liked
        /// </summary>
        /// <param name="isLiked"></param>
        public void SetLiked(bool isLiked) {
            isActive = isLiked;
            m_CurrentAnimator.SetBool(active, isActive);
            OnLikeStateChanged?.Invoke(isActive);
        }

        /// <summary>
        /// Toggle Liked State
        /// </summary>
        public void ToggleLiked() {
            SetLiked(!isActive);
        }
    }
}