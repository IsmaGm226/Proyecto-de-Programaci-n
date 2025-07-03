using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class MovimientoJugador : MonoBehaviour
{
    // Velocidad de movimiento horizontal del jugador
    public float velocidad = 5f;

    // Fuerza con la que el jugador salta
    public float fuerzasalto = 6f;

    // Longitud del raycast para detectar el suelo
    public float longitudRaycast = 0.1f;

    // Capa que se utiliza para identificar el suelo
    public LayerMask capaSuelo;

    // Indica si el jugador está tocando el suelo
    private bool enSuelo;

    // Componente Rigidbody2D para aplicar física
    private Rigidbody2D rb;

    // Controlador de animaciones
    public Animator animator;

    // Se llama una vez al inicio del juego
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Se obtiene el componente Rigidbody2D del objeto
    }

    // Se llama una vez por cada frame
    private void Update()
    {
        // Movimiento horizontal con las teclas A/D o flechas izquierda/derecha
        float velocidadX = Input.GetAxis("Horizontal") * velocidad * Time.deltaTime;

        // Se actualiza el parámetro 'movement' en el Animator con la velocidad
        animator.SetFloat("movement", velocidadX * velocidad);

        // Gira el sprite según la dirección en la que se mueve
        if (velocidadX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (velocidadX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        // Se actualiza la posición del jugador manualmente (sin física)
        Vector3 posicion = transform.position;
        transform.position = new Vector3(posicion.x + velocidadX, posicion.y, posicion.z);

        // Se lanza un raycast hacia abajo para comprobar si el jugador está en el suelo
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, longitudRaycast, capaSuelo);
        enSuelo = hit.collider != null;

        // Si está en el suelo y se presiona la flecha arriba o la tecla W, se salta
        if (enSuelo && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
        {
            rb.AddForce(new Vector2(0f, fuerzasalto), ForceMode2D.Impulse);
        }

        // Se actualiza el parámetro 'ensuelo' en el Animator para controlar animaciones de salto
        animator.SetBool("ensuelo", enSuelo);
    }

    // Método para dibujar en la escena el raycast en el editor (útil para debug)
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * longitudRaycast);
    }
}
