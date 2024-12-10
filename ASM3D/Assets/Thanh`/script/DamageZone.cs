using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public Collider damageCollider;
    public int damageAmount = 20;

    public string targetTag;
    public List<Collider> colliderTargets = new List<Collider>();

    public bool flag = false;
    private void Start()
    {
        damageCollider.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log($"**********21");
        if (other.gameObject.CompareTag(targetTag) && !colliderTargets.Contains(other) && !flag)
        {
            Debug.Log($"*********24");
            colliderTargets.Add(other);
            var go = other.GetComponent<Health>();
            if (go != null)
            {
                Debug.Log($"**********29");
                go.TakeDamage(damageAmount);
            }
            flag = true;    
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"*********38");
        if (other.gameObject.CompareTag(targetTag) && !colliderTargets.Contains(other))
        {
            Debug.Log($"*********41");
            colliderTargets.Add(other);
            var go = other.GetComponent<Health>();
            if (go != null)
            {
                Debug.Log($"**********46");
                go.TakeDamage(damageAmount);
            }
        }
    }

    public void BeginAttack()
    {
        Debug.Log($"**********54");
        flag = true;
        colliderTargets.Clear();
        damageCollider.enabled = true;
    }

    public void EndAttack()
    {
        Debug.Log($"*********62");
        flag &= false;
        colliderTargets.Clear();
        damageCollider.enabled = false;
    }
}
