using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTE.Utils
{
    public delegate void ListOptionHandler(ListOption option);

    /// <summary>
    /// Represents a list option. Name is the text displayed, but it should not contain a newline.
    /// </summary>
    public record ListOption(string Name, string Value);
}
