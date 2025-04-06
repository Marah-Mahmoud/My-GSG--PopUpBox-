using UnityEngine;
// open box when mouse button(0) and not use this script now
public class PopupBox : MonoBehaviour
{
    public Transform lid;
    public float openAngle = 90f;
    public float speed = 2f;
    private bool isOpen = false;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            isOpen = true;
        }

        if (isOpen)
        {
            Quaternion targetRotation = Quaternion.Euler(openAngle, 0, 0);
            lid.localRotation = Quaternion.Lerp(lid.localRotation, targetRotation, Time.deltaTime * speed);
        }
    }
}
