using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PopUp
{
    public class OpenBook : MonoBehaviour
    {
        [Header("Settings")]
        public float bookRotationSensitivity = 200.0f;
        public float maxOpenAngle = 150.0f;

        [Header("Scalable Content")]
        public Transform[] scalableObjects; 
        private Vector3[] originalScales;

        private float xAngle = 0.0f;

        void Start()
        {
            originalScales = new Vector3[scalableObjects.Length];
            for (int i = 0; i < scalableObjects.Length; i++)
            {
                originalScales[i] = scalableObjects[i].localScale;
            }
        }

        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                xAngle += Input.GetAxis("Mouse Y") * bookRotationSensitivity * Time.deltaTime;
                xAngle = Mathf.Clamp(xAngle, 0, maxOpenAngle);
                transform.rotation = Quaternion.Euler(xAngle, 0, 0);
            }

            float openPercent = Mathf.Clamp01(xAngle / maxOpenAngle);

            for (int i = 0; i < scalableObjects.Length; i++)
            {
                Vector3 targetScale = Vector3.Lerp(Vector3.zero, originalScales[i], openPercent);
                scalableObjects[i].localScale = targetScale;
            }
        }
    }
}
