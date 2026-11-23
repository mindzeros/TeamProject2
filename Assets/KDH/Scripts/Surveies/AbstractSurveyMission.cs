using UnityEngine;

namespace KDH.Scripts.Surveies
{
    public abstract class AbstractSurveyMission : MonoBehaviour
    {
        public abstract bool SpecialCondition(); // 특정 행동이 성공했으면 true, 아니면 false
        public bool IsCleared { get; private set; } // 미션 중복처리에 대한 내용을 AI한테 질문함.

        public bool TryClear()
        {
            if (IsCleared || !SpecialCondition())
                return false;

            IsCleared = true;
            return true;
        }
    }
}
