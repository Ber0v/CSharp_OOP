using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Core.Interfaces
{
    public interface ICommand
    {
        string Execute(string[] args);
    }
}
