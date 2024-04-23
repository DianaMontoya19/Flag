using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cinematica : MonoBehaviour
{
    public string gameSceneName; // Nombre de la escena del juego principal
    public float cinematicDuration = 10f; // Duración de la cinemática en segundos

    private bool cinematicFinished = false;

    void Start()
    {
        // Inicia la corutina que controla la cinemática
        StartCoroutine(PlayCinematic());
    }

    IEnumerator PlayCinematic()
    {
        // Reproduce la cinemática
        // Aquí debes colocar el código para reproducir tu cinemática
        // Puedes usar la función yield return new WaitForSeconds() para esperar un tiempo antes de continuar

        yield return new WaitForSeconds(cinematicDuration);

        // La cinemática ha terminado, establece la bandera de finalización en true
        cinematicFinished = true;

        // Carga la escena del juego principal
        SceneManager.LoadScene(gameSceneName);
    }
}
