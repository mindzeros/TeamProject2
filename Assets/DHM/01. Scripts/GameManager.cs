using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DHM
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [Header("생존자 정보")]
        [field: SerializeField] public CharacterStats Player { get; private set; }
        [field: SerializeField] public CharacterStats Sister { get; private set; }

        [Header("플레이어 UI")]
        public TextMeshProUGUI playerHungerText;
        public TextMeshProUGUI playerThirstText;

        [Header("여동생 UI")]
        public TextMeshProUGUI sisterHungerText;
        public TextMeshProUGUI sisterThirstText;

        private Dictionary<string, int> itemUseCounts = new Dictionary<string, int>();

        [Header("설정")]
        [SerializeField] private int hiddenEndingThreshold = 20;

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        private void Start()
        {
            Player.Init();
            Sister.Init();

            UpdateAllUI();
        }

        public void OnClickNextDayButton()
        {
            Player.PassDay();
            CheckDeath(Player);

            Sister.PassDay();
            CheckDeath(Sister);

            UpdateAllUI();
        }

        public void UseItemOnCharacter(ItemSO item, CharacterStats target)
        {
            if (item == null || target == null) return;

            item.Use(target);

            HandleSpecialEffect(item);

            UpdateAllUI();
        }

        private void HandleSpecialEffect(ItemSO item)
        {
            switch (item.specialEvent)
            {
                case ItemSpecialEvent.HiddenEndingTrigger:
                    if (!itemUseCounts.ContainsKey(item.itemID))
                    {
                        itemUseCounts[item.itemID] = 0;
                    }

                    itemUseCounts[item.itemID]++;
                    Debug.Log($"{item.itemName} 누적 횟수: {itemUseCounts[item.itemID]}회");

                    if (itemUseCounts[item.itemID] >= hiddenEndingThreshold)
                    {
                        TriggerHiddenEnding(item);
                    }
                    break;

                case ItemSpecialEvent.NegativeEvent:
                    Debug.LogWarning($"{item.itemName} 아이템 복용. 부정적 이벤트 발생.");
                    break;

                case ItemSpecialEvent.None:
                default:
                    break;
            }
        }

        private void TriggerHiddenEnding(ItemSO item)
        {
            Debug.LogError($"{item.itemName} 아이템을 충분히 섭취하여 히든 엔딩으로 진입");
        }

        private void UpdateAllUI()
        {
            if (playerHungerText != null) playerHungerText.text = $"{Player.currentHunger} / {Player.maxHunger}";
            if (playerThirstText != null) playerThirstText.text = $"{Player.currentThirst} / {Player.maxThirst}";

            if (sisterHungerText != null) sisterHungerText.text = $"{Sister.currentHunger} / {Sister.maxHunger}";
            if (sisterThirstText != null) sisterThirstText.text = $"{Sister.currentThirst} / {Sister.maxThirst}";
        }

        private void CheckDeath(CharacterStats survivor)
        {
            if (survivor.currentHunger <= 0f)
            {
                Debug.LogError($"{survivor.characterName}이 아사함.");
            }

            if (survivor.currentThirst <= 0f)
            {
                Debug.LogError($"{survivor.characterName}이 탈수함.");
            }
        }
    }
}