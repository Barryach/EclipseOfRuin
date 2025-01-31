using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 3;

    [Header("Combat")]
    [SerializeField] float attackCD = 3f;
    [SerializeField] float attackRange = 1f;
    [SerializeField] float aggroRange = 4f;

    GameObject player;
    NavMeshAgent agent;
    Animator animator;
    float timePassed;
    float newDestinationCD = 0.5f;

    [Header("Punch Range")]
    [SerializeField] CapsuleCollider punchCollider;  // CapsuleCollider para el golpe

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        // Desactivar el collider de golpe al inicio
        punchCollider.enabled = false;
    }

    private void Update()
    {
        if (timePassed >= attackCD)
        {
            if (Vector3.Distance(player.transform.position, transform.position) <= attackRange)
            {
                animator.SetTrigger("attack");
                timePassed = 0;
                // Activar el collider de golpe
                punchCollider.enabled = true;
            }
        }
        timePassed += Time.deltaTime;

        if (newDestinationCD <= 0 && Vector3.Distance(player.transform.position, transform.position) <= aggroRange)
        {
            newDestinationCD = 0.5f;
            agent.SetDestination(player.transform.position);
        }
        newDestinationCD -= Time.deltaTime;
        transform.LookAt(player.transform);
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        animator.SetTrigger("damage");

        if (health <= 0)
        {
            Die();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra en el trigger es el jugador
        if (other.CompareTag("Player"))
        {
            // Imprime un mensaje en la consola para confirmar que la colisión ha ocurrido
            Debug.Log("¡El enemigo ha tocado al jugador!");
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }

    // Llamado cuando el jugador sale del rango de ataque
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            punchCollider.enabled = false;  // Desactiva el collider de golpe cuando el jugador se aleja
        }
    }
}
