using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FortuneWheel : MonoBehaviour
{
    [SerializeField] private SpinnerParts spinnerParts;
    [SerializeField] private LeaveGame leaveGame;
    public int round = 1;

    public Image CircleBase;

    public GameObject SpinButton;

    public GameObject[] CircleParts;

    public GameObject RewardPanel;
    public GameObject GameOverPanel;
    public GameObject BaseCircle;

    public GameObject RewardFinalPicture;
    public int deathImage;

    [SerializeField] private Button spinButton;
    [SerializeField] private Button startAgainButton;
    [SerializeField] private RawImage ui_card_icon_death;


    [HideInInspector] public bool isSpinning = false;

    [HideInInspector] public float spinSpeed = 0;

    [HideInInspector] public float spinRotation = 0;

    [HideInInspector] public int rewardNumber = -1;

    private bool rewardPanelScheduled = false;

    private void Awake()
    {
        spinButton.onClick.AddListener(StartSpin);
        startAgainButton.onClick.AddListener(StartAgain);
    }

    private void Start()
    {
        spinRotation = 0;
        isSpinning = false;
        rewardNumber = -1;

        RewardPanel.SetActive(false);
    }

    private void Update()
    {
        if (isSpinning)
        {
            RewardPanel.SetActive(false);
            SpinButton.SetActive(false);


            if (spinSpeed > 2)
            {
                spinSpeed -= 2f * Time.deltaTime;
            }
            else
            {
                spinSpeed -= 0.3f * Time.deltaTime;
            }

            spinRotation += 100f * Time.deltaTime * spinSpeed;

            CircleBase.transform.localRotation =
                Quaternion.Euler(0, 0, -spinRotation);

            if (spinSpeed <= 0)
            {
                spinSpeed = 0;
                isSpinning = false;

                float normalizedAngle = spinRotation % 360f;

                int steps = Mathf.FloorToInt(
                    (normalizedAngle + 22.5f) / 45f
                );

                rewardNumber = (8 - steps) % 8;

                rewardPanelScheduled = false;
            }
        }
        else
        {
            if (rewardNumber != -1 && !rewardPanelScheduled)
            {
                if (rewardNumber == deathImage ||
                    CircleParts[rewardNumber].GetComponent<RawImage>().texture == ui_card_icon_death)
                {
                    leaveGame.hasLeftGame = true;
                    GameOverPanel.SetActive(true);
                    startAgainButton.gameObject.SetActive(true);
                    SpinButton.SetActive(false);
                    BaseCircle.SetActive(false);

                }
                else
                {
                    rewardPanelScheduled = true;
                    ShowRewardPanel();
                }
            }
        }
    }

    public void ShowRewardPanel()
    {

        RewardPanel.SetActive(true);
        



        GameObject selectedReward = CircleParts[rewardNumber];
        Debug.Log(rewardNumber);

        RewardFinalPicture.GetComponent<RawImage>().texture = selectedReward.GetComponent<RawImage>().texture;
    }


    public void StartSpin()
    {
        if (!isSpinning)
        {
            spinSpeed = Random.Range(4f, 14f);
            isSpinning = true;
            rewardNumber = -1;
            rewardPanelScheduled = false;

            RewardPanel.SetActive(false);
        }
    }
    private void OnDestroy()
    {
        spinButton.onClick.RemoveListener(StartSpin);
    }
    
    private void StartAgain()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
        leaveGame.hasLeftGame = false;
        leaveGame.hasLeftGame = false;

    }
}