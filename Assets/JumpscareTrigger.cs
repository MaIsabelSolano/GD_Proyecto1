using UnityEngine;

public class JumpscareTrigger : MonoBehaviour
{
    public JumpscareManager jumpscareManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que el jugador tenga la etiqueta "Player"
        {
            jumpscareManager.TriggerJumpscare();
        }
    }
}
