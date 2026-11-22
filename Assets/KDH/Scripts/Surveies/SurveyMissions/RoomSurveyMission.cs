using KDH.Scripts.Rooms;
using UnityEngine;

namespace KDH.Scripts.Surveies
{
    public class RoomSurveyMission : MonoBehaviour
    {
        [SerializeField] private Survey survey;

        private Room _room;
        private SurveyQS_T_2 _mission;

        private void Awake()
        {
            _room = GetComponent<Room>();
        }

        private void OnEnable()
        {
            if (_mission == null)
            {
                _mission = survey.ExceptionSurveySpawnTrm.GetComponentInChildren<SurveyQS_T_2>();
            }

            if (_mission != null)
            {
                _mission.SetDictValue(_room);
            }

            if (_mission != null && _mission.SpecialCondition())
            {
                survey.InitSurveyQuiz();
                return;
            }
        }
    }
}
