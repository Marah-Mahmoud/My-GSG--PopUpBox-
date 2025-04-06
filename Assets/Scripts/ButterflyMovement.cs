using UnityEngine;
namespace PopUp
{
    public class ButterflyMovement : MonoBehaviour
    {
        public float speed = 2f;
        public float height = 0.5f;
        public float frequency = 1f;
        public float flyProgressSpeed = 0.2f;
        //public KeyCode resetKey = KeyCode.R;
        //public KeyCode flyKey = KeyCode.Space;

        public Vector3 startPos;
        public Vector3 exitPos;

        private float t = 0f;
        private float timeOffset;
        private bool isFlying = true;

        void Start()
        {
            startPos = transform.position;
            exitPos = startPos + new Vector3(2f, 3f, 0f);
            timeOffset = Random.Range(0f, Mathf.PI * 2);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                t = 0f;
                isFlying = true;
                timeOffset = Random.Range(0f, Mathf.PI * 2);
            }

            if (isFlying)
            {
                transform.localScale = new Vector3(.2f, .2f, .2f);
                t += Time.deltaTime * flyProgressSpeed;
                t = Mathf.Clamp01(t);

                float x = Mathf.Sin(Time.time * speed + timeOffset) * 0.2f;
                float y = Mathf.Cos(Time.time * frequency + timeOffset) * height;

                Vector3 move = Vector3.Lerp(startPos, exitPos, t);
                transform.position = move + new Vector3(x, y, 0f);
            }

            if (Input.GetKeyDown(KeyCode.R)) //retun butterfly hidden
            {
                t = 0f;
                isFlying = false;
                transform.position = startPos;
                //transform.localScale = new Vector3(0, 0, 0);
            }
        }
    }
}