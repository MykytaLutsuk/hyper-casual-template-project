using UnityEngine;

namespace _Tools
{
    [ExecuteAlways]
    [SelectionBase]
    public class RepeatedObject : MonoBehaviour
    {
        [SerializeField] private Vector3 offset = Vector3.forward;
        [Min(1)] [SerializeField] private int count = 1;

        private void Start()
        {
            if (Application.IsPlaying(this))
            {
                CorrectChildCount();
                Destroy(this);
            }
        }

        private void Update()
        {
            CorrectChildCount();
        }

        private void CorrectChildCount()
        {
            count = Mathf.Clamp(count, 1, 1000);

            if (transform.childCount < count)
            {
                for (int i = transform.childCount; i < count; i++)
                {
                    Transform instantiate = Instantiate(transform.GetChild(0), transform);
                    instantiate.Translate(offset * i);
                }
            }
            else if (count < transform.childCount)
            {
                for (int i = transform.childCount - 1; i >= count; i--)
                {
                    DestroyImmediate(transform.GetChild(i).gameObject);
                }
            }
        }
    }
}
