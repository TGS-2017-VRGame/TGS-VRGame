using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureFirework : MonoBehaviour
{
    [SerializeField]
    Texture2D m_targetTexture;
    [Range(0.0f, 1.0f)]
    public float MoveRate;

    private Vector3[] m_target;
    private ParticleSystem.Particle[] m_targetParticles;
    private ParticleSystem m_particleSystem;

    void Start()
    {
        m_particleSystem = GetComponent<ParticleSystem>();
        m_target = ProcuralTarget();
        m_targetParticles = new ParticleSystem.Particle[m_target.Length];
    }
    void Update()
    {
        for (int i = 0; i < m_target.Length; i++)
        {
            var half = new Vector3(m_targetTexture.width, m_targetTexture.height,0.0f)*0.5f;
            m_targetParticles[i].position = Vector3.Lerp(transform.position, m_target[i]- half, MoveRate);
            m_targetParticles[i].startColor = Color.red;
            m_targetParticles[i].startSize = 1;

            m_targetParticles[i].remainingLifetime = 10f;
            m_targetParticles[i].startLifetime = 10f;
        }
        m_particleSystem.SetParticles(m_targetParticles, m_targetParticles.Length);
    }

    private Vector3[] ProcuralTarget()
    {
        List<Vector3> target = new List<Vector3>();
        for (var y = 0; y < m_targetTexture.height; y++)
        {
            for (var x = 0; x < m_targetTexture.width; x++)
            {
                if (m_targetTexture.GetPixel(x, y) == Color.black)
                {
					target.Add(new Vector3(x,y,0));
                }
            }
        }
        return target.ToArray();
    }
}
