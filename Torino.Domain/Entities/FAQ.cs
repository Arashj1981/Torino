using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torino.Domain.Entities
{
    public class FAQ : BaseEntity
    {
        

        public string Question { get; set; }=string.Empty;

        public string Answer { get; set; }= string.Empty;

        public FAQ(string question, string answer)
        {
            Question = question;
            Answer = answer;
        }


    }
}
