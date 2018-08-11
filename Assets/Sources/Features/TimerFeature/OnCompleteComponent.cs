using System;
using Entitas;

namespace cln
{
    [Game]
    public class OnCompleteComponent : IComponent
    {
        public Action act;
    }
}