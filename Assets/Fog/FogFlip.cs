using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogFlip : MonoBehaviour
{
    ParticleSystem particles;
    int dir = -1;
    // Start is called before the first frame update
    void Start()
    {
        particles = this.GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    public void FlipDir()
    {
        var main = particles.main;
        dir *= -1;
        main.startSpeed = dir;
    }
}
