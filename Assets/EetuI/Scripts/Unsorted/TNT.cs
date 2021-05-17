using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.Events;

namespace AGP
{
    namespace EetuI
    {
        public class TNT : MonoBehaviour
        {
            [SerializeField] private float explosionRadius;
            [SerializeField] private float explosionForceMultiplier;
            [SerializeField] private bool showRadius;

            public UnityEvent OnExplosion;


            public void Explosion()
            {
                StartCoroutine(ExplosionWait());
            }

            public void ExplosionWithIgnore(TNT _tnt)
            {
                StartCoroutine(ExplosionWait(_tnt));
            }

            private IEnumerator ExplosionWait()
            {
                yield return new WaitForSeconds(0.3f);
                Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius, -1);
                for (int i = hits.Length - 1; i > 0; i--)
                {
                    if (hits[i].TryGetComponent(out Rigidbody rb))
                    {
                        var target = hits[i].transform.position;
                        var direction = (target - transform.position).normalized;
                        rb.AddForce(
                            direction * CalculateExplosionForce(explosionRadius, target) * explosionForceMultiplier,
                            ForceMode.Impulse);
                    }

                    if (hits[i].TryGetComponent(out TNT otherTnt))
                    {
                        otherTnt.ExplosionWithIgnore(this);
                    }
                }

                OnExplosion?.Invoke();
            }

            private IEnumerator ExplosionWait(TNT ignoreSender)
            {
                yield return new WaitForSeconds(0.1f);
                Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius, -1);
                for (int i = hits.Length - 1; i > 0; i--)
                {
                    if (hits[i].TryGetComponent(out Rigidbody rb))
                    {
                        //rb.AddExplosionForce(explosionForceMultiplier, transform.position, explosionRadius);
                        var target = hits[i].transform.position;
                        var direction = (target - transform.position).normalized;
                        rb.AddForce(
                            direction * CalculateExplosionForce(explosionRadius, target) * explosionForceMultiplier,
                            ForceMode.Impulse);
                    }

                    TNT otherTnt = hits[i].GetComponent<TNT>();
                    if (otherTnt != null && otherTnt != this) // otherTnt != this, so it doesnt try to explode its self
                    {
                        if (otherTnt != ignoreSender)
                        {
                            otherTnt.ExplosionWithIgnore(this);
                        }
                    }
                }

                OnExplosion?.Invoke();
            }

            public void Destroy(float time)
            {
                Destroy(gameObject, time);
            }

            private float CalculateExplosionForce(float explosionRadius, Vector3 target)
            {
                var radiusCenter = explosionRadius * 0.5f;
                var distanceToTarget = Vector3.Distance(transform.position, target);
                var explosionForce = (radiusCenter - distanceToTarget);

                return explosionForce < 1 ? 1 : explosionForce;
            }
            private void OnDrawGizmos()
            {
                if (showRadius)
                {
                    Gizmos.color = new Color(255, 0, 0, 0.2f);
                    Gizmos.DrawSphere(transform.position, explosionRadius);
                }
            }
        }
    }
}
