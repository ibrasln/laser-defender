using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float laserSpeed;
    [SerializeField] float laserLifeTime;
    [SerializeField] float baseFiringRate;
    Vector2 direction;

    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVariance;
    [SerializeField] float minimumFiringRate;
    
    [HideInInspector] public bool isFiring;

    Coroutine firingCoroutine;

    AudioPlayer audioPlayer;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    private void Start()
    {
        if (useAI)
        {
            direction = Vector2.down;
            isFiring = true;
        }
        else
        {
            direction = Vector2.up;
            isFiring = false;
        }
    }

    private void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);

            if (laser.TryGetComponent<Rigidbody2D>(out var rb)) rb.velocity = direction * laserSpeed;

            Destroy(laser, laserLifeTime);

            float timeToNextLaser = Random.Range(baseFiringRate - firingRateVariance, baseFiringRate + firingRateVariance);
            timeToNextLaser = Mathf.Clamp(timeToNextLaser, minimumFiringRate, float.MaxValue);

            audioPlayer.PlayAudioClip(0);

            yield return new WaitForSeconds(timeToNextLaser);
        }
    }

}
