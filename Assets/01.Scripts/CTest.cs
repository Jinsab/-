using UnityEngine;

public class CTest : MonoBehaviour
{
    public UnityEngine.UI.Text _tesxt;

    private void Update()
    {
        if (SwipeInput.swipedDown)
        {
            _tesxt.text = "swipedDown";
        }
        if (SwipeInput.swipedUp)
        {
            _tesxt.text = "swipedUp";
        }
        if (SwipeInput.swipedRight)
        {
            _tesxt.text = "swipedRight";
        }
        if (SwipeInput.swipedLeft)
        {
            _tesxt.text = "swipedLeft";
        }
    }
}
