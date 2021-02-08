using TMPro;
using UnityEngine;

namespace _Root.Scripts.Utility
{
    [RequireComponent(typeof(TMP_Text))]
    public class FpsCounter : MonoBehaviour
    {
        const float FpsMeasurePeriod = 0.5f;
        private int _mFpsAccumulator;
        private float _mFpsNextPeriod;
        private int _mCurrentFps;
        
        [SerializeField]
        private TMP_Text _text;

        private void Start()
        {
            _mFpsNextPeriod = Time.realtimeSinceStartup + FpsMeasurePeriod;
        }

        private void Update()
        {
            // measure average frames per second
            _mFpsAccumulator++;
            if (Time.realtimeSinceStartup > _mFpsNextPeriod)
            {
                _mCurrentFps = (int) (_mFpsAccumulator / FpsMeasurePeriod);
                _mFpsAccumulator = 0;
                _mFpsNextPeriod += FpsMeasurePeriod;
                _text.text = _mCurrentFps.ToString();
            }
        }
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            _text = GetComponent<TMP_Text>();
        }
#endif
    }
}