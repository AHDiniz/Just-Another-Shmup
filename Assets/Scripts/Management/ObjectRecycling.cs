using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace JustAnotherShmup.Management
{
    public class ObjectRecycling : MonoBehaviour
    {
        [SerializeField] private List<string> deactivatorTags = new List<string>();
        [SerializeField] private UnityEvent OnDeactivate;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (deactivatorTags.Contains(col.gameObject.tag))
            {
                OnDeactivate.Invoke();
                gameObject.SetActive(false);
            }
        }
    }
}