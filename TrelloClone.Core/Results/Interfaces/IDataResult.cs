﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloClone.Core.Results.Interfaces
{
    public interface IDataResult<T> : IResult where T : class
    {
        T Data { get; }
    }
}