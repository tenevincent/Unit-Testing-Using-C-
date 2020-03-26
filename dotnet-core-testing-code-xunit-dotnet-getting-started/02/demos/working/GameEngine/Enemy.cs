namespace GameEngine
{
    public abstract class Enemy
    {
        public string Name { get; set; }
        public abstract double TotalSpecialPower { get; }
        public abstract double SpecialPowerUses { get; }
        public double SpecialAttackPower => TotalSpecialPower / SpecialPowerUses;

        public override bool Equals(object obj)
        {
            var other = obj as Enemy;
            if(null == other) { return false; }

            return this.Name.Equals(other.Name);


        }
    }
}