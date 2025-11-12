using UnityEngine;

[DisallowMultipleComponent]
public class DeathVfxOnDestroy : MonoBehaviour
{
    [SerializeField] private GameObject _vfxPrefab;

    private void OnDestroy()
    {
        if (_vfxPrefab == null) return;

        var go = Instantiate(_vfxPrefab, transform.position, Quaternion.identity);
        
        float total = 0f;
        var systems = go.GetComponentsInChildren<ParticleSystem>(true);
        foreach (var ps in systems)
        {
            ps.gameObject.SetActive(true);
            ps.Play(true);

            var m = ps.main;
            float life = m.duration;
            life += (m.startLifetime.mode == ParticleSystemCurveMode.TwoConstants)
                ? m.startLifetime.constantMax
                : m.startLifetime.constant;

            if (life > total) total = life;
        }

        if (total <= 0f) total = 2f;
        Destroy(go, total);
    }
}