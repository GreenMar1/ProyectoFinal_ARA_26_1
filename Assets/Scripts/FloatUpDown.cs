using UnityEngine;

public class FloatUpDown : MonoBehaviour
{
    [Header("Configuración del movimiento")]
    public float amplitude = 0.5f;   // Qué tan alto/bajo se mueve
    public float speed = 2f;         // Qué tan rápido se mueve

    private Vector3 startPos;

    void Start()
    {
        // Guardamos la posición original
        startPos = transform.localPosition;
    }

    void Update()
    {
        // Movimiento vertical suave usando seno
        float offset = Mathf.Sin(Time.time * speed) * amplitude;

        transform.localPosition = new Vector3(
            startPos.x,
            startPos.y + offset,
            startPos.z
        );
    }
}
