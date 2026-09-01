using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RewardPoolUI : MonoBehaviour
{
    [SerializeField] private RectTransform contentParent;
    [SerializeField] private GameObject rewardItemPrefab;
    [SerializeField] private GridLayoutGroup gridLayout;

    private Dictionary<Texture, GameObject> rewardItems = new Dictionary<Texture, GameObject>();

    public void UpdateReward(Texture reward, int count)
    {
        if (rewardItems.ContainsKey(reward))
        {
            GameObject item = rewardItems[reward];

            TMP_Text countText =
                item.GetComponentInChildren<TMP_Text>();

            countText.text = "x" + count;

            return;
        }

        GameObject newItem = Instantiate(rewardItemPrefab, contentParent);
        RawImage image = newItem.GetComponentInChildren<RawImage>();
        TMP_Text text = newItem.GetComponentInChildren<TMP_Text>();

        image.texture = reward;
        text.text = "x" + count;

        rewardItems.Add(reward, newItem);
    }

    public void ClearUI()
    {
        foreach (GameObject item in rewardItems.Values)
        {
            Destroy(item);
        }

        rewardItems.Clear();
    }

    public void SetEndGameLayout()
    {
        contentParent.anchorMin =
            new Vector2(0.5f, 0.5f);

        contentParent.anchorMax =
            new Vector2(0.5f, 0.5f);

        contentParent.pivot =
            new Vector2(0.5f, 0.5f);

        contentParent.anchoredPosition =
            Vector2.zero;

        gridLayout.childAlignment =
            TextAnchor.MiddleCenter;

        gridLayout.startCorner =
            GridLayoutGroup.Corner.UpperLeft;

        gridLayout.startAxis =
            GridLayoutGroup.Axis.Horizontal;

        gridLayout.constraintCount = 4;

        contentParent.anchoredPosition = new Vector2(86f, 0f);

        gridLayout.constraint =
            GridLayoutGroup.Constraint.FixedColumnCount;
    }
}