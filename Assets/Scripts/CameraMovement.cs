using UnityEngine;
namespace PopUp
{
    public class CameraMovement : MonoBehaviour
    {
        public Transform target;
        public float zoomSpeed = .0001f;
        public float minDistance = 5.0f;
        public float maxDistance = 10.0f;
        public float smoothSpeed = 0.001f;
        private Camera cam;

        void Start()
        {
            cam = Camera.main;
        }

        void LateUpdate()
        {
            if (target != null)
            {
                float distance = Vector3.Distance(cam.transform.position, target.position);
                float targetDistance = Mathf.Clamp(distance, minDistance, maxDistance);

                Vector3 desiredPosition = target.position - target.forward * targetDistance;
                desiredPosition.y = target.position.y + 3;

                cam.transform.position = Vector3.Lerp(cam.transform.position, desiredPosition, smoothSpeed);
                cam.transform.LookAt(target);
            }
        }
    }
}