using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeMan
{
    public interface IToDoStorage
    {
        System.IO.Stream OpenReader(string file);
        System.IO.Stream OpenWriter(string file);
    }
}
