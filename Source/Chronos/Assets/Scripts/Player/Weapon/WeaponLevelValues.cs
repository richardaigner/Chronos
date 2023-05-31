public static class WeaponLevelValues
{
    public static WeaponValues[] GetWeaponValues(int weaponId)
    {
        if (weaponId == 0) // bow
        {
            return new WeaponValues[] { new WeaponValues(     0,     0, false,     0, false,     0,     0,     0,     0,     0,     0,     0,     0),
                                        new WeaponValues(     0,  0.8f, false,    50, false,   500,   500,     1,     0,  1000,     0,     0,     1) };
        }
        else if (weaponId == 1) // shield
        {
            return new WeaponValues[] { new WeaponValues(     0,     0, false,     0, false,     0,     0,     0,     0,     0,     0,     0,     0),
                                        new WeaponValues(     2,     3,  true,     5, false,     2,  1000,     3,   120,   500,     0,    70,     1) };
        }
        else if (weaponId == 2) // shuriken
        {
            return new WeaponValues[] { new WeaponValues(     0,     0, false,     0, false,     0,     0,     0,     0,     0,     0,     0,     0),
                                        new WeaponValues(     0,  1.5f,  true,     5, false,   300,   300,     3,    10,   500,   500,     0,   1.1f),
                                        new WeaponValues(     0,  1.4f,  true,     7, false,   350,   350,     5,    10,   500,   500,     0,   1.2f),
                                        new WeaponValues(     0,  1.3f,  true,    10, false,   400,   400,     7,    10,   500,   500,     0,   1.3f) };

    }
        else if (weaponId == 3) // sword
        {
            return new WeaponValues[] { new WeaponValues(     0,     0, false,     0, false,     0,     0,     0,     0,     0,     0,     0,     0),
                                        new WeaponValues(  0.2f,     2,  true,    20, false,    10,   100,     1,     0,  1000,     0,     0,     1) };
        }

        return new WeaponValues[] { new WeaponValues(0, 0, false, 0, false, 0, 0, 0, 0, 0, 0, 0, 0) };
    }
}
