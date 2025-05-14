using Weapons;

namespace Enemy
{
    public class EnemyWeapon : Weapon
    {
        private void FixedUpdate()
        {
            if (!WeaponReloaded)
            {
                WeaponReloaded = Reload();
                
                return;
            }
            
            Fire();
        }
    }
}
