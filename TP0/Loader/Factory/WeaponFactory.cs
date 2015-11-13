using TP0.Stuff.Weapon;
using TP0.Entity;

namespace TP0.Loader.Factory
{
    class WeaponFactory
    {
        public WeaponFactory() {}

        public Item getArmor(ListWeapon typeWeapon)
        {
            switch(typeWeapon)
            {
                case ListWeapon.DAGGER:
                    return this.createDagger();

                case ListWeapon.SWORM:
                    return this.createSworm();

                case ListWeapon.SPEAR:
                    return this.createSpear();

                case ListWeapon.TRIDENT:
                    return this.createTrident();

                case ListWeapon.FILET:
                    return this.createFilet();

                default:
                    return null;
            }
        }

        private Item createDagger()
        {
            Item item = new Item("Dague", 2, Stuff.TypeStuff.WEAPON);
            item.addStats(new Stats(60, Stuff.TypeStats.CHANCE_HIT));

            return item;
        }

        private Item createSworm()
        {
            Item item = new Item("Epée", 5, Stuff.TypeStuff.WEAPON);
            item.addStats(new Stats(70, Stuff.TypeStats.CHANCE_HIT));

            return item;
        }

        private Item createSpear()
        {
            Item item = new Item("Lance", 7, Stuff.TypeStuff.WEAPON);
            item.addStats(new Stats(50, Stuff.TypeStats.CHANCE_HIT));

            return item;
        }

        private Item createTrident()
        {
            Item item = new Item("Trident", 7, Stuff.TypeStuff.WEAPON);
            item.addStats(new Stats(30, Stuff.TypeStats.CHANCE_HIT));
            item.addStats(new Stats(10, Stuff.TypeStats.CHANCE_PARRY));

            return item;
        }

        private Item createFilet()
        {
            Item item = new Item("Filet", 3, Stuff.TypeStuff.WEAPON);
            item.addStats(new Stats(30, Stuff.TypeStats.CHANCE_HIT));

            return item;
        }
    }
}
