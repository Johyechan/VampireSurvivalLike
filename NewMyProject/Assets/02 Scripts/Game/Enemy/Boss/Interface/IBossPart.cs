using System.Collections.Generic;

namespace Enemy.Boss.Interface
{
    public interface IBossPart
    {
        public List<IBossPattern> Patterns { get; }

        public void RandomPattern();
    }
}

