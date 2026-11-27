using System.Collections.Generic;
using UnityEngine;

namespace Assets.KDH.Scripts.UIs
{
    internal class InvetoryItemListUI : MonoBehaviour
    {
        [SerializeField] private Type type;
        [SerializeField] private Transform spawnTrm;
        [SerializeField] private InventoryItemSourceUI itemSourceUIPrefab;

        public void Generate(IReadOnlyDictionary<ItemSO, int> dict)
        {
            Remove();

            foreach (var item in dict)
            {
                if (item.Key.type == type)
                {

                    var ui = Instantiate(itemSourceUIPrefab, spawnTrm);
                    ui.CountText.SetText("x" + item.Value);
                    ui.Icon.sprite = item.Key.icon;
                    ui.ItemData = item.Key;
                }
            }
        }

        private void Remove()
        {
            for (int i = 0; i < spawnTrm.childCount; i++)
            {
                Destroy(spawnTrm.GetChild(i).gameObject);
            }
        }
    }
}
