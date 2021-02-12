using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Root.Scripts.MonoExtension
{
    public abstract class MonoCached : MonoBehaviour
    {
        [SerializeField] private BaseMonoCachedData baseMonoCachedData = default;

        private const int CustomUpdateSize = 1000;
        private const int CustomFixedUpdateSize = 1000;
        private const int CustomLateUpdateSize = 1000;
        
        public static List<MonoCached> AllCustomUpdate = new List<MonoCached>(CustomUpdateSize);
        public static List<MonoCached> AllCustomFixedUpdate = new List<MonoCached>(CustomFixedUpdateSize);
        public static List<MonoCached> AllCustomLateUpdate = new List<MonoCached>(CustomLateUpdateSize);

        private void OnEnable()
        {
            if (baseMonoCachedData.NeedToCachedUpdate) AllCustomUpdate.Add(this);
            if (baseMonoCachedData.NeedToCachedFixedUpdate) AllCustomFixedUpdate.Add(this);
            if (baseMonoCachedData.NeedToCachedLateUpdate) AllCustomLateUpdate.Add(this);
        }

        private void OnDisable()
        {
            if (baseMonoCachedData.NeedToCachedUpdate) AllCustomUpdate.Remove(this);
            if (baseMonoCachedData.NeedToCachedFixedUpdate) AllCustomFixedUpdate.Remove(this);
            if (baseMonoCachedData.NeedToCachedLateUpdate) AllCustomLateUpdate.Remove(this);
        }

        public void CustomUpdate()
        {
            OnCustomUpdate();
        }

        public virtual void OnCustomUpdate() { }

        public void CustomFixedUpdate()
        {
            OnCustomFixedUpdate();
        }

        public virtual void OnCustomFixedUpdate() { }

        public void CustomLateUpdate()
        {
            OnCustomLateUpdate();
        }

        public virtual void OnCustomLateUpdate() { }
    }

    [Serializable]
    public class BaseMonoCachedData
    {
        [SerializeField] private bool needToCachedUpdate = false;
        [SerializeField] private bool needToCachedFixedUpdate = false;
        [SerializeField] private bool needToCachedLateUpdate = false;

        public bool NeedToCachedUpdate => needToCachedUpdate;
        public bool NeedToCachedFixedUpdate => needToCachedFixedUpdate;
        public bool NeedToCachedLateUpdate => needToCachedLateUpdate;
    }
}
