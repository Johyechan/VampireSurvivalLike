using System.Collections.Generic;

namespace Enemy.Boss.Interface
{
    public interface IBossPart
    {
        public IBossPattern Pattern { get; }
    }
}

