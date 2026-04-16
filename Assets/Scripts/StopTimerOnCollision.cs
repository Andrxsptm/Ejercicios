using UnityEngine;

public class StopTimerOnCollision : MonoBehaviour
{
    public string stopTag = "Finish";

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.CompareTag(stopTag) && GameEngine.Instance != null)
            GameEngine.Instance.StopTimer();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider != null && collision.collider.CompareTag(stopTag) && GameEngine.Instance != null)
            GameEngine.Instance.StopTimer();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.CompareTag(stopTag) && GameEngine.Instance != null)
            GameEngine.Instance.StopTimer();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider != null && collision.collider.CompareTag(stopTag) && GameEngine.Instance != null)
            GameEngine.Instance.StopTimer();
    }
}
