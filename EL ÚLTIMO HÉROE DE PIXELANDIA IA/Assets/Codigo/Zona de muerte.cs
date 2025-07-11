using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para recargar la escena

public class MuertePorVacio : MonoBehaviour
{
    // Esta funci�n se llama cuando otro Collider 2D entra en este trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Comprueba si el objeto que entr� en el trigger tiene la etiqueta "Player"
        if (other.CompareTag("Player"))
        {
            Morir();
        }
    }

    void Morir()
    {
        Debug.Log("�El personaje ha ca�do al vac�o y ha muerto!");

        // Aqu� es donde en el futuro agregar�s la l�gica del men� de "perdiste".
        // Por ahora, simplemente recargaremos la escena actual.

        // Puedes guardar el �ndice de la escena actual para recargarla
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);

        // O tambi�n puedes recargarla por nombre:
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}