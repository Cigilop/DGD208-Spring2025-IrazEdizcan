using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGD208_Final_IrazEdizcan
{
    public interface IPet
    {
        string Type { get; }
        void Speak();
    }
}