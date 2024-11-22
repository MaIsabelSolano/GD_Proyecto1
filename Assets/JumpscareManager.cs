using UnityEngine;
using System.Collections;

public class JumpscareManager : MonoBehaviour
{
    public Canvas jumpscareCanvas; // Canvas del jumpscare
    public AudioSource audioSource; // Sonido del jumpscare
    public float jumpscareDuration = 2f; // Duración del jumpscare

    private float previousTimeScale; // Guardar el Time.timeScale previo

    private void Start()
    {
        jumpscareCanvas.gameObject.SetActive(false); // Asegúrate de que esté desactivado al inicio
        if (audioSource != null)
        {
            audioSource.ignoreListenerPause = true; // Ignorar la pausa global del AudioListener
        }
    }

    public void TriggerJumpscare()
    {
        StartCoroutine(ShowJumpscare());
    }

    private IEnumerator ShowJumpscare()
    {
        // Pausar el juego
        previousTimeScale = Time.timeScale;
        Time.timeScale = 0; // Pausar el tiempo
        AudioListener.pause = true; // Pausar los sonidos globales
        Cursor.lockState = CursorLockMode.None; // Liberar el cursor si está bloqueado

        // Mostrar el jumpscare
        jumpscareCanvas.gameObject.SetActive(true);

        if (audioSource != null)
        {
            audioSource.Play(); // Reproducir el audio
        }

        // Esperar la duración del jumpscare
        yield return new WaitForSecondsRealtime(jumpscareDuration); // Usa WaitForSecondsRealtime para ignorar Time.timeScale

        // Ocultar el jumpscare y reanudar el juego
        jumpscareCanvas.gameObject.SetActive(false);
        Time.timeScale = previousTimeScale; // Restaurar el tiempo
        AudioListener.pause = false; // Reanudar los sonidos globales
        Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor nuevamente
    }
}
