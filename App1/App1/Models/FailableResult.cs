using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    public class FailableResult<T>
    {
        public string Error;
        public T Result;
    }
}
