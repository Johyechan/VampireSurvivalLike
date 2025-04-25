using System.Collections.Generic;

namespace Enemy.Boss.Interface
{
    public interface IBossPart
    {
        public List<IBossPattern> Patterns { get; }
        public float MaxHp { get; }

        public bool IsDestroy { get; }

        public IBossPattern RandomPattern();
    }
}

