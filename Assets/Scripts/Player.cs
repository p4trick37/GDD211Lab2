using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float mouseSens;

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * mouseSens, 0);
        }
    }

    
}
