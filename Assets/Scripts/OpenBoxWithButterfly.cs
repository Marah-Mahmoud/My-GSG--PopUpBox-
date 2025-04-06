using UnityEngine;
//that code to box
namespace PopUp
{
    public class OpenBoxWithButterfly : MonoBehaviour
    {
        public GameObject butterfly;
        // public float flySpeed = 2f; 
        // public float flyHeight = 5f;  
        //public KeyCode launchKey = KeyCode.Space;

        private float bookRotationSensitivity = 200.0f;
        private float xAngle = 0.0f;
        private bool butterflyFlying = false;
        private Vector3 butterflyStartPos;
        private Vector3 butterflyTargetPos;

        void Start()
        {
            if (butterfly != null)
            {
                butterflyStartPos = butterfly.transform.position;
                //butterflyTargetPos = butterflyStartPos + Vector3.up * flyHeight;
                butterfly.SetActive(false);
            }
        }

        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                xAngle += Input.GetAxis("Mouse Y") * bookRotationSensitivity * Time.deltaTime;
                xAngle = Mathf.Clamp(xAngle, 0, 150);
                transform.rotation = Quaternion.Euler(xAngle, 0, 0);
            }

            if (Input.GetKeyDown(KeyCode.Space) && !butterflyFlying && butterfly != null)
            {
                butterfly.SetActive(true);
                butterflyFlying = true;
            }

            // butterfly movement
            // if (butterflyFlying && butterfly != null)
            // {
            //     float yOffset = Mathf.Sin(Time.time * 5f) * 0.2f;
            //     butterfly.transform.position = Vector3.MoveTowards(butterfly.transform.position, butterflyTargetPos, flySpeed * Time.deltaTime)
            //     + new Vector3(0f, yOffset, 0f);
            // }
        }
    }
}