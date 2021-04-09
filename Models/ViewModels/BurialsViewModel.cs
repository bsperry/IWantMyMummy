using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IWantMyMummy.Models.ViewModels
{
    public class BurialsViewModel
    {
        public List<Burial> Burials { get; set; }
        public PageNumberingInfo PageNumberingInfo { get; set; }

    }
}
