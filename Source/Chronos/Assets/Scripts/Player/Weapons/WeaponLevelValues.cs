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
                                        new WeaponValues(   128,     0,  0.8f, false,    50,     0, false,   500,   300,     1,     0,   700,     0,     0,     1),
                                        new WeaponValues(   128,     0,  0.8f, false,    70,     0, false,   550,   300,     1,     0,   700,     0,     0,     1),
                                        new WeaponValues(   128,     0,  0.7f, false,    90,     0, false,   600,   350,     1,     0,   700,     0,     0,     1),
                                        new WeaponValues(   128,     0,  0.7f, false,   130,     0, false,   650,   350,     1,     0,   700,     0,     0,     1),
                                        new WeaponValues(   128,     0,  0.6f, false,   170,     0, false,   700,   400,     1,     0,   750,     0,     0,     1),
                                        new WeaponValues(   128,     0,  0.6f, false,   210,     0, false,   750,   400,     1,     0,   750,     0,     0,     1),
                                        new WeaponValues(   128,     0,  0.5f, false,   260,     0, false,   800,   450,     3,    10,   750,     0,     0,  1.1f),
                                        new WeaponValues(   128,     0,  0.5f, false,   320,     0, false,   850,   450,     3,    10,   800,     0,     0,  1.1f),
                                        new WeaponValues(   128,     0,  0.4f, false,   400,     0, false,   900,   500,     3,    10,   800,     0,     0,  1.1f) };
        }
        else if (itemId == 1) // shield
        {
            return new WeaponValues[] { new WeaponValues(     0,     0,     0, false,     0,     0, false,     0,     0,     0,     0,     0,     0,     0,     0),
                                        new WeaponValues(   128,     2,     3,  true,     5,     0, false,     2,  1000,     3,   120,   500,     0,    60,     1),
                                        new WeaponValues(   128,     2,  2.9f,  true,     7,     0, false,  2.2f,  1000,     3,   120,   500,     0,    60,     1),
                                        new WeaponValues(   128,     2,  2.8f,  true,    10,     0, false,  2.4f,  1000,     3,   120,   500,     0,    70,     1),
                                        new WeaponValues(   128,     2,  2.7f,  true,    13,     0, false,  2.6f,  1000,     4,    90,   500,     0,    70,     1),
                                        new WeaponValues(   128,     2,  2.6f,  true,    17,     0, false,  2.8f,  1000,     4,    90,   500,     0,    80,     1),
                                        new WeaponValues(   128,     2,  2.5f,  true,    22,     0, false,     3,  1000,     4,    90,   500,     0,    80,     1),
                                        new WeaponValues(   128,     2,  2.4f,  true,    28,     0, false,  3.2f,  1000,     4,    90,   500,     0,    90,     1),
                                        new WeaponValues(   128,     2,  2.2f,  true,    36,     0, false,  3.4f,  1000,     4,    90,   500,     0,    90,     1),
                                        new WeaponValues(   128,     2,     2,  true,    50,     0, false,  3.6f,  1000,     6,    60,   500,     0,   100,     1) };
        }
        else if (itemId == 2) // shuriken
        {
            return new WeaponValues[] { new WeaponValues(     0,     0,     0, false,     0,     0, false,     0,     0,     0,     0,     0,     0,     0,     0),
                                        new WeaponValues(   128,     0,  1.5f,  true,     5,     0, false,   300,   300,     3,    10,   500,   500,     0,  1.1f),
                                        new WeaponValues(   128,     0,  1.5f,  true,     7,     0, false,   300,   300,     3,    10,   500,   500,     0,  1.1f),
                                        new WeaponValues(   128,     0,  1.4f,  true,    10,     0, false,   350,   300,     3,    10,   500,   500,     0,  1.1f),
                                        new WeaponValues(   128,     0,  1.4f,  true,    13,     0, false,   350,   350,     5,    10,   500,   500,     0,  1.2f),
                                        new WeaponValues(   128,     0,  1.3f,  true,    17,     0, false,   400,   350,     5,    10,   500,   500,     0,  1.2f),
                                        new WeaponValues(   128,     0,  1.3f,  true,    21,     0, false,   450,   350,     5,    10,   500,   500,     0,  1.2f),
                                        new WeaponValues(   128,     0,  1.2f,  true,    25,     0, false,   500,   400,     5,    10,   500,   500,     0,  1.3f),
                                        new WeaponValues(   128,     0,  1.1f,  true,    30,     0, false,   550,   400,     7,    10,   500,   500,     0,  1.3f),
                                        new WeaponValues(   128,     0,     1,  true,    35,     0, false,   600,   400,     7,    10,   500,   500,     0,  1.3f) };

        }
        else if (itemId == 3) // sword
        {
            return new WeaponValues[] { new WeaponValues(     0,     0,     0, false,     0,     0, false,     0,     0,     0,     0,     0,     0,     0,     0),
                                        new WeaponValues(   256,  0.2f,     2,  true,    20,     0, false,    10,   100,     1,     0,  1000,     0,     0,     1),
                                        new WeaponValues(   256,  0.2f,  1.9f,  true,    30,     0, false,    10,   100,     1,     0,  1000,     0,     0,     1),
                                        new WeaponValues(   256,  0.2f,  1.8f,  true,    40,     0, false,    10,   100,     1,     0,  1000,     0,     0,     1),
                                        new WeaponValues(   256,  0.2f,  1.7f,  true,    55,     0, false,    10,   100,     1,     0,  1000,     0,     0,     1),
                                        new WeaponValues(   256,  0.2f,  1.6f,  true,    70,     0, false,    10,   100,     1,     0,  1000,     0,     0,     1),
                                        new WeaponValues(   256,  0.2f,  1.5f,  true,    90,     0, false,    10,   100,     1,     0,  1000,     0,     0,     1),
                                        new WeaponValues(   256,  0.2f,  1.4f,  true,   110,     0, false,    10,   100,     1,     0,  1000,     0,     0,     1),
                                        new WeaponValues(   256,  0.2f,  1.2f,  true,   130,     0, false,    10,   100,     1,     0,  1000,     0,     0,     1),
                                        new WeaponValues(   256,  0.2f,     1,  true,   150,     0, false,    10,   100,     1,     0,  1000,     0,     0,     1) };
        }
        else if (itemId == 4) // bounce
        {
            return new WeaponValues[] { new WeaponValues(    96,     0,     0, false,     0,     0, false,     0,     0,     0,     0,     0,     0,     0,     0),
                                        new WeaponValues(    96,    10,  1.5f,  true,    10,     0,  true,   400,  2000,     1,     0,   200,  1000,     0,     1),
                                        new WeaponValues(    96,    11,  1.5f,  true,    20,     0,  true,   450,  2000,     1,     0,   200,  1000,     0,     1),
                                        new WeaponValues(    96,    12,  1.4f,  true,    30,     0,  true,   500,  2000,     1,     0,   200,  1000,     0,     1),
                                        new WeaponValues(    96,    13,  1.4f,  true,    45,     0,  true,   550,  2000,     1,     0,   200,  1000,     0,     1),
                                        new WeaponValues(    96,    14,  1.3f,  true,    60,     0,  true,   600,  2000,     1,     0,   200,  1000,     0,     1),
                                        new WeaponValues(    96,    15,  1.3f,  true,    80,     0,  true,   650,  2000,     3,     5,   200,  1000,     0,  1.2f),
                                        new WeaponValues(    96,    16,  1.2f,  true,   110,     0,  true,   700,  2000,     3,     5,   200,  1000,     0,  1.3f),
                                        new WeaponValues(    96,    18,  1.1f,  true,   150,     0,  true,   750,  2000,     3,     5,   200,  1000,     0,  1.3f),
                                        new WeaponValues(    96,    20,     1,  true,   200,     0,  true,   800,  2000,     5,     5,   200,  1000,     0,  1.3f) };
        }
        else if (itemId == 5) // fireball
        {
            return new WeaponValues[] { new WeaponValues(     0,     0,     0, false,     0,     0, false,     0,     0,     0,     0,     0,     0,     0,     0),
                                        new WeaponValues(   128,     0,  2.5f,  true,    20,     0, false,   300,  1000,     1,     0,  1000,     0,     0,     1),
                                        new WeaponValues(   140,     0,  2.5f,  true,    50,     0, false,   310,  1000,     1,     0,  1000,     0,     0,     1),
                                        new WeaponValues(   160,     0,  2.4f,  true,    80,     0, false,   320,  1000,     1,     0,  1000,     0,     0,     1),
                                        new WeaponValues(   180,     0,  2.4f,  true,   110,     0, false,   330,  1000,     1,     0,  1000,     0,     0,     1),
                                        new WeaponValues(   200,     0,  2.3f,  true,   140,     0, false,   340,  1000,     1,     0,  1000,     0,     0,     1),
                                        new WeaponValues(   220,     0,  2.3f,  true,   180,     0, false,   350,  1000,     1,     0,  1000,     0,     0,     1),
                                        new WeaponValues(   240,     0,  2.2f,  true,   220,     0, false,   360,  1000,     1,     0,  1000,     0,     0,     1),
                                        new WeaponValues(   250,     0,  2.1f,  true,   260,     0, false,   380,  1000,     1,     0,  1000,     0,     0,     1),
                                        new WeaponValues(   256,     0,     2,  true,   300,     0, false,   400,  1000,     1,     0,  1000,     0,     0,     1) };
        }
        else if (itemId == 6) // aura
        {
            return new WeaponValues[] { new WeaponValues(     0,     0,     0, false,     0,     0, false,     0,     0,     0,     0,     0,     0,     0,     0),
                                        new WeaponValues(   450,     5,     5,  true,     5,     0, false,     0,  9000,     1,     0,   100,     0, 0.01f,     1),
                                        new WeaponValues(   470,     5,     5,  true,     7,     0, false,     0,  9000,     1,     0,   100,     0, 0.01f,     1),
                                        new WeaponValues(   500,     5,     5,  true,     9,     0, false,     0,  9000,     1,     0,   100,     0, 0.01f,     1),
                                        new WeaponValues(   530,     5,     5,  true,    12,     0, false,     0,  9000,     1,     0,   100,     0, 0.01f,     1),
                                        new WeaponValues(   560,     5,     5,  true,    15,     0, false,     0,  9000,     1,     0,   100,     0, 0.01f,     1),
                                        new WeaponValues(   600,     5,     5,  true,    20,     0, false,     0,  9000,     1,     0,   100,     0, 0.01f,     1),
                                        new WeaponValues(   640,     5,     5,  true,    30,     0, false,     0,  9000,     1,     0,   100,     0, 0.01f,     1),
                                        new WeaponValues(   680,     5,     5,  true,    40,     0, false,     0,  9000,     1,     0,   100,     0, 0.01f,     1),
                                        new WeaponValues(   750,     5,     5,  true,    50,     0, false,     0,  9000,     1,     0,   100,     0, 0.01f,     1) };
        }

        return new WeaponValues[] { new WeaponValues(0, 0, 0, false, 0, 0, false, 0, 0, 0, 0, 0, 0, 0, 0) };
    }
}
