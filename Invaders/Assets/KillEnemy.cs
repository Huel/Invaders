using UnityEngine;
using System.Collections;

public class KillEnemy : MonoBehaviour
{
    public GameObject Particles;

    private SpriteRenderer _renderer;
    private bool _kill;

    void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void Kill()
    {
        Particles.transform.parent = null;
        Particles.SetActive(true);
        _kill = true;
    }

    void Update()
    {
        if (_renderer.color.a > 0)
        {
            Color color = _renderer.color;
            color.a -= Time.deltaTime*1f;
            _renderer.color = color;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
