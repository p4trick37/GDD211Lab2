using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Player player;
    public int damage;
    [SerializeField] private Animator ani;

    private void Start()
    {
        player = FindAnyObjectByType<Player>();
        ani = FindAnyObjectByType<Animator>();
    }
    private void Update()
    {
        float angle = Mathf.Atan(transform.position.z / transform.position.x);
        if(angle < 0)
        {
            angle += 180 * Mathf.Deg2Rad;
        }
        float moveX = Mathf.Cos(angle);
      
        float moveZ = Mathf.Sin(angle);
        transform.position += new Vector3(-moveX, 0, -moveZ) * speed * Time.deltaTime;

    }

    public void OnTriggerEnter(Collider other)
    {
        Player user = other.GetComponent<Player>();
        if(user != null)
        {
            player.health -= damage;
            Destroy(gameObject);
            ani.SetBool("GotHit", true);
        }
    }
}
