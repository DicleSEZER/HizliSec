using HizliSec.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HizliSec.Entities.Concrete.Dtos.CategoryDtos
{
    public class CategoryAddDto : IDto
    {
        public string Name { get; set; }
        public DateTime CreateDate { get; }
    }
}
