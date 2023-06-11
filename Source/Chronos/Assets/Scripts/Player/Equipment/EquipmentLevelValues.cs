public static class EquipmentLevelValues
{
    public static EquipmentValues[] GetEquipmentValues(int itemId)
    {
        if (itemId == 50) // heart container
        {
            return new EquipmentValues[] {  new EquipmentValues(     0,     0,     0,     0,     0,     1,     1,     1,     1,     1),
                                            new EquipmentValues(     2,     0,     0,     0,     0,     1,     1,     1,     1,     1),
                                            new EquipmentValues(     2,     0,     0,     0,     0,     1,     1,     1,     1,     1),
                                            new EquipmentValues(     2,     0,     0,     0,     0,     1,     1,     1,     1,     1),
                                            new EquipmentValues(     2,     0,     0,     0,     0,     1,     1,     1,     1,     1),
                                            new EquipmentValues(     2,     0,     0,     0,     0,     1,     1,     1,     1,     1),
                                            new EquipmentValues(     4,     0,     0,     0,     0,     1,     1,     1,     1,     1) };
        }
        else if (itemId == 51) // fast boots
        {
            return new EquipmentValues[] {  new EquipmentValues(     0,     0,     0,     0,     0,     1,     1,     1,     1,     1),
                                            new EquipmentValues(     0,     0,    20,     0,     0,     1,     1,     1,     1,     1),
                                            new EquipmentValues(     0,     0,    20,     0,     0,     1,     1,     1,     1,     1),
                                            new EquipmentValues(     0,     0,    20,     0,     0,     1,     1,     1,     1,     1),
                                            new EquipmentValues(     0,     0,    20,     0,     0,     1,     1,     1,     1,     1),
                                            new EquipmentValues(     0,     0,    20,     0,     0,     1,     1,     1,     1,     1),
                                            new EquipmentValues(     0,     0,    40,     0,     0,     1,     1,     1,     1,     1) };
        }
        else if (itemId == 52) // regeneration ring
        {
            return new EquipmentValues[] {  new EquipmentValues(     0,     0,     0,     0,     0,     1,     1,     1,     1,     1),
                                            new EquipmentValues(     0,     1,     0,     0,     0,     1,     1,     1,     1,     1),
                                            new EquipmentValues(     0,     1,     0,     0,     0,     1,     1,     1,     1,     1),
                                            new EquipmentValues(     0,     1,     0,     0,     0,     1,     1,     1,     1,     1),
                                            new EquipmentValues(     0,     1,     0,     0,     0,     1,     1,     1,     1,     1),
                                            new EquipmentValues(     0,     1,     0,     0,     0,     1,     1,     1,     1,     1),
                                            new EquipmentValues(     0,     2,     0,     0,     0,     1,     1,     1,     1,     1) };
        }
        else if (itemId == 53) // range amulett
        {
            return new EquipmentValues[] {  new EquipmentValues(     0,     0,     0,     0,     0,     1,     1,     1,     1,     1),
                                            new EquipmentValues(     0,     0,     0,     0,     0,     1,  1.1f,     1,     1,     1),
                                            new EquipmentValues(     0,     0,     0,     0,     0,     1,  1.1f,     1,     1,     1),
                                            new EquipmentValues(     0,     0,     0,     0,     0,     1,  1.1f,     1,     1,     1),
                                            new EquipmentValues(     0,     0,     0,     0,     0,     1,  1.1f,     1,     1,     1),
                                            new EquipmentValues(     0,     0,     0,     0,     0,     1,  1.1f,     1,     1,     1),
                                            new EquipmentValues(     0,     0,     0,     0,     0,     1,  1.2f,     1,     1,     1) };
        }
        else if (itemId == 54) // mighty ring
        {
            return new EquipmentValues[] {  new EquipmentValues(     0,     0,     0,     0,     0,     1,     1,     1,     1,     1),
                                            new EquipmentValues(     0,     0,     0,     0,     0,  1.1f,     1,     1,  1.1f,     1),
                                            new EquipmentValues(     0,     0,     0,     0,     0,  1.1f,     1,     1,  1.1f,     1),
                                            new EquipmentValues(     0,     0,     0,     0,     0,  1.1f,     1,     1,  1.1f,     1),
                                            new EquipmentValues(     0,     0,     0,     0,     0,  1.1f,     1,     1,  1.1f,     1),
                                            new EquipmentValues(     0,     0,     0,     0,     0,  1.1f,     1,     1,  1.1f,     1),
                                            new EquipmentValues(     0,     0,     0,     0,     0,  1.1f,     1,     1,  1.1f,     1) };
        }
        else if (itemId == 55) // lucky charm
        {
            return new EquipmentValues[] {  new EquipmentValues(     0,     0,     0,     0,     0,     1,     1,     1,     1,     1),
                                            new EquipmentValues(     0,     0,     0,    50,    20,     1,     1,     1,     1,     1),
                                            new EquipmentValues(     0,     0,     0,    50,    20,     1,     1,     1,     1,     1),
                                            new EquipmentValues(     0,     0,     0,    50,    20,     1,     1,     1,     1,     1),
                                            new EquipmentValues(     0,     0,     0,    50,    20,     1,     1,     1,     1,     1),
                                            new EquipmentValues(     0,     0,     0,    50,    20,     1,     1,     1,     1,     1),
                                            new EquipmentValues(     0,     0,     0,   100,    40,     1,     1,     1,     1,     1) };
        }

        return new EquipmentValues[] { new EquipmentValues(0, 0, 0, 0, 0, 0, 0, 0, 0, 0) };
    }
}