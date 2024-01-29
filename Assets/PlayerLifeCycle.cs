using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifeCycle : MonoBehaviour
{
    private Animator animator;

    private Rigidbody2D playerRb;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        playerRb.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("DeathTrigger");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
