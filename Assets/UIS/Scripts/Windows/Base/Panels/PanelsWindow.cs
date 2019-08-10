namespace UIS
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    public class PanelsWindow : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> prefabs = new List<GameObject>();

        private List<GameObject> internalPool = new List<GameObject>();

        private PanelsAgregator _panelsAgregator;
        private Window _window;
        private void Awake()
        {
            try
            {
                _panelsAgregator = FindObjectOfType<PanelsAgregator>();
                _window = GetComponent<Window>();
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                Destroy(this);
            }
            _window.ChangeFocusHandler += onChangeFocusWindow;
        }

        private void OnEnable()
        {
            onChangeFocusWindow(true);
        }

        private void OnDisable()
        {
            onChangeFocusWindow(false);
        }

        private void OnDestroy()
        {
            _window.ChangeFocusHandler -= onChangeFocusWindow;
        }

        private void onChangeFocusWindow(bool status)
        {
            if (status)
            {
                internalPool = new List<GameObject>();
                foreach (var item in prefabs)
                {
                    FindItem(item);
                }
            }
            else
            {
                foreach (var item in internalPool)
                {
                    BackToPool(item);
                }
                internalPool.Clear();
            }
        }

        private void FindItem(GameObject item)
        {
            //FIXME: Using names for equals is very bad. But equals of type GO - is not working. Need create some other solution
            GameObject res = _panelsAgregator.PanelsPool.Find(x => x.name == item.name);
            if (!res)
            {
                res = Instantiate(item);
                res.name = res.name.Replace("(Clone)", "");
            }
            else
            {
                _panelsAgregator.PanelsPool.Remove(res);
            }
            internalPool.Add(res);
            SetObjectInView(res);
        }

        private void SetObjectInView(GameObject item)
        {
            item.transform.SetParent(transform, false);
            item.transform.SetAsLastSibling();
            item.SetActive(true);
        }

        private void BackToPool(GameObject item)
        {
            _panelsAgregator.PanelsPool.Add(item);
            item.SetActive(false);
        }
    }
}
