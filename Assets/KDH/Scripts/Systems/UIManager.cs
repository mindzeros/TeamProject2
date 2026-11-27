using KDH.Scripts.UIs;
using UnityEngine;

namespace KDH.Scripts.Systems
{
    public class UIManager : MonoBehaviour
    {
        [field: SerializeField] public MessageUI MessageUI { get; private set; }
        [field: SerializeField] public FadeInOutUI FadeInOutUI { get; private set; }
        [field: SerializeField] public NextDayFadeInOutUI NextDayFadeInOutUI { get; private set; }
        [field: SerializeField] public UpdateCreditText CreditText { get; private set; }
        [field: SerializeField] public HealthText HealthText { get; private set; }
        [field: SerializeField] public InventoryUI InventoryUI { get; private set; }
    }
}
