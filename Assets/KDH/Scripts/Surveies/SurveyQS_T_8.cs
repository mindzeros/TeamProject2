using KDH.Scripts.Surveies;

public class SurveyQS_T_8 : AbstractSurveySpecialCondition
{
    private bool _isCleared;

    public override bool SpecialCondition() // 구매하는 설문 예외 구현하기, PurchaseSurveyMission 확인하기
    {
        return false;
    }
}
