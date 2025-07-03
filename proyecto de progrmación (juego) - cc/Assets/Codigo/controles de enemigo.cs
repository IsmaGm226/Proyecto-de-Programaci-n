using UnityEngine;

public class controlesdeenemigo : MonoBehaviour
{
    public Transform player;
    public float detectarRango = 5f;
    public float velocidadMovimiento = 2f;

    private Rigidbody2D rb;
    private Vector2 direccionMovimiento;
    private Vector2 direccionDano;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanciaAlJugador = Vector2.Distance(transform.position, player.position);

        if (distanciaAlJugador < detectarRango)
        {
            Vector2 direccion = (player.position - transform.position).normalized;

            direccionMovimiento = new Vector2(direccion.x, 0);
        }
        else
        {
            direccionMovimiento = Vector2.zero;
        } 
        rb.MovePosition(rb.position + direccionMovimiento * velocidadMovimiento * Time.deltaTime);
    }

}
