using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaveGame : MonoBehaviour
{
    
    [SerializeField] private Button leaveGameButton;
    [SerializeField] private FortuneWheel fortuneWheel;
    [SerializeField] private GameObject rewardsList;
    [SerializeField] private GameObject FortunePanel;
    [SerializeField] private GameObject SpinButton;
    [SerializeField] private GameObject StartAgainButton;
    [SerializeField] private GameObject reward;
    [SerializeField] private RewardPoolUI rewardPoolUI;
    
    public bool hasLeftGame = false;
    public bool isdead = false;

    
    private void Awake()
    {
        leaveGameButton.onClick.AddListener(LeaveGameFunc);
    }

    public void LeaveGameFunc()
    {
        rewardPoolUI.SetEndGameLayout();

        FortunePanel.SetActive(false);
        SpinButton.SetActive(false);
        leaveGameButton.gameObject.SetActive(false);
        StartAgainButton.SetActive(true);

        hasLeftGame = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (fortuneWheel.isSpinning || reward.activeSelf || hasLeftGame || isdead)
        {
            leaveGameButton.gameObject.SetActive(false);
        }
        else
        {
            leaveGameButton.gameObject.SetActive(true);
        }
        
    }
}
