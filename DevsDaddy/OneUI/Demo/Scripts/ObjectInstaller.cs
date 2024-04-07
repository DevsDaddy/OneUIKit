using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace DevsDaddy.OneUI.Demo
{
    /// <summary>
    /// Object Instantiate Manager
    /// </summary>
    internal sealed class ObjectInstaller : MonoBehaviour
    {
        public Transform root;
        public List<GameObject> objectToInstantiate = new List<GameObject>();

        /// <summary>
        /// Instantiate Objects
        /// </summary>
        private void Awake() {
            foreach (var gameObj in objectToInstantiate) {
                Instantiate(gameObj, root);
            }
        }
    }
}