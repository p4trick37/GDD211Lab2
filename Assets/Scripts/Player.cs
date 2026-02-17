//using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float mouseSens;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private GameManager gm;
    public int enemiesKilled;
    public int health;
    public int maxHealth = 50;
    public static int highScore;

    private void Start()
    {
        health = maxHealth;
    }


    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * mouseSens, 0);
        }

        if(health <= 0)
        {
            gm.Death();
        }


    } 

    public void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit))
        {
            Enemy enemy = hit.transform.gameObject.GetComponent<Enemy>();

            if (enemy != null)
            {
                Destroy(enemy.gameObject);
                enemiesKilled++;
            }
        }
    }
}
