using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Ending00 : MonoBehaviour
{
    [SerializeField] private Image _imgFade = null;

    [SerializeField] private Image _imgEnding = null;
    [SerializeField] private Text _textEnding = null;

    [SerializeField] private Button _btnTitle = null;
    [SerializeField] private Button _btnRetry = null;

    public void StartFadeout()
    {
        StartCoroutine(Fadeout());
    }

    IEnumerator Fadeout()
    {
        while (_imgFade.color.a < 1f)
        {
            _imgFade.color = new Color(0f, 0f, 0f, _imgFade.color.a + (Time.deltaTime / 2f));
            yield return null;
        }

        while (_imgEnding.color.a < 1f)
        {
            _imgEnding.color = new Color(1f, 1f, 1f, _imgEnding.color.a + (Time.deltaTime / 2f));
            _textEnding.color = new Color(1f, 1f, 1f, _textEnding.color.a + (Time.deltaTime / 2f));
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        _btnTitle.gameObject.SetActive(true);
        _btnRetry.gameObject.SetActive(true);
    }
}
