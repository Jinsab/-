using UnityEngine;
using UnityEngine.UI;

public class CTimeSlide : MonoBehaviour
{
    public RectTransform _rt;
    
    private readonly float _fSlideValue = 270f;

    private void Update()
    {
        float PosX = (CGameManager._pInstance._fPastTime / CGameManager._pInstance._fTotalTime) * -_fSlideValue;

        _rt.localPosition = new Vector3(PosX, 0f, 0f);
    }
}
