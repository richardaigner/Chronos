public static class WeaponLevelValues
{
    public static WeaponValues[] GetWeaponValues(int itemId)
    {
        //                                              |scale |      |      |      |      |      |bouncing     |      |      |      |      |      |      |      |
        //                                              |      |lifetime     |      |      |      |      |moveSpeed    |      |      |      |rotationSpeed|      |
        //                                              |      |      |attackSpeed  |      |      |      |      |flyRange     |      |      |      |circularDistance
        //                                              |      |      |      |piercing     |      |      |      |      |projectileCount     |      |      |rndFactor
        //                                              |      |      |      |      |damage|      |      |      |      |      |projectileAngleMod  |      |      |
        //                                              |      |      |      |      |      |      |      |      |      |      |      |knockbackForce      |      |
        //                                              |      |      |      |      |      |damageInterval      |      |      |      |      |      |      |      |
        if (itemId == 0) // bow
        {
            return new WeaponValues[] { new WeaponValues(     0,     0,     0, false,     0,     0, false,     0,     0,     0,     0,     0,     0,     0,     0),
                                        new WeaponValues(   128,     0,  0.8f, false,    50,  0.1f, false,   500,   500,     1,     0,  1000,     0,     0,     1),
                                        new WeaponValues(   128,     0,  0.8f, false,    70,  0.1f, false,   550,   550,     1,     0,  1100,     0,     0,     1),
                                        new WeaponValues(   128,     0,  0.7f, false,    90,  0.1f, false,   600,   600,     1,     0,  1200,     0,     0,     1),
                                        new WeaponValues(   128,     0,  0.7f, false,   130,  0.1f, false,   650,   650,     1,     0,  1300,     0,     0,     1),
                                        new WeaponValues(   128,     0,  0.6f, false,   170,  0.1f, false,   700,   700,     1,     0,  1400,     0,     0,     1),
                                        new WeaponValues(   128,     0,  0.6f, false,   210,  0.1f, false,   750,   750,     1,     0,  1500,     0,     0,     1),
                                        new WeaponValues(   128,     0,  0.5f, false,   260,  0.1f, false,   800,   800,     3,    10,  1500,     0,     0,  1.1f),
                                        new WeaponValues(   128,     0,  0.5f, false,   320,  0.1f, false,   850,   850,     3,    10,  1600,     0,     0,  1.1f),
                                        new WeaponValues(   128,     0,  0.4f, false,   400,  0.1f, false,   900,   900,     3,    10,  1600,     0,     0,  1.1f) };
        }
        else if (itemId == 1) // shield
        {
            return new WeaponValues[] { new WeaponValues(     0,     0,     0, false,     0,     0, false,     0,     0,     0,     0,     0,     0,     0,     0),
                                        new WeaponValues(   128,     2,     3,  true,     5,  0.1f, false,     2,  1000,     3,   120,   500,     0,    60,     1),
                                        new WeaponValues(   128,     2,  2.9f,  true,     7,  0.1f, false,  2.2f,  1000,     3,   120,   500,     0,    60,     1),
                                        new WeaponValues(   128,     2,  2.8f,  true,    10,  0.1f, false,  2.4f,  1000,     3,   120,   500,     0,    70,     1),
                                        new WeaponValues(   128,     2,  2.7f,  true,    13,  0.1f, false,  2.6f,  1000,     4,    90,   500,     0,    70,     1),
                                        new WeaponValues(   128,     2,  2.6f,  true,    17,  0.1f, false,  2.8f,  1000,     4,    90,   500,     0,    80,     1),
                                        new WeaponValues(   128,     2,  2.5f,  true,    22,  0.1f, false,     3,  1000,     4,    90,   500,     0,    80,     1),
                                        new WeaponValues(   128,     2,  2.4f,  true,    28,  0.1f, false,  3.2f,  1000,     4,    90,   500,     0,    90,     1),
                                        new WeaponValues(   128,     2,  2.2f,  true,    36,  0.1f, false,  3.4f,  1000,     4,    90,   500,     0,    90,     1),
                                        new WeaponValues(   128,     2,     2,  true,    50,  0.1f, false,  3.6f,  1000,     6,    60,   500,     0,   100,     1) };
        }
        else if (itemId == 2) // shuriken
        {
            return new WeaponValues[] { new WeaponValues(     0,     0,     0, false,     0,     0, false,     0,     0,     0,     0,     0,     0,     0,     0),
                                        new WeaponValues(   128,     0,  1.5f,  true,     5,  0.1f, false,   300,   300,     3,    10,   500,   500,     0,  1.1f),
                                        new WeaponValues(   128,     0,  1.5f,  true,     7,  0.1f, false,   300,   300,     3,    10,   500,   500,     0,  1.1f),
                                        new WeaponValues(   128,     0,  1.4f,  true,    10,  0.1f, false,   350,   300,     3,    10,   500,   500,     0,  1.1f),
                                        new WeaponValues(   128,     0,  1.4f,  true,    13,  0.1f, false,   350,   350,     5,    10,   500,   500,     0,  1.2f),
                                        new WeaponValues(   128,     0,  1.3f,  true,    17,  0.1f, false,   400,   350,     5,    10,   500,   500,     0,  1.2f),
                                        new WeaponValues(   128,     0,  1.3f,  true,    21,  0.1f, false,   450,   350,     5,    10,   500,   500,     0,  1.2f),
                                        new WeaponValues(   128,     0,  1.2f,  true,    25,  0.1f, false,   500,   400,     5,    10,   500,   500,     0,  1.3f),
                                        new WeaponValues(   128,     0,  1.1f,  true,    30,  0.1f, false,   550,   400,     7,    10,   500,   500,     0,  1.3f),
                                        new WeaponValues(   128,     0,     1,  true,    35,  0.1f, false,   600,   400,     7,    10,   500,   500,     0,  1.3f) };

        }
        else if (itemId == 3) // sword
        {
            return new WeaponValues[] { new WeaponValues(     0,     0,     0, false,     0,     0, false,     0,     0,     0,     0,     0,     0,     0,     0),
                                        new WeaponValues(   256,  0.2f,     2,  true,    20,  0.1f, false,    10,   100,     1,     0,  1000,     0,     0,     1),
                                        new WeaponValues(   256,  0.2f,  1.9f,  true,    30,  0.1f, false,    10,   100,     1,     0,  1000,     0,     0,     1),
                                        new WeaponValues(   256,  0.2f,  1.8f,  true,    40,  0.1f, false,    10,   100,     1,     0,  1000,     0,     0,     1),
                                        new WeaponValues(   256,  0.2f,  1.7f,  true,    55,  0.1f, false,    10,   100,     1,     0,  1000,     0,     0,     1),
                                        new WeaponValues(   256,  0.2f,  1.6f,  true,    70,  0.1f, false,    10,   100,     1,     0,  1000,     0,     0,     1),
                                        new WeaponValues(   256,  0.2f,  1.5f,  true,    90,  0.1f, false,    10,   100,     1,     0,  1000,     0,     0,     1),
                                        new WeaponValues(   256,  0.2f,  1.4f,  true,   110,  0.1f, false,    10,   100,     1,     0,  1000,     0,     0,     1),
                                        new WeaponValues(   256,  0.2f,  1.2f,  true,   130,  0.1f, false,    10,   100,     1,     0,  1000,     0,     0,     1),
                                        new WeaponValues(   256,  0.2f,     1,  true,   150,  0.1f, false,    10,   100,     1,     0,  1000,     0,     0,     1) };
        }
        else if (itemId == 4) // bounce
        {
            return new WeaponValues[] { new WeaponValues(    96,     0,     0, false,     0,     0, false,     0,     0,     0,     0,     0,     0,     0,     0),
                                        new WeaponValues(    96,    10,  1.5f,  true,    10,  0.1f,  true,   400,  2000,     1,     0,   200,  1000,     0,     1),
                                        new WeaponValues(    96,    11,  1.5f,  true,    20,  0.1f,  true,   450,  2000,     1,     0,   200,  1000,     0,     1),
                                        new WeaponValues(    96,    12,  1.4f,  true,    30,  0.1f,  true,   500,  2000,     1,     0,   200,  1000,     0,     1),
                                        new WeaponValues(    96,    13,  1.4f,  true,    45,  0.1f,  true,   550,  2000,     1,     0,   200,  1000,     0,     1),
                                        new WeaponValues(    96,    14,  1.3f,  true,    60,  0.1f,  true,   600,  2000,     1,     0,   200,  1000,     0,     1),
                                        new WeaponValues(    96,    15,  1.3f,  true,    80,  0.1f,  true,   650,  2000,     3,     5,   200,  1000,     0,  1.2f),
                                        new WeaponValues(    96,    16,  1.2f,  true,   110,  0.1f,  true,   700,  2000,     3,     5,   200,  1000,     0,  1.3f),
                                        new WeaponValues(    96,    18,  1.1f,  true,   150,  0.1f,  true,   750,  2000,     3,     5,   200,  1000,     0,  1.3f),
                                        new WeaponValues(    96,    20,     1,  true,   200,  0.1f,  true,   800,  2000,     5,     5,   200,  1000,     0,  1.3f) };
        }
        else if (itemId == 5) // fireball
        {
            return new WeaponValues[] { new WeaponValues(     0,     0,     0, false,     0,     0, false,     0,     0,     0,     0,     0,     0,     0,     0),
                                        new WeaponValues(   128,     0,  2.5f,  true,    20,  0.1f, false,   300,  2000,     1,     0,  1000,     0,     0,     1),
                                        new WeaponValues(   140,     0,  2.5f,  true,    50,  0.1f, false,   310,  2000,     1,     0,  1000,     0,     0,     1),
                                        new WeaponValues(   160,     0,  2.4f,  true,    80,  0.1f, false,   320,  2000,     1,     0,  1000,     0,     0,     1),
                                        new WeaponValues(   180,     0,  2.4f,  true,   110,  0.1f, false,   330,  2000,     1,     0,  1000,     0,     0,     1),
                                        new WeaponValues(   200,     0,  2.3f,  true,   140,  0.1f, false,   340,  2000,     1,     0,  1000,     0,     0,     1),
                                        new WeaponValues(   220,     0,  2.3f,  true,   180,  0.1f, false,   350,  2000,     1,     0,  1000,     0,     0,     1),
                                        new WeaponValues(   240,     0,  2.2f,  true,   220,  0.1f, false,   360,  2000,     1,     0,  1000,     0,     0,     1),
                                        new WeaponValues(   250,     0,  2.1f,  true,   260,  0.1f, false,   380,  2000,     1,     0,  1000,     0,     0,     1),
                                        new WeaponValues(   256,     0,     2,  true,   300,  0.1f, false,   400,  2000,     1,     0,  1000,     0,     0,     1) };
        }
        else if (itemId == 6) // aura
        {
            return new WeaponValues[] { new WeaponValues(     0,     0,     0, false,     0,     0, false,     0,     0,     0,     0,     0,     0,     0,     0),
                                        new WeaponValues(   350,     5,     5,  true,     5,  0.1f, false,     0,  9000,     1,     0,   100,     0, 0.01f,     1),
                                        new WeaponValues(   370,     5,     5,  true,     7,  0.1f, false,     0,  9000,     1,     0,   100,     0, 0.01f,     1),
                                        new WeaponValues(   400,     5,     5,  true,     9,  0.1f, false,     0,  9000,     1,     0,   100,     0, 0.01f,     1),
                                        new WeaponValues(   430,     5,     5,  true,    12,  0.1f, false,     0,  9000,     1,     0,   100,     0, 0.01f,     1),
                                        new WeaponValues(   460,     5,     5,  true,    15,  0.1f, false,     0,  9000,     1,     0,   100,     0, 0.01f,     1),
                                        new WeaponValues(   500,     5,     5,  true,    20,  0.1f, false,     0,  9000,     1,     0,   100,     0, 0.01f,     1),
                                        new WeaponValues(   540,     5,     5,  true,    30,  0.1f, false,     0,  9000,     1,     0,   100,     0, 0.01f,     1),
                                        new WeaponValues(   580,     5,     5,  true,    40,  0.1f, false,     0,  9000,     1,     0,   100,     0, 0.01f,     1),
                                        new WeaponValues(   650,     5,     5,  true,    50,  0.1f, false,     0,  9000,     1,     0,   100,     0, 0.01f,     1) };
        }

        return new WeaponValues[] { new WeaponValues(0, 0, 0, false, 0, 0, false, 0, 0, 0, 0, 0, 0, 0, 0) };
    }
}
