using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP0.Debuff;
using TP0.Entity;
using TP0.Stuff;

namespace TP0.Gameplay
{
    public enum Hit
    {
        NOPE = 0,
        TRAPPED = 1,
        TOUCH = 2
    }

    class Duel
    {
        private Gladiator _gladiatorA;
        private Gladiator _gladiatorB;

        public Duel(Gladiator gladiatorA, Gladiator gladiatorB)
        {
            this._gladiatorA = gladiatorA;
            this._gladiatorB = gladiatorB;
        }

        public void fight()
        {
            while (this.allGladiatorIsAlive())
            {
                Hit hitGladiatorA = this.hit(this._gladiatorA, this._gladiatorB);
                Hit hitGladiatorB = this.hit(this._gladiatorB, this._gladiatorA);

                this.setEffect(hitGladiatorA, this._gladiatorB);
                this.setEffect(hitGladiatorB, this._gladiatorA);
            }
        }

        private Hit hit(Gladiator attacker, Gladiator defenser)
        {
            List<SlotStuff> hits = attacker.getSlotByStats(TypeStats.CHANCE_HIT);
            List<SlotStuff> parries = defenser.getSlotByStats(TypeStats.CHANCE_PARRY);

            foreach(SlotStuff slotForHit in hits)
            {
                uint chanceHit = attacker.chanceHit(slotForHit);

                if (this.diceRool(chanceHit))
                {
                    // Le filet ne peut pas être parré
                    if (attacker.isFilet(slotForHit)) {
                        return Hit.TRAPPED;
                    }

                    foreach (SlotStuff slotForParry in parries)
                    {
                        uint chanceParry = defenser.chanceParry(slotForParry);

                        if (this.diceRool(chanceParry)) {
                            return Hit.TOUCH;
                        }
                    }
                }
            }

            return Hit.NOPE;
        }

        private void setEffect(Hit hit, Gladiator gladiator)
        {
            switch(hit)
            {
                case Hit.TRAPPED:
                    gladiator.debuff = new Trapped();
                    break;

                case Hit.TOUCH:
                    gladiator.debuff = new Dead();
                    break;
            }
        }

        private bool diceRool(uint chance)
        {
            Random dice = new Random();
            int nb = dice.Next(101);

            return (chance >= nb);
        }

        private bool allGladiatorIsAlive()
        {
            return (this._gladiatorA.isAlive() && this._gladiatorB.isAlive());
        }
    }
}
