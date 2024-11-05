using UnityEngine;

[RequireComponent(typeof(ParticleSystem), typeof(Collider))]
public class TriggerParticleEffect : MonoBehaviour
{
    private ParticleSystem myParticleSystem;
    public int particleAmount = 10;
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
            myParticleSystem.Emit(particleAmount);
        }
    }
}
