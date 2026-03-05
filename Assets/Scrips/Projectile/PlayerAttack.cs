using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] private float attckCooldown;

    [SerializeField] private Transform firePoint;
    
    [SerializeField] private GameObject[] fireballs;

    private Animator anim;
    
    private PlayerMovement playerMovement;

    private float cooldownTimer = Math.Infinty;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();

    }

    private void Update()
    {
        if(Input.GetMouseButton(0) && cooldownTimer > attckCooldown && playerMovement.canAttack())
            Attack();

        cooldownTimer += cooldownTimer.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        fireballs[0].transform.position = firePoint.position;
        fireballs[0].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
}
