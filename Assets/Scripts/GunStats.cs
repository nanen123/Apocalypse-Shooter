using UnityEngine;

[CreateAssetMenu(fileName = "GunStats", menuName = "Scriptable Objects/GunStats")]
public class GunStats : ScriptableObject
{
    public enum GunType {semiAuto, fullAuto };

    public GunType type;
    public float damage; // 데미지
    
    public int remainAmmo; // 현재 탄창에 남아있는 총알
    public int maxAmmo; // 한 탄창 최대 총알

    public float reloadingTime; // 재장전 시간
}
