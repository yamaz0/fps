using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem effect;
    [SerializeField]
    private Animator fireEffect;
    [SerializeField]
    private bool isPressing;
    public void OnFireClicked(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isPressing = true;
            StartCoroutine(Shoot());
        }
        if (context.canceled)
        {
            isPressing = false;
        }
    }

    public IEnumerator Shoot()
    {
        while (isPressing)
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
            {
                Instantiate(effect, hit.point, Quaternion.identity);
                IDamageable damageable = hit.collider.gameObject.GetComponent<IDamageable>();
                if (damageable != null)
                    damageable.TakeDamage(1);
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
}
