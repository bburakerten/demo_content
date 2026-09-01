using UnityEngine;
using UnityEngine.UI;

public class SpinnerParts : MonoBehaviour
{
    [SerializeField] private FortuneWheel fortuneWheel;
    public Texture[] RewardPictures;

    public GameObject[] WheelParts;

    public Texture DeathTexture;

    void Start()
    {
        FillWheelRandomly();
        AssignDeath();
    }

    public void FillWheelRandomly()
    {
        for (int i = 0; i < WheelParts.Length; i++)
        {
            int randomIndex = Random.Range(0, RewardPictures.Length);

            RawImage rawImage =
                WheelParts[i].GetComponentInChildren<RawImage>();

            if (rawImage != null)
            {
                rawImage.texture = RewardPictures[randomIndex];
            }
        }

        
    }

    public void AssignDeath()
    {
        int deathSlot = Random.Range(0, WheelParts.Length);
        fortuneWheel.deathImage = deathSlot;
        Debug.Log("atandi");
        RawImage deathImage =
            WheelParts[deathSlot].GetComponentInChildren<RawImage>();

        if (deathImage != null)
        {
            deathImage.texture = DeathTexture;
        }
    }
}