using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance; // Singleton

    public float Volume { get; private set; } = 1f; // Volumen inicial
    public float Brightness { get; private set; } = 1f; // Brillo inicial
    public int Quality { get; private set; } = 2; // Calidad inicial

    private void Awake()
    {
        // Asegurar que solo exista una instancia del Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // No destruir al cambiar de escena
            LoadSettings(); // Cargar configuraciones guardadas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetVolume(float volume)
    {
        Volume = volume;
        AudioListener.volume = volume; // Aplicar inmediatamente
        PlayerPrefs.SetFloat("Volume", volume);
    }

    public void SetBrightness(float brightness)
    {
        Brightness = brightness;
        RenderSettings.ambientLight = Color.white * brightness; // Aplicar inmediatamente
        PlayerPrefs.SetFloat("Brightness", brightness);
    }



    public void SetQuality(int quality)
    {
        Quality = quality;
        QualitySettings.SetQualityLevel(quality); // Aplicar inmediatamente
        PlayerPrefs.SetInt("Quality", quality);
    }

    private void LoadSettings()
    {
        // Cargar valores guardados
        Volume = PlayerPrefs.GetFloat("Volume", 1f);
        Brightness = PlayerPrefs.GetFloat("Brightness", 1f);
        Quality = PlayerPrefs.GetInt("Quality", 2);

        // Aplicar inmediatamente al cargar
        AudioListener.volume = Volume;
        RenderSettings.ambientLight = Color.white * Brightness;
        QualitySettings.SetQualityLevel(Quality);
    }
}
