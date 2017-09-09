using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Terrain
{
    public interface IMapBuilder
    {
        char[,] Build();
    }
}
