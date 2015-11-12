using TP0.Stuff.Armor;
using TP0.Entity;

namespace TP0.Loader.Factory
{
    class ArmorFactory
    {
        public ArmorFactory() {}

        public Item getArmor(ListArmor typeArmor)
        {            
            switch(typeArmor)
            {
                case ListArmor.SMALL_SHIELD:
                    return this.createSmallShield();

                case ListArmor.TALL_SHIELD:
                    return this.createTallShield();

                case ListArmor.HELMET:
                    return this.createHelmet();

                default:
                    return new Item("Unknow", 0, Stuff.TypeStuff.NONE);
            }
        }

        private Item createSmallShield()
        {
            Item armor = new Item("Petit boucler rond", 5, Stuff.TypeStuff.ARMOR);
            armor.addStats(new Stats(20, Stuff.TypeStats.CHANCE_PARRY));

            return armor;
        }

        private Item createTallShield()
        {
            Item armor = new Item("Bouclier rectangulaire", 8, Stuff.TypeStuff.ARMOR);
            armor.addStats(new Stats(30, Stuff.TypeStats.CHANCE_PARRY));

            return armor;
        }

        private Item createHelmet()
        {
            Item armor = new Item("Casque", 2, Stuff.TypeStuff.ARMOR);
            armor.addStats(new Stats(10, Stuff.TypeStats.CHANCE_PARRY));

            return armor;
        }
    }
}
