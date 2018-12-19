using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectChat
{

    public class MasterDetailMainMenuItem
    {
        public MasterDetailMainMenuItem()
        {
            TargetType = typeof(MasterDetailMainDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}