using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPage_ : MonoBehaviour
{
    public Text musicLevelText;
    public Slider musicLevel;
    public Text soundEffectsText;
    public GameObject muteImg;
    public GameObject sunSlider;
    public Gradient sunGradient;
    public Text sunPointText;
    public Text explosionsEnabledText;
    public Text selectedControlTextField;

    // Start is called before the first frame update
    void Start()
    {
        soundEffectsText.text = "Sound Effects: " + (GameDataManager.SoundEffectsEnabled() ? "Yes" : "No ");
        musicLevel.normalizedValue = GameDataManager.GetMusicLevel();
        muteImg.SetActive(!GameDataManager.SoundEffectsEnabled());
        musicLevelText.text = $"Music Volume: {(int)(10 * musicLevel.normalizedValue)}";
        sunSlider.GetComponent<Slider>().value = GameDataManager.GetSunPoint();
        UpdateExplosionStatus();
        ChangeSelectedControl(GameDataManager.GetSelectedControl());
    }

    /// <summary>
    /// Updates game settings based on preferences
    /// </summary>
    private void Update()
    {
        GameDataManager.SetMusicLevel(musicLevel.normalizedValue);
        musicLevelText.text = $"Music Volume: {(int)(10 * musicLevel.normalizedValue)}";
        GameDataManager.SetSunPoint(sunSlider.GetComponent<Slider>().value);
        EvaluateSliderColorAndText(sunSlider.GetComponent<Slider>().normalizedValue);
    }

    /// <summary>
    /// Changes the sound effects from on to off
    /// </summary>
    public void SwitchSoundEffects()
    {
        GameDataManager.SwitchSoundEffectsEnabled();
        muteImg.SetActive(!GameDataManager.SoundEffectsEnabled());
        soundEffectsText.text = "Sound Effects: " + (GameDataManager.SoundEffectsEnabled() ? "Yes" : "No ");
    }

    /// <summary>
    /// Changes game based on the sun setting
    /// </summary>
    /// <param name="sunPoint">The point of the sun that the user wants it to be at</param>
    private void EvaluateSliderColorAndText(float sunPoint)
    {
        sunSlider.GetComponent<SunSlider>().fill.GetComponent<Image>().color = sunGradient.Evaluate(sunPoint);
        sunSlider.GetComponent<SunSlider>().background.GetComponent<Image>().color = sunGradient.Evaluate(sunPoint);
        string timeRegardingSun = sunPoint <= 0.1f ? "Sunrise" : (sunPoint <= 0.4f ? "Morning" : (sunPoint <= 0.6f ? "Noon" : (sunPoint <= 0.9f ? "Afternoon" : "Sunset")));
        sunPointText.text = $"Sun Point: {timeRegardingSun}";
    }

    /// <summary>
    /// Uodates explosion status in GameManager
    /// </summary>
    public void ChangeExplosionsStatus()
    {
        GameDataManager.SwitchExplosionsEnabled();
        UpdateExplosionStatus();
    }

    public void UpdateExplosionStatus() => explosionsEnabledText.text = "Explosions Enabled: " + (GameDataManager.ExplosionsEnabled() ? "Yes" : "No");

    /// <summary>
    /// Changes selected vehicle control with GameManager
    /// </summary>
    /// <param name="i">The control index</param>
    public void ChangeSelectedControl(int i)
    {
        selectedControlTextField.text = "Current Controls: " + (i == 0 ? "Buttons" : (i == 1 ? "Tilt" : "Swipe"));
        GameDataManager.SetSelectedControl(i);
    }
}
