using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class RewardPoolManager : MonoBehaviour
{

    private Dictionary<Texture, int> Rewards = new Dictionary<Texture, int>();
    [SerializeField] private SpinnerVisualManager _spinnerVisualManager;
    [SerializeField] private FortuneWheel fortuneWheel;
    private int numberOfRewards;
    public Button collectButton;
    public FortuneWheel FortuneWheel;
    [SerializeField]
    private RewardPoolUI rewardPoolUI;
    private void Awake()
    {
        collectButton.onClick.AddListener(
            () => AddRewardToList(FortuneWheel.RewardFinalPicture.GetComponent<RawImage>().texture)
        );
    }

    public void AddRewardToList(Texture reward)
    {
        numberOfRewards++;
        if (Rewards.ContainsKey(reward))
        {
            Rewards[reward]++;
            fortuneWheel.round++;
        }
        else
        {
            if (fortuneWheel.round % 5 != 0)
            {
                Rewards.Add(reward,1*(fortuneWheel.round) % 5);
            }
            else
            {
                Rewards.Add(reward, 5);
            }
            fortuneWheel.round++;
            
        }

        rewardPoolUI.UpdateReward(
            reward,
            Rewards[reward]);
        Debug.Log(Rewards.Count);
        FortuneWheel.RewardPanel.SetActive(false);
        FortuneWheel.SpinButton.SetActive(true);
        _spinnerVisualManager.Change();
        

    }
    
    private void OnDestroy()
    {
        collectButton.onClick.RemoveListener(() => AddRewardToList(FortuneWheel.RewardFinalPicture.GetComponent<RawImage>().texture)
        );
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
