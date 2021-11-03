using System;
using System.Collections.Generic;
using System.Text;

namespace Codereview
{
    public interface IGameLoopObject
    {
        public void Start();
        public void Update();
    }
}
