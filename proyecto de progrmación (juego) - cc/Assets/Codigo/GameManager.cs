  using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int PuntosTotales { get { return puntosTotales; } }
    private int puntosTotales;

    public void SumarPuntos(int puntosAsumar) 
    {
        puntosTotales += puntosAsumar;
        Debug.Log(puntosTotales);
    }
}
