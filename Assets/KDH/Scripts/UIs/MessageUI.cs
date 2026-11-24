using System.Collections.Generic;
using UnityEngine;
namespace KDH.Scripts.UIs
{
    public class MessageUI : MonoBehaviour
    {
        [SerializeField] private Transform spawner;
        public Queue<MessageText> messages { get; private set; } = new();

        private void Start()
        {
            for (int i = 0; i < spawner.childCount; i++)
            {
                messages.Enqueue(spawner.GetChild(i).GetComponent<MessageText>());
            }

            foreach (var item in messages)
            {
                if (item.gameObject.activeSelf)
                {
                    item.gameObject.SetActive(false);
                }

                item.Init(this);
            }
        }
        
        public void SetUI(string message)
        {
            var msg = messages.Dequeue();
            msg.gameObject.SetActive(true);
            msg.SetText(message);
        }
    }
}
