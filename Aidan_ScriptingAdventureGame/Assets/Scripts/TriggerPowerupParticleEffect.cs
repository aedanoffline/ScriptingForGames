using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem), typeof(Collider))]
public class TriggerPowerupParticleEffect : MonoBehaviour
{
    private ParticleSystem myParticleSystem;
    
    public int particleAmount = 10;
    public float emissionDelay = 0.5f;
    private bool triggered = false;
    
    private void Start()
    {
        myParticleSystem = GetComponent<ParticleSystem>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !triggered)
        {
            triggered = true;
            StartCoroutine(EmitParticlesCoroutine());
        }
    }

    private IEnumerator EmitParticlesCoroutine()
    {
        myParticleSystem.Emit(particleAmount);
        yield return new WaitForSeconds(emissionDelay);

        myParticleSystem.Emit((particleAmount + 30));
        yield return new WaitForSeconds(emissionDelay);
        
        myParticleSystem.Emit((particleAmount + 110));
        yield return new WaitForSeconds(emissionDelay);
        
        triggered = false;
    }
}