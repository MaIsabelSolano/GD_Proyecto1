using UnityEngine;
using UnityEngine.UI;

public class SettingsManagerPause : MonoBehaviour
{
    public GameObject settingsPanel;
    public Slider volumeSlider;
    public Slider brightnessSlider;
    public Slider qualitySlider;

    private void Start()
    {
        // Cargar configuraciones guardadas
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", AudioListener.volume);
        brightnessSlider.value = PlayerPrefs.GetFloat("Brightness", 1f);
        qualitySlider.value = PlayerPrefs.GetInt("Quality", QualitySettings.GetQualityLevel());

        // Configurar el valor máximo del slider de calidad
        qualitySlider.maxValue = QualitySettings.names.Length - 1;
    }

    public void ToggleSettingsPanel()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

    // Aplicar y guardar configuraciones cuando se hace clic en "Regresar"
    public void ApplySettings()
    {
        // Aplicar los valores de los sliders
        SetVolume(volumeSlider.value);
        SetBrightness(brightnessSlider.value);
        SetQuality(qualitySlider.value);

        // Guardar los valores en PlayerPrefs
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        PlayerPrefs.SetFloat("Brightness", brightnessSlider.value);
        PlayerPrefs.SetInt("Quality", (int)qualitySlider.value);
        PlayerPrefs.Save();

        // Cerrar el panel de configuraciones
        settingsPanel.SetActive(false);
    }

    private void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    private void SetBrightness(float brightness)
    {
        RenderSettings.ambientLight = Color.white * brightness;
    }

    private void SetQuality(float qualityIndex)
    {
        QualitySettings.SetQualityLevel((int)qualityIndex);
    }
}
