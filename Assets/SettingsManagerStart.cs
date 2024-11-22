using UnityEngine;
using UnityEngine.UI;

public class SettingsManagerStart : MonoBehaviour
{
    public GameObject settingsPanel;
    public Slider volumeSlider;
    public Slider brightnessSlider;
    public Slider qualitySlider;

    private void Start()
    {
        // Configurar los sliders con valores del GameSettings
        volumeSlider.value = GameSettings.Instance.Volume;
        brightnessSlider.value = GameSettings.Instance.Brightness;
        qualitySlider.value = GameSettings.Instance.Quality;

        // Configurar el valor máximo del slider de calidad
        qualitySlider.maxValue = QualitySettings.names.Length - 1;
    }

    public void ToggleSettingsPanel()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

    public void ApplySettings()
    {
        // Aplicar valores usando GameSettings
        GameSettings.Instance.SetVolume(volumeSlider.value);
        GameSettings.Instance.SetBrightness(brightnessSlider.value);
        GameSettings.Instance.SetQuality((int)qualitySlider.value);

        // Cerrar el panel de configuraciones
        settingsPanel.SetActive(false);
    }
}
