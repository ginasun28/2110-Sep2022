using System;
using System.Collections.Generic;
using System.Text;

namespace _2110_Sep2022.TableStorage
{
    public interface IStorageConfiguration
    {
        string GetStorageConnectionString();
    }
}
