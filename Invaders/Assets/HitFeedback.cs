using UnityEngine;
using UnityEngine.UI;

public class HitFeedback : MonoBehaviour
{

    private Image _image;
    void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void Hit()
    {
        Color color = _image.color;
        color.a = 1f;
        _image.color = color;
        gameObject.SetActive(true);

    }

    void Update()
    {

        if (_image.color.a > 0)
            {
                Color color = _image.color;
                color.a -= Time.deltaTime * 1f;
                _image.color = color;
            }
            else
            {
                gameObject.SetActive(false);
            }
    }
}
