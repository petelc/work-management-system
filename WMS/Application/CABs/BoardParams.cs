using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;

namespace Application.CABs
{
    public class BoardParams : PagingParams
    {
        public bool IsNew { get; set; }
    }
}