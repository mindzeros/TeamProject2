using UnityEngine;

namespace KDH.Scripts.Surveies
{
    public abstract class AbstractSurveySpecialCondition : MonoBehaviour
    {
        public abstract bool SpecialCondition(); // 특정 행동이 성공했으면 true, 아니면 false
    }
}
