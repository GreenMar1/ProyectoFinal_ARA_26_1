using UnityEngine;

public class JumpEffect : MonoBehaviour
{
    public float jumpHeight = 0.3f;      // Altura del brinco
    public float jumpSpeed = 5f;        // Velocidad del brinco

    private Vector3 originalPosition;
    private bool isJumping = false;

    void Start()
    {
        originalPosition = transform.localPosition;
    }

    public void Jump()
    {
        if (!isJumping)
            StartCoroutine(JumpRoutine());
    }

    private System.Collections.IEnumerator JumpRoutine()
    {
        isJumping = true;

        Vector3 targetUp = originalPosition + Vector3.up * jumpHeight;

        // SUBIR
        while (Vector3.Distance(transform.localPosition, targetUp) > 0.01f)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetUp, Time.deltaTime * jumpSpeed);
            yield return null;
        }

        // BAJAR
        while (Vector3.Distance(transform.localPosition, originalPosition) > 0.01f)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, originalPosition, Time.deltaTime * jumpSpeed);
            yield return null;
        }

        isJumping = false;
    }
}
