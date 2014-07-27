using UnityEngine;
using System.Collections;

public class KillEnemy : MonoBehaviour
{
    public GameObject Particles;

    private SpriteRenderer _renderer;
    public bool kill;

    void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void Kill()
    {
        Particles.transform.parent = null;
        Particles.SetActive(true);
        kill = true;
    }

    void Update()
    {
		if (kill) {
						if (_renderer.color.a > 0) {
								Color color = _renderer.color;
								color.a -= Time.deltaTime * 1f;
								_renderer.color = color;
						} else {
								Destroy (gameObject);
						}
				}
    }
}
