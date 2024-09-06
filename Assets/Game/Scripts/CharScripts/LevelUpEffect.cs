using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpEffect : MonoBehaviour
{
    Transform playerTransform;
    [SerializeField] private GameObject explosionPrefab;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public IEnumerator CreateandDestroyEffect()
    {
        GameObject effect = Instantiate(explosionPrefab, playerTransform.position, Quaternion.identity);

        FollowEffect followEffect = effect.AddComponent<FollowEffect>();
        followEffect.target = playerTransform;

        Animator effectAnimator = effect.GetComponent<Animator>();
        float effectDuration = effectAnimator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(effectDuration);
        Destroy(effect);
    }
}

public class FollowEffect : MonoBehaviour
{
    [NonSerialized] public Transform target;

    private void Update()
    {
        if (target != null)
        {
            transform.position = target.position;
        }
    }
}
