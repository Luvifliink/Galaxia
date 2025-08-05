using UnityEngine;

using UnityEngine;

public class ParticleAttractor : MonoBehaviour
{
    public ParticleSystem ps;
    public Transform target; // Ponto para onde as partículas serão atraídas
    public float force = 10f;

    private ParticleSystem.Particle[] particles;

    void LateUpdate()
    {
        if (ps == null || target == null) return;

        if (particles == null || particles.Length < ps.main.maxParticles)
            particles = new ParticleSystem.Particle[ps.main.maxParticles];

        int count = ps.GetParticles(particles);

        for (int i = 0; i < count; i++)
        {
            Vector3 direction = (target.position - particles[i].position).normalized;
            particles[i].velocity = direction * force;
        }

        ps.SetParticles(particles, count);
    }
}
