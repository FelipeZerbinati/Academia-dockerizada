using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia10.Domain.DTO
{
    public class PaginationRequest
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

}
