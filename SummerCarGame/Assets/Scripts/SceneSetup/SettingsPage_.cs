using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPage_ : MonoBehaviour
{
    public Text musicLevelText;
    public Slider musicLevel;
    public Text soundEffectsText;

    // Start is called before the first frame update
    void Start()
    {
        soundEffectsText.text = "Sound Effects:" + (GameDataManager.SoundEffectsEnabled() ? "Yes" : "No");
        musicLevel.normalizedValue = GameDataManager.GetMusicLevel();
        musicLevelText.text = $"Music Volume: {(int)(10 * musicLevel.normalizedValue)}";
    }

    private void Update()
    {
        GameDataManager.SetMusicLevel(musicLevel.normalizedValue);
        musicLevelText.text = $"Music Volume: {(int)(10 * musicLevel.normalizedValue)}";
    }

    public void SwitchSoundEffects()
    {
        GameDataManager.SwitchSoundEffectsEnabled();
        soundEffectsText.text = "Sound Effects:" + (GameDataManager.SoundEffectsEnabled() ? "Yes" : "No");
    }
}
