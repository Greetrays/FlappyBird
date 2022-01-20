using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    [SerializeField] private List<GameObject> _pool = new List<GameObject>();
    private Camera _camera;

    protected void Initial(GameObject prefab)
    {
        _camera = Camera.main;

        for (int i = 0; i < _capacity; i++)
        {
            var template = Instantiate(prefab, _container.transform);
            template.SetActive(false);
            _pool.Add(template);
        }
    }

    protected bool TryGetObject(out GameObject obj)
    {
        obj = _pool.FirstOrDefault(p => p.activeSelf == false);

        return obj != null;
    }

    protected void DisableObjectAbroadScreen()
    {
        Vector2 disablePoint = _camera.ViewportToWorldPoint(new Vector2(-0.5f, 0));

        foreach (var item in _pool)
        {
            if (item.activeSelf == true)
            {
                if (item.transform.position.x < disablePoint.x)
                    item.SetActive(false);
            }
        }
    }

    public void Reset()
    {
        foreach (var item in _pool)
        {
            item.SetActive(false);
        }
    }
}
